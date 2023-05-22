namespace VinaOfficeWebsite.Dto
{
    public class OrderDto
    {
        public string FullName { get; set; }
        public string Address { get; set; } = "";
        public string Email { get; set; } = "";
        public string Note { get; set; } = "";
        public string PhoneNumber { get; set; }
        public string IsCOD { get; set; } = "1";
        public string Cart { get; set; }
    }
}
