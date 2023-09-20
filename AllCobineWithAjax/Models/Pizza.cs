using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllCobineWithAjax.Models
{
    public class Pizza
    {   
        [Key]
        public int PizzaId { get; set; }

        public string PizzaName { get; set; }

        public int PizzaPrice { get; set; }
    }
}
