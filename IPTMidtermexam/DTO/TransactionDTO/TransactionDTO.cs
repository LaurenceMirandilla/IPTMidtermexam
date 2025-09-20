namespace IPTMidtermexam.DTO.TransactionDTO
{
    public class TransactionDTO
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int? CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal ChangeGiven { get; set; }
        public string PaymentMethod { get; set; }
        public bool? IsDeleted { get; set; }
        public List<TransactionItemDTO> TransactionItems { get; set; }

    }
}
