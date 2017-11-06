using Kamban.API.Contacts;
using Kamban.API.Data.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kamban.API.Trust
{
    public interface ITrustRepository
    {
        IQueryable<Trust> GetAllTrusts();
        
        bool AddNewTrust(Trust trust);
        Trust GetTrustByUserName(string userName);
        bool AddNewContactToTrust(string trustUserName, Contact newContact);
        bool AddNewGroup(string trustUserName, string groupName, List<int> userIds);
        Form GetFormByFormId(string userId, string id);
        IQueryable<Form> GetAllForm(string userId);
        bool AddNewForm(Form form);
        bool Save();
    }
}