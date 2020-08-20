using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;
namespace WeddingPlanner.Models
{
    public class JoinWrapper 
    {
    public Wedding OneWedding { get; set; }
    public Guest OneGuest {get; set;}
    }
}