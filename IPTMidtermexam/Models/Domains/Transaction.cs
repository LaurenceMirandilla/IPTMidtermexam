using IPTMidtermexam.DTO.TransactionDTO;

namespace IPTMidtermexam.Model.Domain
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now; // Default to current date/time
        public int? CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal ChangeGiven { get; set; }
        public string PaymentMethod { get; set; }
        public bool? IsDeleted { get; set; }
        public Customer Customer { get; set; }
        public List<TransactionItemDTO> TransactionItems { get; set; }

    }
}
