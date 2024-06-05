namespace DBL.Entities
{
    public class Staffresetpassword
    {
        public long Staffid { get; set; }
        public string? Passwords { get; set; }
        public string? Confirmpassword { get; set; }
        public string? Passwordhash { get; set; }
    }
}
