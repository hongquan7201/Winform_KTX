namespace ProjectQLKTX.Models
{
    public class ChangePasswordNhanVien
    {
        public Guid idNhanVien { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
