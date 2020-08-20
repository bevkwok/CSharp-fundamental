using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;
namespace WeddingPlanner.Models
{
    public class WedPageWrapper 
    {
    public Wedding OneWedding { get; set; }
    public List<User> Users {get; set;}
    }
}