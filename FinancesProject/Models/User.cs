using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinancesProject.Models
{
    public class User
    {
        public int ID { get; set; }

        [Index(IsUnique=true)]
        [StringLength(100)]
        public string Name { get; set; }
        public string Password { get; set; }

        public virtual ICollection<FinanceMovimentation> Movimentations { get; set; }
    }
}