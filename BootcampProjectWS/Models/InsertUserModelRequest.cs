namespace BootcampProjectWS.Models
{
    public class InsertUserModelRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Rolid {  get; set; }
        public int Statusid { get; set; }
    }
}
