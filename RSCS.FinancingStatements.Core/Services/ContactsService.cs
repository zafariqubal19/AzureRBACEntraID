using RSCS.FinancingStatements.Core.Models.BusinessObjects.Contacts;
using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using RSCS.FinancingStatements.Core.Interfaces.Repository;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IContactsRepository _contactsRepository;

        public ContactsService(IUnitOfWork UnitOfWork, IContactsRepository contactsRepository)
        {
            _UnitOfWork = UnitOfWork;
            _contactsRepository = contactsRepository;
        }
        public async Task<IEnumerable<Contacts>> FetchContacts(int masterId)
        {

            string SQLQuery = "p_Attendance_FranchiseeList";
            List<Contacts> contacts = new List<Contacts>();
            object param = new { masterId };
            foreach (var contactsEntity in await _contactsRepository.GetAllAsync(SQLQuery, param))
            {
                contacts.Add(contactsEntity.ToBusinessObject());
            }
            return contacts;
        }
    }
}
