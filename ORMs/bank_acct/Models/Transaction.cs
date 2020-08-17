using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //for [NotMapped]
namespace bank_acct.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId {get; set;}

        [Required]
        public int Amount {get; set;}
        public int UserId {get; set;}

        public User UserAccount {get; set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }

}