namespace IPTMidtermexam.DTO.TransactionDTO
{
    public class TransactionItemDTO
    {
        public int TransactionItemID { get; set; }
        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
        public bool? IsDeleted { get; set; }

    }
}

