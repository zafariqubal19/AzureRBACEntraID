using RSCS.FinancingStatements.Core.Models.BusinessObjects.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Interfaces.Service
{
    public interface IContactsService
    {
        Task<IEnumerable<Contacts>> FetchContacts(int masterId);
    }
}
