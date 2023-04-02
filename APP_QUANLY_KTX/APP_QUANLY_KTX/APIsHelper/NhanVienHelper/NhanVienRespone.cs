namespace ProjectQLKTX.APIsHelper.NhanVienHelper
{
    public class NhanVienRespone<T> where T : class
    {
        public string message { get; set; }
        public int status { get; set; }
        public T data { get; set; }
    }
}
