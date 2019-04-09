namespace Pages.Models
{
    public class NewCustomerModel
    {
        public string TaxId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Newsletter { get; set; }
        public string DesiredPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}