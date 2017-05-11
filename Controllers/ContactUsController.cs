using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ErieHack_TeamEdgwater.Models;

namespace ErieHack_TeamEdgwater.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        public async Task<ActionResult> Index(ContactEmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();
                    //message.From = new MailAddress("jeffrey.butts@tri-c.edu");
                    message.From = new MailAddress(model.FromEmail);
                    message.To.Add(new MailAddress("edgewater1351@gmail.com"));
                    message.Subject = model.Subject;
                    message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                    message.IsBodyHtml = true;
                    using (var smtp = new SmtpClient())
                    {
                        smtp.UseDefaultCredentials = true;
                        var credential = new NetworkCredential
                        {
                            UserName = "edgewater1351",
                            Password = "asdf1234~"
                        };
                        smtp.Credentials = credential;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(message);
                        ModelState.Clear();
                        return RedirectToAction("Sent");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}