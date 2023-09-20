using AllCobineWithAjax.ContextAndRepo;
using AllCobineWithAjax.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllCobineWithAjax.Controllers
{
    public class PizzaController : Controller
    {
        private readonly Repo _repo;
        public PizzaController(Repo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public JsonResult Read()
        {
            var data = _repo.GetData();
            return Json(data);
        }
        [HttpPost]
        public IActionResult AddPizza(Pizza pizza)
        {
            _repo.AddPizza(pizza);
            return Json("Inserted");
        }

        public IActionResult Delete(int pizzaId)
        {
            _repo.Delete(pizzaId);
            return Json("Deleted");
        }
        public IActionResult GetById(int pizzaId)
        {
            var data = _repo.GetById(pizzaId);
            return Json(data);
        }
        [HttpPost]
        public IActionResult Edit(Pizza pizza)
        {
            _repo.Edit(pizza);
            return Json("Updated");
        }
    }
}
