using FinancesProject.Util;
using FinancesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinancesProject.DAL;

namespace FinancesProject.Controllers
{
    public class FinancesController : Controller
    {
        //
        // GET: /Finances/

        public ActionResult Index()
        {
            User currentUser = (User)Session[Constants.CurrentUser];
            using (var context = new FinancesManagerContext()) {
                ViewBag.Movimentations = context.Movimentations.Where(m => m.UserId == currentUser.ID).ToList();
            }
            return View();
        }
    }
}
