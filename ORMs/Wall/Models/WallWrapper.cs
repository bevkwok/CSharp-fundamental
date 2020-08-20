using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wall.Models;
namespace Wall.Models
{
    public class WallWrapper
    {
        public User WallUser { get; set; }
        public List<Message> MessagesList {get; set;}
    }
}