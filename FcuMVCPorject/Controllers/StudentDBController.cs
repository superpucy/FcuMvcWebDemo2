using System;
using System.Web.Mvc;
using FcuMVCPorject.Service;
using MvcWebDemo.Models.ViewModel;

namespace FcuMVCPorject.Controllers
{
    public class StudentDBController : Controller
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
        public ActionResult Create(StudentViewModel data)
        {
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

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(studentBaseService.getStudent(id));
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel data)
        {
            if (studentBaseService.updateStudent(data))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Status = false;
                return View(data);
            }
        }

        [HttpGet]
        public ActionResult Detail(Guid id)
        {
            return View(studentBaseService.getStudent(id));
        }


        public ActionResult Delete(Guid id)
        {
            if (studentBaseService.deleteStudent(id))
            {
                ViewBag.Status = true;
            }
            else
            {
                ViewBag.Status = false;
            }
            return RedirectToAction("Index");
        }

    }
}
