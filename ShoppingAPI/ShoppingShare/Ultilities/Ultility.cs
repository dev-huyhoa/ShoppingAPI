using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace ShoppingShare.Ultilities
{
    public class Ultility
    {
        private const string CLOUD_NAME = "ddv2idi9d";
        private const string API_KEY = "687389283419199";
        private const string API_SECRET = "BOCNwD1_s-DwP67WIkwNkuURBtE";
        private static Cloudinary cloudinary;
        private static string publicId;
        private static string link;
        public static long FormatDateToInt(DateTime datetime, string type)
        {
            // Type DDMMYYYY - day month year
            // Type YYYYMMDD - year month day
            // Type DDMMYYYYHHMM - day month year hour min
            // Type YYYYMMDDHHMM - year month day hour min
            // Type YYYYMMDDHHMMSS - year month day hour min sec
            // Type DDMMYYYYHHMMSS - day month year hour min sec
            var dateTimeNow = datetime;
            string year = dateTimeNow.Year.ToString();
            string month = dateTimeNow.Month.ToString();
            string day = dateTimeNow.Day.ToString();
            string hour = dateTimeNow.Hour.ToString();
            string mi = dateTimeNow.Minute.ToString();
            string sec = dateTimeNow.Second.ToString();
            try
            {
                if (type == "DDMMYYYY")
                {
                    //29/01/2001 
                    return int.Parse(year + month + day);
                }
                else if (type == "YYYYMMDD")
                {
                    //2001/01/29
                    return int.Parse(year + month + day);
                }
                else if (type == "YYYYMMDDHHMM")
                {
                    ////2001/01/29 23:12
                    return int.Parse(year + month + day + hour + mi);
                }
                else if (type == "DDMMYYYYHHMM")
                {
                    ////29/01/2001 23:12
                    return int.Parse(year + month + day + hour + mi);
                }
                else if (type == "YYYYMMDDHHMMSS")
                {
                    ////2001/01/29 23:12:12
                    return Int64.Parse(year + month + day + hour + mi + sec);
                }
                else
                {
                    ////29/01/2001 23:12:12
                    return Int64.Parse(year + month + day + hour + mi + sec);
                }
            }
            catch (Exception)
            {
                return 1;
            }
        }
        public static string WriteFile(IFormFile file, string type, string idService)
        {
            int orderby = 1;
            var folder = Directory.GetCurrentDirectory() + @"\wwwroot";
            string path = Path.Combine(folder, "UploadsShopping");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string pathType = Path.Combine(path, type);

            if (!Directory.Exists(pathType))
            {
                Directory.CreateDirectory(pathType);
            }

            string pathId = Path.Combine(pathType, idService.ToString());

            if (!Directory.Exists(pathId))
            {
                Directory.CreateDirectory(pathId);
            }
            var date = FormatDateToInt(DateTime.Now, "DDMMYYYY").ToString();

            string pathDate = Path.Combine(pathId, date);
            if (!Directory.Exists(pathDate))
            {
                Directory.CreateDirectory(pathDate);
            }
            //get file extension
            //string[] str = file.FileName.Split('.');
            string fileName = "";
            if (orderby > 0)
            {
                fileName = orderby.ToString() + "_" + FormatDateToInt(DateTime.Now, "DDMMYYYYHHMMSS").ToString() + Path.GetExtension(file.FileName);
            }
            else
            {
                fileName = FormatDateToInt(DateTime.Now, "DDMMYYYYHHMMSS").ToString() + Path.GetExtension(file.FileName);
            }
            string fullpath = Path.Combine(pathDate, fileName);
            string folderPath = "/Uploads/" + type + "/" + idService + "/" + date;
            string serverPath = "/Uploads/" + type + "/" + idService + "/" + date + "/" + fileName;
            if (Directory.Exists(fullpath))
            {
                System.IO.File.Delete(fullpath);

            }
            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            //up lên cloud
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);
            string imagePath = Path.GetFullPath(fullpath);
            return uploadImage(imagePath, folderPath);
        }

        public static string uploadImage(string filePath, string folderPath)
        {
            var uploadParams = new ImageUploadParams()
            {
                Folder = folderPath,
                File = new FileDescription(filePath),
                UseFilename = true
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            publicId = $"lia/Folder/{uploadResult.PublicId}";
            return uploadResult.Uri.ToString();
        }
        public static int SendMail(string email,string subject,string content )
        {
            
            var mailSend = "thaoln20@uef.edu.vn";
            var password = "079302012544";
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(mailSend, password);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(email),
                    Subject = subject,
                    Body = content,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(email);

                client.Send(mailMessage);

            }
            return 0;
        }

        public static string ConvertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
