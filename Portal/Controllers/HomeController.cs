using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Portal.Data;
using Portal.Models;
using Portal.Models.ReliefViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DisasterReliefContext db;
        public HomeController(ILogger<HomeController> logger, DisasterReliefContext disasterReliefContext)
        {
            _logger = logger;
            db = disasterReliefContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            /*
             * The LINQ statement groups the student entities 
             * by enrollment date, calculates the number of entities 
             * in each group, and stores the results in a 
             * collection of EnrollmentDateGroup view model objects.
             */
            IQueryable<DonationGroup> data =
                from good in db.Goods
                group good by good.DonationDate into
                dateGroup
                select new DonationGroup()
                {
                    DonationDate = dateGroup.Key,
                    GoodsCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
