namespace Notes.Web.PL.Models
{
    public class AccountUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public DateTime Reg { get; set; }
    }
}
