using FinancesProject.Models;
using FinancesProject.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancesProject.DAL
{
    public class FinancesManagerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FinancesManagerContext>
    {
        protected override void Seed(FinancesManagerContext context)
        {
            context.Users.Add(new User() { 
                Name = "admin",
                Password = PasswordUtil.HashPassword("123456")
            });
            context.SaveChanges();

            User user = context.Users.First(u => u.Name == "admin");
            List<FinanceMovimentation> movimentations = new List<FinanceMovimentation>() { 
                new FinanceMovimentation(){ Type = EMovimentationType.Credit, Value = 350 },
                new FinanceMovimentation(){ Type = EMovimentationType.Debit, Value = 150 }
            };
            user.Movimentations = movimentations;
            context.SaveChanges();
        }
    }
}