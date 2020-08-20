using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;
namespace WeddingPlanner.Models
{
    public class DashWrapper 
    {
    public User WedUser { get; set; }
    public List<Wedding> WeddingList {get; set;}

    public Guest OneGuest { get; set; }
    }
}