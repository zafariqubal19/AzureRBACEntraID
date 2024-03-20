using RSCS.FinancingStatements.Core.Models.BusinessObjects.InvoiceDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Interfaces.Service
{
    public interface IInvoiceDetailsService
    {
        Task<IEnumerable<InvoiceDetails>> FetchInvoiceDetails(int programId, string MasterId);
    }
}
