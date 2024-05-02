namespace BootcampProjectWS.Models
{
    public class InsertClientModelRequest
    {
        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public string Identification { get; set; } = null!;

        public string Phonenumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string? Referenceaddress { get; set; }

        public string Email { get; set; } = null!;
    }
}
