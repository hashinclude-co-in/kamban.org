using Delete.Data;
using Delete.Data.Trust;
using Delete.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApplication1.Data;

namespace Delete.Controllers
{
    public class TrustController : ApiController
    {
        private TrustRepository _repo;
        public TrustController(TrustRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<Trust> GetCurrentUserTrustDetails()
        {
            var tes = User.Identity.GetUserId();
#if DEBUG
            if (tes == null) tes = "e226cb01-5d5f-4a5b-af20-fb646a3a2eea";
#endif

            var _trustId = _repo.GetLinkedTrustIDWithUserId(tes);

            if (_trustId != 0)
            {
                Trust result = _repo.GetTrustByTrustId(_trustId);
                result.Events = _repo.GetEventByTrustId(_trustId).ToList();
                result.Reviews = _repo.GetReviewsByTrustId(_trustId).ToList();

                List<TrustUserRelationship> volunteerList = _repo.GetUserIdLinkedWithTrustId(_trustId).ToList();
                List<VolunteerViewModel> volunteerVM = new List<VolunteerViewModel>();
                var _userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

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
                return result;
            }
            return null;
        }

        public async Task<List<string>> GetAllInventoryGroupName()
        {
            return null;
        }
        public async Task<bool> AddNewInventoryGroupName(string newGroupName)
        {
            try
            {
                var tes = User.Identity.GetUserId();
#if DEBUG
                if (tes == null) tes = "e226cb01-5d5f-4a5b-af20-fb646a3a2eea";
#endif

                var _trustId = _repo.GetLinkedTrustIDWithUserId(tes);
                if (_trustId != 0)
                {
                    Trust result = _repo.GetTrustByTrustId(_trustId);
                    result.InventoryGroups.Add(newGroupName, new List<Data.Trust.InventoryItem>());
                    _repo.Save();
                }
            }
            catch
            {
                return false;
            }

                return true;
        }

        public async Task<bool> AddNewInventoryItemToGroup(string groupName, InventoryItem inventoryItem)
        {
            try
            {
                var tes = User.Identity.GetUserId();
#if DEBUG
                if (tes == null) tes = "e226cb01-5d5f-4a5b-af20-fb646a3a2eea";
#endif

                var _trustId = _repo.GetLinkedTrustIDWithUserId(tes);
                if (_trustId != 0)
                {
                    Trust result = _repo.GetTrustByTrustId(_trustId);
                    if(result.InventoryGroups.ContainsKey(groupName))
                    {
                        result.InventoryGroups[groupName].Add(inventoryItem);
                        _repo.Save();
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}