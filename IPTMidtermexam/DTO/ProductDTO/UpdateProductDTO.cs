namespace IPTMidtermexam.DTO.ProductDTO
{
    public class UpdateProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
