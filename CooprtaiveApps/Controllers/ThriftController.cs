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
    public class ThriftController : Controller
    {
        ICooperativeRepository CooperativeRepository;

        public ThriftController(ICooperativeRepository Tthrift)
        {
            CooperativeRepository = Tthrift;
        }
        public ActionResult Index()
        {



            var List = CooperativeRepository.Thrifts;

            return View(List);
        }


        // GET: ThriftController/Create
        public ActionResult Create()
        {
            //ViewBag.User = User();
            return View();
        }

        // POST: ThriftController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Thrift app)
        {
            try
            {


               
                app.Created = DateTime.Now;
                app.Updated = DateTime.Now;

                CooperativeRepository.AddThrift(app);
                CooperativeRepository.Save();
                ViewBag.Status = "Thrift Created successfully";
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







      
    }
}
