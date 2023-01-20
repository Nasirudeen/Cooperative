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
    public class DepartmentController : Controller
    {
        ICooperativeRepository CooperativeRepository;

        public DepartmentController(ICooperativeRepository Tthrift)
        {
            CooperativeRepository = Tthrift;
        }
        public ActionResult Index()
        {



            var List = CooperativeRepository.Departments;

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
        public ActionResult Create(Department app)
        {



            app.Created = DateTime.Now;
            app.Updated = DateTime.Now;

            CooperativeRepository.AddDepartment(app);
            CooperativeRepository.Save();
            ViewBag.Status = "Department Created successfully";
            // return View();
            return RedirectToAction(nameof(Index));

        }

    }
}