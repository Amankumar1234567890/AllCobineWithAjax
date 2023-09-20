using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllCobineWithAjax.Models
{
    public class Movie
    {  
        [Key]
        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public int MovieBudget { get; set; }
    }
}
