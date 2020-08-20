using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Wall.Models
{
    public class Comment
    {
        [Key]

        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int MessageId { get; set; }

        public User User { get; set; }

        public Message Message {get; set;}
    }
}