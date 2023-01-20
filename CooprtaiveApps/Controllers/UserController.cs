using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using CooprtaiveApps.Models;

namespace CooprtaiveApps.Controllers
{
    public class UserController : Controller
    {
        ICooperativeRepository CooperativeRepository;

        public UserController(ICooperativeRepository Tthrift)
        {
            CooperativeRepository = Tthrift;
        }
        public ActionResult Index()
        {
           


            var List = CooperativeRepository.Users;

            return View(List);
        }


        // GET: UserController/Create
        public ActionResult Create()
        {
            //ViewBag.User = User();
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User app)
        {
            try
            {


                app.Password = GetMD5(app.Password);
                app.Created = DateTime.Now;
                app.Updated = DateTime.Now;

                CooperativeRepository.AddUser(app);
                CooperativeRepository.Save();
                ViewBag.Status = "User Created successfully";
                // return View();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return View();
            }
        }
        //public List<SelectListItem> User()
        //{
        //    var user = new List<SelectListItem>();
        //    var items = HostelRepository.Users.ToList();
        //    foreach (var t in items)
        //    {
        //        user.Add(new SelectListItem { Text = t.EmailAddress, Value = t.UserId.ToString() });
        //    }
        //    return user;
        //}





       

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                //lower  
                byte2String += targetData[i].ToString("x2");
                //upper  
                //byte2String += targetData[i].ToString("X2");  
            }
            return byte2String;
        }

    }
}
