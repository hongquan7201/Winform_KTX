namespace ProjectQLKTX.Models
{
    public class Banking
    {
        public Guid Id { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public string cmt { get; set; }
        public DateTime creatAt { get; set; }
        public string amount { get; set; }
        public Guid? idSinhVien { get; set; }
        public string? Name { get;set; }
        public string? Sdt { get; set; }
        public string? Email { get;set; }
        public string? NamePhong { get;set; }
        public string? NameKhu { get;set; }
        public int? STT { get;set; }
    }
}
