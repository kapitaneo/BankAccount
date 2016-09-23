using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankAccount.Models;
using Newtonsoft.Json;

namespace BankAccount.Controllers
{
    public class HomeController : Controller
    {
        private AccountContext db;

        public HomeController()
        {
            db = new AccountContext();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Enter()
        {
            if(Session["user"]==null) return View("Index");

            return View();
        }
        // Post: Home
        [HttpPost]
        public ViewResult Enter([Bind(Include = "Email,Password")] Account acc)
        {
            if (ModelState.IsValid)
            {
                Account accvalid = db.Accounts.Where(x => x.Email == acc.Email & x.Password == acc.Password).FirstOrDefault();
                if (accvalid != null)
                {
                    if (accvalid.Role == "user")
                    {
                        Session["User"] = accvalid;
                        return View("Enter");
                    }
                    else
                    {
                        Session["User"] = accvalid;
                        return View("AdminAcc");
                    }
                }
                else
                    return View("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Regist()
        {
            return View();
        }
        // Post: Account
        [HttpPost]
        public ViewResult Regist(string Email, string Password, string PasswordConfirm)
        {
            if (Password == PasswordConfirm)
            {
                Account _newacc = new Account();
                _newacc.Email = Email;
                _newacc.Password = Password;
                _newacc.Role = "user";
                _newacc.DateofRegistration = DateTime.Now;
                db.Accounts.Add(_newacc);
                db.SaveChanges();

                Session["User"] = _newacc;

                return View("Enter");
            }
            ViewBag.Massage = "Пароли не совпадают";
            return View("~/Views/Home/Regist.cshtml");
        }

        public ActionResult Exit()
        {
            Session.Abandon();
            return View("Index");
        }

        public string GetData()
        {
            /*            List<Accountfortable> Fortable = new List<Accountfortable>();
                        foreach (Account acc in db.Accounts)
                        {
                            Accountfortable accft = new Accountfortable();
                            accft.Email = acc.Email;
                            accft.Balance = acc.Balance;
                            accft.DateofRegistration = acc.DateofRegistration;
                            Fortable.Add(accft);
                        }
                   string data = JsonConvert.SerializeObject(Fortable);
            */
            var data = db.Accounts.Where(t =>t.Role=="user").Select(t=> new { Email=t.Email, Balance=t.Balance, DateofRegistration=t.DateofRegistration});
            return JsonConvert.SerializeObject(data);
        }

    }
}