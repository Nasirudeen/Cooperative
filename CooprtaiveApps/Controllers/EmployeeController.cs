using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooprtaiveApps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace CooperativeApplication.Controllers
{
    public class EmployeeController : Controller
    {
        ICooperativeRepository CooperativeRepository;

        public EmployeeController(ICooperativeRepository Tthrift)
        {
            CooperativeRepository = Tthrift;
        }
        public ActionResult Index()
        {

            // TempData["status"] = TempData["status"];
            var List = CooperativeRepository.Employees;

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
        public ActionResult Create(Employee app)
        {
            try
            {



                app.Created = DateTime.Now;
                app.Updated = DateTime.Now;

                CooperativeRepository.AddEmployee(app);
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
