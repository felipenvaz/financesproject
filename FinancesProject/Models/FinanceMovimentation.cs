using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinancesProject.Models
{
    public class FinanceMovimentation
    {
        public int ID { get; set; }
        public EMovimentationType Type { get; set; }
        public decimal Value { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
    public enum EMovimentationType { 
        Credit = 1,
        Debit = 2
    }
}