﻿using MailKit.Net.Smtp;
using MDS_Tour.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class EMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            //Gönderici bilgileri
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "tourmds@gmail.com"); // Maili gönderen kişinin adı ve mail adresini parametre olarak aldık
            mimeMessage.From.Add(mailboxAddressFrom); //  Mailin nereden geldiğini kullanıcıya bildirmiş olduk.
            
            //Alıcı bilgileri
            MailboxAddress mailboxAddressTo = new MailboxAddress("User",mailRequest.RecipientofMail);    // Burada da kime geldiği (ALıcı) bilgisini veriyoruz.
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder=new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Content;
            mimeMessage.Body=bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient smtpClient = new SmtpClient();     // Simple Mail Transfer Protokol Sunucusu
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("tourmds@gmail.com", "azjpfkzpozqvhlrf");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return View();
        }
    }
}
