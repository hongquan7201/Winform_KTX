namespace ProjectQLKTX.APIsHelper.BienLaiHelper
{
    public class BienLaiResponse<T>where T: class
    {
        public string message { get; set; }
        public int status { get; set; }
        public T? data { get; set; }
    }
}
