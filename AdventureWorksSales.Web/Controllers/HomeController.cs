
using AdventureWorksSales.Core.Abstract;
using AdventureWorksSales.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
    public class HomeController : Controller
    {
        ISalesOrderRepository _salesOrderRepo;
        public HomeController(ISalesOrderRepository salesOrderRepository)
        {
            _salesOrderRepo = salesOrderRepository;
        }
        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                TotalOrders = _salesOrderRepo.Query().Count(),
                HighestLineTotal = decimal.Round(_salesOrderRepo.GetAllLineTotal().Max(), 3, MidpointRounding.AwayFromZero),
                FrontBrakeSalesTotal =_salesOrderRepo.GetAllProductSales(948).Count()
            };

            return View(model);
        }

    }
}