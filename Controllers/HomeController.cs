using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;

namespace Delete.Controllers
{
    public class HomeController : Controller
    {
        private ITrustRepository _repo;

        public HomeController(ITrustRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult HomeView(string location, string trustType)
        {
            var tes = User.Identity.GetUserId();
            ViewBag.Title = User.Identity.GetUserName();
            IQueryable<Trust> result = _repo.GetAllTrust();

            if (location != null)
            {
                result = result.Where(x => x.Location == location);
            }
            if (trustType != null)
            {
                TrustType _trustType;
                Enum.TryParse(trustType, out _trustType);

                if (_trustType != TrustType.All)
                    result = result.Where(x => x.HomeType == _trustType);
            }
            var events = _repo.GetEventByTrustId(3);

            return View(result.ToList());
        }
        [Authorize]
        public ActionResult TrustView()
        {
            int trustId = _repo.GetLinkedTrustIDWithUserId(User.Identity.GetUserId());

            if (trustId != 0)
            {
                Trust result = _repo.GetTrustByTrustId(trustId);
                result.Events = _repo.GetEventByTrustId(trustId).ToList();
                result.Reviews = _repo.GetReviewsByTrustId(trustId).ToList();


                return View(result);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TrustView(Trust model)
        {
            _repo.AddTrust(model);
            if (_repo.Save())
            {
                _repo.LinkTrustIDWithUserId(User.Identity.GetUserId(), model.Id, "");
                _repo.Save();
                return View(model);
            }
            
            return View();
        }

        public ActionResult TrustPublicView(string trustName)
        {
            IQueryable<Trust> result = _repo.GetAllTrust();
            if (trustName != null)
            {
                result = result.Where(x => x.UserName == trustName);
            }

            return View(result.First());
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