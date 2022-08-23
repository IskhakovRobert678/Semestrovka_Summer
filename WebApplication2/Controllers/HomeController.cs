using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHtmlLocalizer<HomeController> _localizer;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHtmlLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            //var test = _localizer["HelloWorld"];
            //ViewData["HelloWorld"] = test;
            return View();
        }

        public IActionResult Subscription()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(SendMailDto sendMailDto)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("carmelo17@ethereal.email");
                mail.To.Add("carmelo17@ethereal.email");

                mail.Subject = sendMailDto.Subject;

                mail.IsBodyHtml = true;

                string content = "Name : " + sendMailDto.Name;
                content += "<br/> Message : " + sendMailDto.Message;

                mail.Body = content;


                SmtpClient smtpClient = new SmtpClient("smtp.ethereal.email");

                NetworkCredential networkCredential = new NetworkCredential("carmelo17@ethereal.email", "weYkCsb4jHUMrSxx61");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 25;
                smtpClient.EnableSsl = false;
                smtpClient.Send(mail);
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }

            return Redirect("~/Home");
        }

        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}