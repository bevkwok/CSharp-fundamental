using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;
namespace WeddingPlanner.Models
{
    public class PlanWrapper 
    {
    public User WedUser { get; set; }
    public Wedding OneWedding {get; set;}
    }
}