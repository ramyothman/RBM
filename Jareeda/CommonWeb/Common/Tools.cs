using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Configuration;

namespace CommonWeb.Common
{
    public class Tools
    {
        public static string MenuImagesPath
        {
            get { return ConfigurationManager.AppSettings["MenuItemIconPath"]; }
        }

        public static string HospitalImagesPath
        {
            get { return ConfigurationManager.AppSettings["HospitalImagesPath"]; }
        }
        // get the md5 of a string, used mainly for passwords
        public static string MD5(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, 
            //get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = UnicodeEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }
        public static string GetIPAddress()
        {
            string ipMain = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            string IpForwardedFor = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            string ip = String.Format("{0}-{1}", ipMain, IpForwardedFor);
            return ip;
        }
        public static string extractPageFileName(Page page)
        {
            string fileName = page.Request.Url.ToString();
            fileName = fileName.Remove(0, fileName.LastIndexOf("/") + 1);
            return fileName;
        }

        // with no extension
        public static string extractPageFileNameWithoutExt(string str)
        {
            return System.IO.Path.GetFileNameWithoutExtension(str);
        }
        public static int CalculateAge(DateTime birthDate)
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

        // safe assign to a string from string field inside an object, if exceptions happned, catches it and return default
        public static string safeStr2Str(string s)
        {
            return safeStr2Str(s, string.Empty);
        }
        public static string safeStr2Str(string s, string defValue)
        {
            string tmp;
            try
            {
                tmp = s;
                return tmp;
            }
            catch (Exception)
            {

            }
            return defValue;
        }

        public static int safeInt2Int(int s)
        {
            return safeInt2Int(s, 0);
        }

        public static int safeInt2Int(int s, int defValue)
        {
            int tmp;
            try
            {
                tmp = s;
                return tmp;
            }
            catch (Exception) { };

            return defValue;
        }

        public static int daysPast(DateTime old)
        {
            DateTime now = DateTime.Now;
            TimeSpan span = now - old;
            return (int)Math.Ceiling(span.TotalDays);
        }

        // get difference in days between 2 dates
        public static int getDays(DateTime d1, DateTime d2)
        {
            try
            {
                TimeSpan span = d1 - d2;
                return Math.Abs((int)Math.Ceiling(span.TotalDays));
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// gets remaining days, either negative or positive depending on d1 and d2 and whoe's greater
        /// </summary>
        /// <param name="d1">The d1.</param>
        /// <param name="d2">The d2.</param>
        /// <returns></returns>
        public static int getRemainingDays(DateTime d1, DateTime d2)
        {
            try
            {
                TimeSpan span = d2 - d1;
                return (int)Math.Round(span.TotalDays);
            }
            catch
            {
            }
            return 0;
        }

        // replace ' with ''
        public static string safeSqlLiteral(string inputSQL)
        {
            return inputSQL.Replace("'", "''");
        }

        // remove html tags
        public static string safeHtmlLiteral(string inputTXT)
        {
            return HttpUtility.HtmlEncode(inputTXT);
        }

        // safe convert a string to integer
        public static int Str2Int(string str)
        {
            return Str2Int(str, 0);
        }
        public static int Str2Int(string str, int defaultvalue)
        {
            try
            {
                return Int32.Parse(str);
            }
            catch
            {
                return defaultvalue;
            }
        }

        // get a link to the website
        public static string getWebsiteUrl(Page p)
        {
            string path = p.Request.Url.AbsolutePath.Replace(p.Request.ApplicationPath + "/", string.Empty);

            //path = p.Request.Url.AbsolutePath.Replace(System.Configuration.ConfigurationManager.AppSettings["URLHome"] + "/", string.Empty);
            //path = p.Request.Url.AbsolutePath.Replace(System.Configuration.ConfigurationManager.AppSettings["URLHome"], string.Empty);
            //path = p.Request.Url.AbsolutePath.Replace(System.Configuration.ConfigurationManager.AppSettings["URLHomeAlias2"] + "/", string.Empty);
            //path = p.Request.Url.AbsolutePath.Replace(System.Configuration.ConfigurationManager.AppSettings["URLHomeAlias2"], string.Empty);
            if (path.StartsWith("/"))
                path = path.Remove(0, 1);
            //System.IO.File.WriteAllText(p.MapPath("~/ContentData/") + "test.txt", path + "\n" + p.Request.Url.AbsolutePath + "\n" + p.Request.ApplicationPath);
            return path;
        }

        public static ImageFormat GetFormat(string MimeType)
        {

            ImageFormat result = ImageFormat.Jpeg;
            switch (MimeType)
            {
                case "image/gif":
                    result = ImageFormat.Gif;
                    break;
                case "image/png":
                    result = ImageFormat.Png;
                    break;
                case "image/bmp":
                    result = ImageFormat.Bmp;
                    break;
                case "image/tiff":
                    result = ImageFormat.Tiff;
                    break;
                case "image/x-icon":
                    result = ImageFormat.Icon;
                    break;
                default:
                    result = ImageFormat.Jpeg;
                    break;
            }
            return result;
        }
        //Create thumb
        public static byte[] CreateThumb(byte[] imageBytes, int thumbnailSize, bool sizeIsHeight)
        {
            try
            {

                if (imageBytes == null)
                    return null;
                MemoryStream stream = new MemoryStream(imageBytes);
                System.Drawing.Bitmap tempImage = new Bitmap(stream);
                int dw = tempImage.Width; ;
                int dh = tempImage.Height;
                int compareSize = dw;
                if (dw > thumbnailSize || dh > thumbnailSize)
                {
                    int tw = thumbnailSize;
                    int th = thumbnailSize;
                    double zw = (tw / (double)dw);
                    double zh = (th / (double)dh);

                    double z = sizeIsHeight ? zh : zw;
                    dw = (int)(dw * z);
                    dh = (int)(dh * z);
                }



                Bitmap m_Image = new Bitmap(dw, dh);
                Graphics g = Graphics.FromImage(m_Image);
                g.InterpolationMode = InterpolationMode.Default;
                g.DrawImage(tempImage, 0, 0, dw, dh);
                g.Dispose();
                tempImage.Dispose();
                stream = new MemoryStream();
                m_Image.Save(stream, GetFormat("image/png"));
                return stream.GetBuffer();
            }
            catch 
            {

            }
            return null;
        }

        #region File Header Content Check
        public static bool IsImage(byte[] imageBytes)
        {
            bool result = false;
            // DICTIONARY OF ALL IMAGE FILE HEADER
            Dictionary<string, byte[]> imageHeader = new Dictionary<string, byte[]>();
            imageHeader.Add("JPG", new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 });
            imageHeader.Add("JPEG", new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 });
            //imageHeader.Add("JPE", new byte[] { 0xFF, 0xD8, 0xFF, 0xFF });
            imageHeader.Add("PNG", new byte[] { 0x89, 0x50, 0x4E, 0x47 });
            imageHeader.Add("TIF", new byte[] { 0x49, 0x49, 0x2A, 0x00 });
            imageHeader.Add("TIFF", new byte[] { 0x49, 0x49, 0x2A, 0x00 });
            imageHeader.Add("GIF", new byte[] { 0x47, 0x49, 0x46, 0x38 });
            imageHeader.Add("BMP", new byte[] { 0x42, 0x4D });


            byte[] header;
            
            // GET FILE EXTENSION
            //string fileExt;
            //string fileExt = GetExtension(FileName);

            // CUSTOM VALIDATION GOES HERE BASED ON FILE EXTENSION IF ANY


            foreach (string key in imageHeader.Keys)
            {
                byte[] tmp = imageHeader[key];
                header = new byte[tmp.Length];

                for (int j = 0; j < header.Length; j++)
                {
                    header[j] = imageBytes[j];
                }
                if (CompareArray(tmp, header))
                {
                    result = true;
                    break;
                }
            }
            
               
            return result;
        }

        public static byte[] Crop(string Img, int Width, int Height, int X, int Y)
        {
            try
            {
                using (Image OriginalImage = Image.FromFile(Img))
                {
                    using (Bitmap bmp = new Bitmap(Width, Height))
                    {
                        bmp.SetResolution(OriginalImage.HorizontalResolution, OriginalImage.VerticalResolution);
                        using (Graphics Graphic = Graphics.FromImage(bmp))
                        {
                            Graphic.SmoothingMode = SmoothingMode.AntiAlias;
                            Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            Graphic.DrawImage(OriginalImage, new Rectangle(0, 0, Width, Height), X, Y, Width, Height, GraphicsUnit.Pixel);
                            MemoryStream ms = new MemoryStream();
                            bmp.Save(ms, OriginalImage.RawFormat);
                            return ms.GetBuffer();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }

        public static string GetExtension(string FileName)
        {
            string result = "";
            result = FileName.Substring(FileName.LastIndexOf('.') + 1).ToUpper();
            return result;
        }
        private static bool CompareArray(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Check if the document passed is .doc / .docx or Rtf
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <returns></returns>
        public static bool IsWordDocument(byte[] fileBytes,string contentType)
        {
            bool result = false;
            //doc files start like this value
            int j = 0;
            byte[] chkByteDoc = { 208, 207, 17, 224 }; //2003 MS word starting bytes (.doc format)
            byte[] chkByteDocx = {80,75,3,4,20}; //2007 MS word starting bytes (.docx format)

            #region Doc Check
            if(!result)
            for (Int32 i = 0; i <= 2; i++)
            {
                if (fileBytes[i] == chkByteDoc[i])
                {
                    j = j + 1;
                    if (j == 3)
                    {
                        result = true;
                    }
                }
            }
            #endregion

            #region Docx Check
            j = 0;
            if(!result)
            for (Int32 i = 0; i <= 2; i++)
            {
                if (fileBytes[i] == chkByteDocx[i])
                {
                    j = j + 1;
                    if (j == 3)
                    {
                        result = true;
                    }
                }
            }
            #endregion

            #region Checking ContentType
            if (!result)
            {
                List<String> wordMimeTypes = new List<String>();
                wordMimeTypes.Add("application/msword");
                wordMimeTypes.Add("application/doc");
                wordMimeTypes.Add("appl/text");
                wordMimeTypes.Add("application/vnd.msword");
                wordMimeTypes.Add("application/vnd.ms-word");
                wordMimeTypes.Add("application/winword");
                wordMimeTypes.Add("application/word");
                wordMimeTypes.Add("application/x-msw6");
                wordMimeTypes.Add("application/x-msword");

                if (wordMimeTypes.Contains(contentType))
                {
                    result = true;
                }
            }
            #endregion

            return result;
        }

        public static bool IsDocument(byte[] fileBytes, string contentType)
        {
            bool result = false;
            result = IsWordDocument(fileBytes, contentType);
            if (!result)
                result = IsPDFDocument(fileBytes);
            return result;
        }

        public static bool IsPDFDocument(byte[] fileBytes)
        {
            bool result = false;
            if (fileBytes[0] == 0x25 && fileBytes[1] == 0x50
            && fileBytes[2] == 0x44 && fileBytes[3] == 0x46)
                result = true;
            return result;
        }
        #endregion




    }
}