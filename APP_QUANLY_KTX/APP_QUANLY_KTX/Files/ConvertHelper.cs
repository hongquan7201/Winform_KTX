using DevExpress.CodeParser;
using ProjectQLKTX.Models;
using static DevExpress.Data.Filtering.Helpers.SubExprHelper;

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
        public static string ConvertToVndText(decimal? number )
        {
            string[] ones = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] tens = { "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };
            string[] thousands = { "", "nghìn", "triệu", "tỷ" };

            int scale = 0;
            decimal? wholePart = decimal.Truncate(number ?? 0);
            decimal? fractionPart = Math.Abs(number ?? 0) % 1 * 100;

            if (wholePart == 0)
            {
                return ones[0] + " đồng";
            }

            string text = "";
            int i = 0;

            while (wholePart > 0)
            {
                int n = (int)(wholePart % 1000);
                if (n != 0)
                {
                    string s = "";
                    if (n < 10)
                    {
                        s = ones[n];
                    }
                    else if (n < 20)
                    {
                        s = "mười " + ones[n - 10];
                    }
                    else if (n < 100)
                    {
                        int m = n / 10;
                        int d = n % 10;
                        if (d == 0)
                        {
                            s = tens[m - 1];
                        }
                        else
                        {
                            s = tens[m - 1] + " " + ones[d];
                        }
                    }
                    else
                    {
                        int h = n / 100;
                        int m = (n % 100) / 10;
                        int d = n % 10;
                        if (m == 0 && d == 0)
                        {
                            s = ones[h] + " trăm";
                        }
                        else if (m == 0)
                        {
                            s = ones[h] + " trăm lẻ " + ones[d];
                        }
                        else if (m == 1)
                        {
                            s = ones[h] + " trăm mười " + ones[d];
                        }
                        else if (d == 0)
                        {
                            s = ones[h] + " trăm " + tens[m - 1];
                        }
                        else
                        {
                            s = ones[h] + " trăm " + tens[m - 1] + " " + ones[d];
                        }
                    }
                    text = s + " " + thousands[i] + " " + text;
                }
                wholePart = decimal.Truncate(wholePart ?? 0 / 1000);
                i++;
            }

            if (fractionPart > 0)
            {
                text += "lẻ ";
                int n = (int)fractionPart;
                if (n < 10)
                {
                    text += ones[n];
                }
                else if (n < 20)
                {
                    text += ones[n - 10] + " mười";
                }
                else
                {
                    int m = n / 10;
                    int d = n % 10;
                    if (d == 0)
                    {
                        text += tens[m - 1];
                    }
                    else
                    {
                        text += tens[m - 1] + " " + ones[d];
                    }
                }
                text += " xu";
            }
            else
            {
                text += "đồng";
            }
            return text.Trim();

        }
    }
}
