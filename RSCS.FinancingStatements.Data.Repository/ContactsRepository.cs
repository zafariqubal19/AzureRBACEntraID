using RSCS.FinancingStatements.Data.Persistance.DataAccess;
using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using RSCS.FinancingStatements.Core.Interfaces.Repository;
using Entities = RSCS.FinancingStatements.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Data.Repository
{
    public class ContactsRepository : GenericRepository<Entities.EntityModels.tblContacts>, IContactsRepository
    {
        public ContactsRepository(IDbConnection dbConnection, IDBTransactionFactory dbTransactionFactory) : base(dbConnection, dbTransactionFactory)
        {
        }
    }
}
