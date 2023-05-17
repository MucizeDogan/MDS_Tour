using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using MDS_Tour.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace MDS_Tour.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail); // Kullanıcının mail adresini bul.
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);  // Kullanıcıya yollanacak olan unique(eşsiz) link yollanmak için
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);     //Kullancının gelen url e tıkladığında (ResetPassword) sayfasına (PasswordChange) controllerına gidecek. Neyle beraber? Kullaını id si ve token la

            MimeMessage mimeMessage = new MimeMessage();

            //Gönderici bilgileri
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "tourmds@gmail.com"); // Maili gönderen kişinin adı ve mail adresini parametre olarak aldık
            mimeMessage.From.Add(mailboxAddressFrom); //  Mailin nereden geldiğini kullanıcıya bildirmiş olduk.

            //Alıcı bilgileri
            MailboxAddress mailboxAddressTo = new MailboxAddress("User",forgetPasswordViewModel.Mail);    // Burada da kime geldiği (ALıcı) bilgisini veriyoruz.
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Password Change Request";

            SmtpClient smtpClient = new SmtpClient();     // Simple Mail Transfer Protokol Sunucusu
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("tourmds@gmail.com", "gsxxmalhzfteojzt");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid,string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];
            if(userid == null || token == null)
            {
                //HATAAAA
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user,token.ToString(),resetPasswordViewModel.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
