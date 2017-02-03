using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Repository;
using Domain.Repository.Interfaces;

namespace OrangeTask01.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProcedureRepository _procedureRepository = new ProcedureRepository();

        public ActionResult Index()
        {
            
            var procedures = _procedureRepository.GetAll();
            return View(procedures);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}