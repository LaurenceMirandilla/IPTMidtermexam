namespace IPTMidtermexam.DTO.TransactionDTO
{
    public class CreateTransactionDTO
    {
        public int? CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal ChangeGiven { get; set; }
        public string PaymentMethod { get; set; }
        public TransactionItemDTO TransactionItem { get; set; }
         public List<TransactionItemDTO> TransactionItems { get; set; }
    }
    public class CreateTransactionItemDTO
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
