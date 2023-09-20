using AllCobineWithAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllCobineWithAjax.ContextAndRepo
{
    public class Repo
    {
        private readonly Context _context;
        public Repo(Context context)
        {
            _context = context;

        }
        public List<Pizza> GetData()
        {
            var data = _context.PizzaTable.ToList();
            return data;
        }

        public void AddPizza(Pizza pizza)
        {
            _context.PizzaTable.Add(pizza);
            _context.SaveChanges();
        }

        public void Delete(int pizzaId)
        {
            var data = _context.PizzaTable.Find(pizzaId);
            _context.PizzaTable.Remove(data);
            _context.SaveChanges();
        }

        public Pizza GetById(int pizzaId)
        {
            var data = _context.PizzaTable.Find(pizzaId);
            return data;
        }

        public void Edit(Pizza pizza)
        {
            _context.PizzaTable.Update(pizza);
            _context.SaveChanges();
        }
    }
}
