using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Models;
namespace WeddingPlanner.Models
{
    public class IndexWrapper 
    {
    public User RegUser { get; set; }
    public LogUser LoginUser { get; set; }
    }
}