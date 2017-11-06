using Kamban.API.Trust;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kamban.API.Controllers
{
    public class HomeController : Controller
    {
        ITrustRepository _repo;
        public HomeController()
        {
            _repo = new TrustRepository(new TrustContext());
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var trusts = _repo.GetAllTrusts();
            return View();
        }
    }
}
