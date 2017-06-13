using Delete.Data;
using Delete.Data.Trust;
using Delete.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;

namespace Delete.Controllers
{


    public class HomeController : Controller
    {
        private TrustRepository _repo;
        private ApplicationUserManager _userManager;
        private string _userId;
        private int _trustId;
        private string _inventoryGroupName;

        public object VolunteerViewModel { get; private set; }

        public HomeController(TrustRepository repo)
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
        public async Task<ActionResult> TrustDashboardView()
        {
            var tes = User.Identity.GetUserId();
            _trustId = _repo.GetLinkedTrustIDWithUserId(User.Identity.GetUserId());

            if (_trustId != 0)
            {
                Trust result = _repo.GetTrustByTrustId(_trustId);
                result.Events = _repo.GetEventByTrustId(_trustId).ToList();
                result.Reviews = _repo.GetReviewsByTrustId(_trustId).ToList();
                ViewBag.Title = result.Name;

                List<TrustUserRelationship> volunteerList = _repo.GetUserIdLinkedWithTrustId(_trustId).ToList();
                List<VolunteerViewModel> volunteerVM = new List<VolunteerViewModel>();
                _userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

                foreach (var volunteer in volunteerList)
                {
                    var tempVolunteer = await _userManager.FindByIdAsync(volunteer.UserID);
                    volunteerVM.Add(new Models.VolunteerViewModel
                    {
                        Name = tempVolunteer.Name,
                        UserName = tempVolunteer.UserName,
                        PhoneNumber = tempVolunteer.PhoneNumber,
                        Rating = tempVolunteer.Rating
                    });
                }
                ViewBag.VolunteerList = volunteerVM;

                return View(result);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TrustDashboardView(Trust model)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTrust(model);
                if (_repo.Save())
                {
                    _repo.LinkTrustIDWithUserId(User.Identity.GetUserId(), model.Id, "", "");
                    _repo.Save();
                    _trustId = model.Id;
                    return View(model);
                }
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
            _trustId = result.First().Id;
            return View(result.First());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> Contact(string contactGroupName)
        {
            ViewBag.Message = "Your contact page.";
            if (contactGroupName != null)
                this.HttpContext.Session["contactGroupName"] = contactGroupName;

            var tes = User.Identity.GetUserId();
            int trustId = _repo.GetLinkedTrustIDWithUserId(User.Identity.GetUserId());

            if (trustId != 0)
            {
                List<VolunteerViewModel> volunteerVM = new List<VolunteerViewModel>();


                ICollection<TrustUser> unRegisteredUsers = _repo.GetUnRegisteredUsersFromTrustId(trustId);
                if (unRegisteredUsers != null)
                {
                    foreach (var unregisteredUser in unRegisteredUsers)
                    {
                        if (unregisteredUser.GroupName == contactGroupName)
                        {
                            volunteerVM.Add(new Models.VolunteerViewModel
                            {
                                Name = unregisteredUser.Name,
                                PhoneNumber = unregisteredUser.PhoneNumber,
                                GroupName = unregisteredUser.GroupName
                            });
                        }
                    }
                }

                List<TrustUserRelationship> volunteerList = _repo.GetUserIdLinkedWithTrustId(trustId).ToList();
                _userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

                foreach (var volunteer in volunteerList)
                {
                    if (volunteer.Group == contactGroupName)
                    {
                        var tempVolunteer = await _userManager.FindByIdAsync(volunteer.UserID);
                        volunteerVM.Add(new Models.VolunteerViewModel
                        {
                            Name = tempVolunteer.Name,
                            UserName = tempVolunteer.UserName,
                            PhoneNumber = tempVolunteer.PhoneNumber,
                            Rating = tempVolunteer.Rating,
                            GroupName = volunteer.Group
                        });
                    }
                }
                ViewBag.VolunteerList = volunteerVM;

                return View(volunteerVM);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel contactVM)
        {
            if (_trustId == 0)
            {
                _trustId = _repo.GetLinkedTrustIDWithUserId(User.Identity.GetUserId());
            }
            _userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser findUser = null;
            if (contactVM.MailId != null)
                findUser = _userManager.FindByEmail(contactVM.MailId);

            if (findUser == null && contactVM.PhoneNumber != null)
            {
                findUser = _userManager.Users.Where(x => x.PhoneNumber == contactVM.PhoneNumber).FirstOrDefault();
            }
            if (findUser != null)
            {
                //Adding User already registered to kamban.org
                _repo.LinkTrustIDWithUserId(findUser.Id, _trustId, "", (string)this.HttpContext.Session["contactGroupName"]);
                _repo.Save();
            }
            else
            {
                //Adding user not registered to kamban.org
                _repo.AddUnRegisteredUserToTrustId(new TrustUser
                {
                    Name = contactVM.Name,
                    MailId = contactVM.MailId,
                    PhoneNumber = contactVM.PhoneNumber,
                    TrustId = _trustId,
                    GroupName = (string)this.HttpContext.Session["contactGroupName"]
                });
                _repo.Save();
            }


            return View();
        }

        public ActionResult Inventory(string inventoryName)
        {
            ViewBag.Message = "Inventory Management Page";
            if (inventoryName != null)
                this.HttpContext.Session["InventoryName"] = inventoryName;
            else if (this.HttpContext.Session["InventoryName"] != null)
                inventoryName = (string)this.HttpContext.Session["InventoryName"];

            _userId = User.Identity.GetUserId();
            _trustId = _repo.GetLinkedTrustIDWithUserId(User.Identity.GetUserId());

            if (_trustId != 0)
            {
                var inv = _repo.GetAllInStockInventoryItems(_trustId)
                                .Where(x => x.GroupName == inventoryName)
                                .ToList();

                List<InventoryViewModel> inventoryVM = new List<InventoryViewModel>();

                foreach (var inventoryItem in inv)
                {
                    inventoryVM.Add(new Models.InventoryViewModel
                    {
                        Name = inventoryItem.Name,
                        OriginalAmount = inventoryItem.OriginalAmount,
                        PurchaseAmount = inventoryItem.PurchaseAmount,
                        Quantity = inventoryItem.Quantity
                    });
                }


                return View(inventoryVM);
            }
            else
            {
                return RedirectToAction("TrustView", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inventory(InventoryViewModel inventoryVM)
        {
            if (_trustId == 0)
            {
                _trustId = _repo.GetLinkedTrustIDWithUserId(User.Identity.GetUserId());
            }
            _repo.AddNewInStockInventoryItem(new Data.Trust.InventoryItem
            {
                Name = inventoryVM.Name,
                OriginalAmount = inventoryVM.OriginalAmount,
                PurchaseAmount = inventoryVM.PurchaseAmount,
                TrustID = _trustId,
                GroupName = (string)this.HttpContext.Session["InventoryName"],
                Quantity = inventoryVM.Quantity
            });
            _repo.Save();
            return View();
        }
    }
}