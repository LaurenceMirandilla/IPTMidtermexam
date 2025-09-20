namespace IPTMidtermexam.Model.Domain
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
