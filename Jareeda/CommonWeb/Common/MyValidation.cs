using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
namespace CommonWeb.Common
{
    /// <summary>
    /// Summary description for MyValidation
    /// </summary>
    public class MyValidation
    {
        public MyValidation()
        {
            //
            // TODO: Add constructor logic here
            //       
        }

        public static bool isSameStr(string val1, string val2)
        {
            if (val1 != val2)
                return false;
            return true;
        }

        public static bool isUserName(string val)
        {
            if (val != string.Empty && val.Length > 2)
                return true;
            return false;
        }

        public static bool isPassword(string value)
        {
            if (value == string.Empty || value.Length < 2)
                return false;
            return true;
        }

        public static bool isNotEmpty(string value)
        {
            if (value == string.Empty)
                return false;
            return true;
        }


        public static bool isMoney(string value)
        {
            return true;
        }

        // is valid term (between 1 and 10)
        public static bool isTerm(string p)
        {
            try
            {
                if (isInteger(p))
                {
                    int tmp = Int32.Parse(p);
                    if (tmp >= 1 && tmp <= 10)
                        return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }


        // is valid GPA (between 0.0 and 4.0 float number with 3 numbers after the point)
        public static bool isGPA(string p)
        {
            try
            {
                if (isFloat(p))
                {
                    float tmp = float.Parse(p);
                    if (tmp >= 0.0f && tmp <= 4.0f)
                        return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        // is valid float value
        public static bool isFloat(string value)
        {
            try
            {
                float tmp = float.Parse(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        // is valid integer value
        public static bool isInteger(string value)
        {
            try
            {
                int tmp = Int32.Parse(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        // compare if period between 2 dates are valid, and also start is less than end.
        public static bool isPeriod(DateTime start, DateTime end)
        {
            return isPeriod(start, end, 1);
        }
        public static bool isPeriod(DateTime start, DateTime end, int days)
        {
            try
            {
                TimeSpan span = end - start;
                int tmp = (int)Math.Ceiling(span.TotalDays);
                if (tmp >= days)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }

        public static bool isEmail(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                Regex rx = new Regex("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
                Match m = rx.Match(val);
                if (m.Success)
                    return true;
            }
            return false;
        }

        private static int CalculateAge(DateTime birthDate)
        {
            // cache the current time
            DateTime now = DateTime.Today; // today is fine, don't need the timestamp from now
            // get the difference in years
            int years = now.Year - birthDate.Year;
            // subtract another year if we're before the
            // birth day in the current year
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                --years;

            return years;
        }

        // is graduate date (must be less than now)
        public static bool isGraduateDate(string p)
        {
            try
            {
                DateTime tmp = DateTime.Parse(p);
                // graduate date must be in past
                if (tmp.Ticks < DateTime.Now.Ticks)
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        // is birth date
        public static bool IsBirthDate(string bdate)
        {
            try
            {
                DateTime tmp = DateTime.Parse(bdate);
                int tmp2 = CalculateAge(tmp);
                // age should be between 15 and 65
                if (tmp2 < 65 && tmp2 > 15)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }


        public static bool isDueDays(int p)
        {
            return true;
            try
            {
                if (p > 0 && p <= 20)
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static bool isEvalThreshold(int p)
        {
            try
            {
                if (p >= 0 && p <= 20)
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static bool isIntegerInRange(int p, int p1, int p2)
        {
            if (p >= p1 && p <= p2)
                return true;
            return false;

        }
    }
}