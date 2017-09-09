using Kamban.API.Contacts;
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
        bool Save();
    }
}