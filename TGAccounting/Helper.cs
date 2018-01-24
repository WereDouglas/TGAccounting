using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TGAccounting
{
    public static class Helper
    {
        public static CultureInfo cultureinfo = CultureInfo.CurrentCulture;
        public static string UserID;
        public static string CompanyID;
        public static string UserName;
        public static string UserImage;
        public static string CurrentYear;
        public static int UserLevel;
        public static DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(jan1, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);


            // var firstDayWeek = ci.Calendar.GetWeekOfYear( d, CalendarWeekRule.FirstDay,   DayOfWeek.Monday);
        }
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            DayOfWeek firstDay = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(1);
            return firstDayInWeek;
        }

        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            return cal.GetWeekOfYear(time, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            /***  DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
             if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
              {
                  time = time.AddDays(3);
              }

              return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday); **/
        }
        public static void Exceptions(string message, string process)
        {
            string id = Guid.NewGuid().ToString();
            string Query = "INSERT INTO exceptions(id,message, page,created) VALUES ('" + id + "','" + message + "','" + process + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "');";
            DBConnect.save(Query);
        }
        public static void Log(string userName, string actions)
        {
            string id = Guid.NewGuid().ToString();
            string Query = "INSERT INTO logs(id,name,actions,created) VALUES ('" + id + "','" + userName + "','" + actions + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "');";
            DBConnect.save(Query);
        }
        public static string CleanString(string str)
        {
            return str.Replace("'", "''");
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        static string base64String = null;
        public static System.Drawing.Image Base64ToImage(string bases)
        {
            byte[] imageBytes = Convert.FromBase64String(bases);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static MemoryStream ImageToStream(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, format);
            return ms;
        }
        public static bool validateDouble(string t)
        {

            double n;
            if (!double.TryParse(t, out n))
            {
                return false;
            }
            else { return true; }

        }
        public static bool validateInt(string t)
        {

            int p;
            if (!int.TryParse(t, out p))
            {
                return false;
            }
            else { return true; }

        }
        public static bool ifEmpty(string t)
        {

            if (String.IsNullOrEmpty(t))
            {
                return false;
            }
            else { return true; }

        }

        public static string ImageToBase64(MemoryStream images)
        {

            using (System.Drawing.Image image = System.Drawing.Image.FromStream(images))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
        public static int GetWeeksInYear(int year)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(year, 12, 31);
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                dfi.FirstDayOfWeek);
        }

    }
}
