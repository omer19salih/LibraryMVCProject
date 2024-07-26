using MVC_Library_Otomasyon.DAL;
using MVC_Library_Otomasyon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryV2.Controllers
{
    [AllowAnonymous]
    public class UsersController : Controller
    {
        // GET: Users
        Librarycontext context= new Librarycontext();
        UsersDAL UsersDal=  new UsersDAL();
        UserRolesDAL UserRolesDAL= new UserRolesDAL();
        
        
        
        public ActionResult Index()
        {
            var model = UsersDal.GetAll(context);
            return View(model);
        }




        public ActionResult Ekle ()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Ekle (Users Entity)
        {
            if (!ModelState.IsValid)
            {
                return View(Entity);
            }
           UsersDal.InsertorUpdate(context, Entity);
            UsersDal.save(context);
            return RedirectToAction("Index");

        }

        public ActionResult Edit (int? id )
        {
            if (id==null)
            {
                return HttpNotFound( "id degeri girilmedi");
            }
            var model = UsersDal.GetById(context, id);
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Users Entity)
        {
            if (!ModelState.IsValid)
            {
                return View(Entity);
            }
            UsersDal.InsertorUpdate(context, Entity);
            UsersDal.save(context);
            return RedirectToAction("Index");

        }

        public ActionResult Delete (int id )
        {
            UsersDal.Delete(context,x =>x.Id == id);
            UsersDal.save(context);
            return RedirectToAction("Index");


        }




        



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users entity)
        {

            var model = UsersDal.GetByFilter(context, x => x.Email == entity.Email && x.Password == entity.Password);

            if (model != null) 
            {
                FormsAuthentication.SetAuthCookie(entity.Email, true);
                return RedirectToAction("Index", "BookGenres");
            }

            ViewBag.error = " Kullanıcı Adı Ve Şifre Yanlış";
            return View();
        }

        public ActionResult Register() 
        {

            return View();
       
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(Users entiy,string passwordagain,bool acceptance)
        {
            if (!ModelState.IsValid) //model dogrulanmazsa
            {
                return View(entiy);
            }

            else//model dogrulanırsa 
            {
                if (entiy.Password != passwordagain) // sifreler uyuşmassa
                {
                    ViewBag.PasswordError = "Şifreler Uyuşmuyor";
                    return View();
                }
                else //sifreler uyusursa 
                {
                    if (!acceptance) // sartlar kabul edilmemisle 
                    {
                        ViewBag.AcceptanceError = "Lütfen şartları kabul ettiginizi onaylayın! ";
                        return View ();

                    }
                    else //sartlar kabul edilmisse 
                    {   
                        entiy.RegistrationDate = DateTime.Now;
                        UsersDal.InsertorUpdate(context,entiy);
                        UsersDal.save(context);
                        return RedirectToAction("Login");
                    }
                }
            }
            
        }
        
        public ActionResult ForgotPassword()
        {
            return View();
        }


        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult ForgotPassword(Users entity)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.Email))
                {
                    ViewBag.hata = "Lütfen e-posta adresinizi giriniz.";
                    return View();
                }

                var model = UsersDal.GetByFilter(context, x => x.Email == entity.Email);
                if (model != null)
                {
                    // Generate a new random password
                    string newPassword = Guid.NewGuid().ToString().Substring(0, 8);
                    model.Password = newPassword;
                    UsersDal.save(context);

                    // Email setup
                    SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("salihomeruyar@gmail.com", "Şifre sıfırlama");
                    mail.To.Add(model.Email);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Şifre Değiştirme İsteği";
                    mail.Body = $"Merhaba {model.FullName},<br/> Kullanıcı Adınız: {model.Username}<br/> Yeni Şifreniz: {newPassword}";

                    // Securely fetch SMTP credentials
                    string smtpUser = "salihomeruyar@gmail.com";
                    string smtpPass = "Sss2005km"; // Fetch from secure storage
                    client.Credentials = new NetworkCredential(smtpUser, smtpPass);
                    client.Send(mail);

                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.hata = "Böyle bir e-mail adresi bulunamadı.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here)
                ViewBag.hata = "Şifre sıfırlama sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyiniz." + ex.Message;
                return View();
            }
        }

    }
}