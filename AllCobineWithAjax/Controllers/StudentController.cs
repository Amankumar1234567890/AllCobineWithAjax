using AllCobineWithAjax.ContextAndRepo;
using AllCobineWithAjax.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllCobineWithAjax.Controllers
{
    public class StudentController : Controller
    {
        private readonly DapperRepo _dr;
        public StudentController(DapperRepo dr)
        {
            _dr = dr;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult DisplayData()
        {
            var data = _dr.DisplayData();
            return Json(data);
        }
        [HttpPost]
        public IActionResult InsertData(Student stu)
        {
            _dr.InsertData(stu);
            return Json("Success");
        }
        public IActionResult Delete(int studentId)
        {
            _dr.Delete(studentId);
            return Json("Success");
        }

        public IActionResult GetById(int studentId)
        {
            var data = _dr.DisplayData().Find(x=>x.StudentId==studentId);
            return Json(data);
        }
        [HttpPost]
        public IActionResult UpdateData(Student stu)
        {
            _dr.UpdateData(stu);
            return Json("success");
        }
    }
}
