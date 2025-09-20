using AutoMapper;
using IPTMidtermexam.Data;
using IPTMidtermexam.DTO.TransactionDTO;
using IPTMidtermexam.DTO;
using IPTMidtermexam.Model.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IPTMidtermexam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ApplicationDbContext context, IMapper mapper, ILogger<TransactionsController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        // 1. Get all transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetTransactions()
        {
            var transactions = await _context.Transactions
                .Where(t => t.IsDeleted == null || t.IsDeleted == false) // Exclude soft-deleted transactions
                .Include(t => t.Customer) // Include related customer data
                .ToListAsync();

            // Map Transaction entities to TransactionDTOs
            var transactionDTOs = _mapper.Map<List<TransactionDTO>>(transactions);
            return Ok(transactionDTOs);
        }

        // 2. Get a single transaction by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDTO>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions
                .Where(t => t.IsDeleted == null || t.IsDeleted == false) // Exclude soft-deleted transactions
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(t => t.TransactionID == id);

            if (transaction == null)
            {
                return NotFound();
            }

            // Map to TransactionDTO
            var transactionDTO = _mapper.Map<TransactionDTO>(transaction);
            return Ok(transactionDTO);
        }

        // 3. Create a new transaction
        [HttpPost]
        public async Task<ActionResult<TransactionDTO>> CreateTransaction([FromBody] CreateTransactionDTO createTransactionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map CreateTransactionDTO to the Transaction entity
            var transaction = _mapper.Map<Transaction>(createTransactionDTO);

            // Add the transaction to the database
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            // Return the created transaction as a DTO
            var transactionDTO = _mapper.Map<TransactionDTO>(transaction);
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.TransactionID }, transactionDTO);
        }

        // 4. Update an existing transaction
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] UpdateTransactionDTO updateTransactionDTO)
        {
            if (id != updateTransactionDTO.TransactionID)
            {
                return BadRequest("Transaction ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the existing transaction to update
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.TransactionID == id && (t.IsDeleted == null || t.IsDeleted == false));

            if (transaction == null)
            {
                return NotFound();
            }

            // Map the updated data from UpdateTransactionDTO to the transaction entity
            _mapper.Map(updateTransactionDTO, transaction);

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Return the updated transaction as a DTO
            return NoContent();
        }

        // 5. Soft delete a transaction
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            // Find the transaction to "soft delete"
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.TransactionID == id && (t.IsDeleted == null || t.IsDeleted == false));

            if (transaction == null)
            {
                return NotFound();
            }

            // Mark the transaction as deleted
            transaction.IsDeleted = true;

            // Update the transaction in the database
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();

            return NoContent(); // Successfully "soft deleted"
        }

        // Check if a transaction exists
        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(t => t.TransactionID == id);
        }
    }
}
