using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooprtaiveApps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace CooperativeApplication.Controllers
{
    public class RoleController : Controller
    {
        ICooperativeRepository CooperativeRepository;

        public RoleController(ICooperativeRepository Tthrift)
        {
            CooperativeRepository = Tthrift;
        }
        public ActionResult Index()
        {

            // TempData["status"] = TempData["status"];
            var List = CooperativeRepository.Roles;

            return View(List);
        }


        // GET: RoleController/Create
        public ActionResult Create()
        {
            // ViewBag.College = Role();
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role app)
        {
            try
            {

                

                app.Created = DateTime.Now;
                app.Updated = DateTime.Now;

                CooperativeRepository.AddRole(app);
                CooperativeRepository.Save();
                TempData["status"] = "Role Created successfully";
                // return View();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return View();
            }
        }



    }
}
