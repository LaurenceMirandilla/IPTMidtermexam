namespace IPTMidtermexam.Model.Domain
{
    public class TransactionItem
    {
        public int TransactionItemID { get; set; }
        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
        public Transaction Transaction { get; set; }
        public Product Product { get; set; }
    }
}
