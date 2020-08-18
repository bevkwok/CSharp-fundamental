using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Products_n_Categories.Models;
namespace Products_n_Categories.Models
{
    public class indexWrapper
    {
        public Product oneProduct {get; set;}
        public List<Product> ProductsList {get; set;}

        public Category oneCategory {get; set;}
        public List<Category> CategoryList {get; set;}

        public Association oneAssociation {get; set;}

        public List<Association> AssociationsList {get; set;}
    }
}