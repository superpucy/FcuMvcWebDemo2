using System;
using System.Web.Mvc;
using FcuMVCPorject.Service;
using MvcWebDemo.Models.ViewModel;

namespace FcuMVCPorject.Controllers
{
    public class StudentBaseController : Controller
    {
        private StudentBaseService studentBaseService = new StudentBaseService();

        public ActionResult Index()
        {
            var result = studentBaseService.getStudentList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            StudentViewModel data = new StudentViewModel();
            return View(data);
        }

        [HttpPost]
        public ActionResult Create(string ID, string NAME, string ADDRESS, string EMAIL, string TEL, string MESSAGE )
        {
            StudentViewModel data = new StudentViewModel();
            data.guid = Guid.NewGuid();
            data.ID = ID;
            data.NAME = NAME;
            data.ADDRESS = NAME;
            data.EMAIL = EMAIL;
            data.TEL = TEL;
            data.MESSAGE = MESSAGE;

            if (studentBaseService.addStudent(data))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Status = false;
                return View(data);
            }
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create()
        //{
        //    return View();
        //}
    }
}
