using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using bank_acct.Models;
namespace bank_acct.Models
{
    public class IndexWrapper
    {
        public User UserFormModel {get; set;}
        public List<User> UserTableModel {get; set;}

        public Transaction TransactionFormModel {get; set;}

        public List<Transaction> TransactionsTableModel {get;set;}

    }
}