global using System.Linq.Dynamic;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using System.ComponentModel.DataAnnotations;
global using HandMadeEcommece.helper;
global using HandMadeEcommece.Models.Dto;
global using Microsoft.EntityFrameworkCore;
global using System.Net.Mail;
global using PhoneNumbers;
using System.Reflection.Metadata;
using Azure.Core;
using HandMadeEcommece.Models.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Net;



namespace HandMadeEcommece.helper
{
    public class Methods
    {
        public static async Task<byte[]> TransferImage(IFormFile Image)
        {
            if (Image == null || Image.Length == 0)
                return null;
            using (var dataStream = new MemoryStream())
            {
                await Image.CopyToAsync(dataStream);
                return dataStream.ToArray();
            }
        }

        public static Task<bool>IsValidEmail(string email)
        {
            try
            {
                var address =  new MailAddress(email);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
        public static Task<bool>IsValidPhone(string phone, string countryCode = "EG")
        {
            var phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var number = phoneUtil.Parse(phone, countryCode);
                return Task.FromResult(phoneUtil.IsValidNumber(number));
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public static async Task<string> GetImagesFromPath(IFormFile image, string category,  HttpContext httpContext, IWebHostEnvironment webHostEnvironment)
        {

            if (image == null || image.Length == 0) { return "No file uploaded."; }
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath,"Images", category);
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
           
            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            string url = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/Images/{category}/{uniqueFileName}";
            return url;
        }


        public static async Task Notifications(string ToAddress, string Person, string Subject, string Body)
        {
            var fromAddress = new MailAddress("Your email", "Harfaty");
            var toAddress = new MailAddress(ToAddress, Person);
            string fromPassword = "AppPassword";
            string subject = Subject;
            string body = Body;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", // e.g., smtp.gmail.com
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }



    }
}
