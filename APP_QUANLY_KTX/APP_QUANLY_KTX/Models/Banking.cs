namespace ProjectQLKTX.Models
{
    public class Banking
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Type { get; set; }
        public string? Comment { get; set; }
        public DateTime CreateAt { get; set; }
        public decimal? Amount { get; set; }
        public Guid? IdUser { get; set; }
        public Guid? IdHoaDon { get; set; }
        public Guid? IdBienLai { get; set; }
        public string? Name { get;set; }
        public string? Sdt { get; set; }
        public string? Email { get;set; }
        public string? NamePhong { get;set; }
        public string? NameKhu { get;set; }
        public int? STT { get;set; }
    }
}
