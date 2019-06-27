using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace LeafSolutionsbnm.Models
{
    public static class Gmail
    {
        public static void SendMail(string body)
        {
            var fromAddress = new MailAddress("enteremail", "Bilecik Gözde Kız Apart & Pansiyon Geribildirim");
            var toAddress = new MailAddress("enteremail");
            const string subject = "Bilecik Gözde Kız Apart & Pansiyon Geribildirim";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "enteremailpassword")
                //credentials kısmı e-posta adresinin şifresi
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}