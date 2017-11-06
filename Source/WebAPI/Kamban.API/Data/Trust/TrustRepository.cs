using Kamban.API.Contacts;
using Kamban.API.Data.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kamban.API.Trust
{
    public class TrustRepository : ITrustRepository
    {
        #region Fields
        TrustContext _ctx;
        #endregion

        #region Constructor
        public TrustRepository(TrustContext ctx)
        {
            _ctx = ctx;
        }
        #endregion

        #region Public Methods
        public bool AddNewTrust(Trust trust)
        {
            try
            {
                _ctx.Trusts.Add(trust);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IQueryable<Trust> GetAllTrusts()
        {
            try
            {
                return _ctx.Trusts;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Groups> GetAllGroups(string trustUserName)
        {
            try
            {
                return _ctx.Groups.Where(x => x.TrustUserName == trustUserName);
            }
            catch
            {
                return null;
            }
        }


        public Trust GetTrustByUserName(string userName)
        {
            try
            {
                return _ctx.Trusts
                            .Where(x => x.UserName == userName)
                            .First();
            }
            catch
            {
                return null;
            }
        }

        public bool AddNewContactToTrust(string trustUserName, Contact newContact)
        {
            try
            {
                newContact.TrustUserName = trustUserName;
                _ctx.Contacts.Add(newContact);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddNewGroup(string trustUserName, string groupName, List<int> userIds)
        {
            try
            {
                _ctx.Groups.Add(new Contacts.Groups()
                {
                    TrustUserName = trustUserName,
                    Name = groupName,
                    UserIds = userIds
                });
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool AddNewMemberToTheGroup(string trustUserName, string groupName, int userId)
        {
            try
            {
                var group = _ctx.Groups
                                .Where(x => x.TrustUserName == trustUserName)
                                .Where(x => x.Name == groupName)
                                .First();
                group.UserIds.Add(userId);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool RemoveMemberFromTheGroup(string trustUserName, string groupName, int userId)
        {
            try
            {
                var group = _ctx.Groups
                                .Where(x => x.TrustUserName == trustUserName)
                                .Where(x => x.Name == groupName)
                                .First();
                group.UserIds.Remove(userId);
                return true;
            }
            catch
            {
                return false;
            }

        }


        #region Forms
        public bool AddNewForm(Form form)
        {
            try
            {
                _ctx.Forms.Add(form);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Form GetFormByFormId(string userId, string id)
        {
            try
            {
                return _ctx.Forms.Where(x => x.Id == id)
                                .Where(x=>x.UserId == userId)
                                .First();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Form> GetAllForm(string userId)
        {
            try
            {
                return _ctx.Forms
                            .Where(x=>x.UserId == userId);
            }
            catch
            {
                return null;
            }
        }
        #endregion
        public bool Save()
        {
            try
            {
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}