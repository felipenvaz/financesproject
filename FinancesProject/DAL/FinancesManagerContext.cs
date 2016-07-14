using FinancesProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinancesProject.DAL
{
    
        public class FinancesManagerContext : DbContext
        {

            public FinancesManagerContext()
                : base("DefaultConnection")
            {
            }
            public DbSet<User> Users { get; set; }
            public DbSet<FinanceMovimentation> Movimentations { get; set; }
        }
}