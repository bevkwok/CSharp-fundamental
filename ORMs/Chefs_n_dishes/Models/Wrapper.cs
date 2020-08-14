using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Chefs_n_dishes.Models;
namespace Chefs_n_dishes.Models
{
    public class Wrapper
    {
        public Chef ChefFromModel {get; set;}

        public List<Chef> ChefTableModel {get; set;}

        public Dish DishFromModel {get; set;}

        public List<Dish> DishTableModel {get; set;}

    }
}