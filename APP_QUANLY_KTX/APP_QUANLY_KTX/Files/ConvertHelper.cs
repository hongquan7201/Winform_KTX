namespace ProjectQLKTX.Files
{
    public class ConvertHelper
    {
        public static string ConvertToGuid(Guid guid)
        {
            return guid.ToString();
        }
        public static Guid ConvertString(string nameString)
        {
            Guid guid;
            if (Guid.TryParse(nameString, out guid))
            {
                return guid;
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
}
