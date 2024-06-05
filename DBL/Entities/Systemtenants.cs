namespace DBL.Entities
{
    public class Systemtenants
    {
        public long Tenantid { get; set; }
        public string? Tenantname { get; set; }
        public string? Tenantlogo { get; set; }
        public string? Emailserver { get; set; }
        public string? Emailpassword { get; set; }
        public string? Consumerkey { get; set; }
        public string? Shortcode { get; set; }
        public string? Consumersecret { get; set; }
        public string? Tenantlipanampesapasskey { get; set; }
        public string? Tenantstatus { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public string? Extra6 { get; set; }
        public string? Extra7 { get; set; }
        public string? Extra8 { get; set; }
        public string? Extra9 { get; set; }
        public string? Extra10 { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
    }
}

