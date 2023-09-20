using AllCobineWithAjax.ContextAndRepo;
using AllCobineWithAjax.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllCobineWithAjax.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieRepo _mr;
        public MovieController(MovieRepo mr)
        {
            _mr = mr;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public JsonResult Display()
        {
            var data = _mr.Display();
            return Json(data);
        }
        [HttpPost]
        public IActionResult InsertData(Movie mm)
        {
            _mr.InsertData(mm);
            return Json("Success");
        }
        public IActionResult Delete(int movieId)
        {
            _mr.Delete(movieId);
            return Json("Success");
        }

        public IActionResult GetById(int movieId)
        {
            var data = _mr.Display().Find(x => x.MovieId == movieId);
            return Json(data);
        }
        [HttpPost]

        public IActionResult Edit(Movie mm)
        {
            _mr.Edit(mm);
            return Json("Success");
        }
    }
}
