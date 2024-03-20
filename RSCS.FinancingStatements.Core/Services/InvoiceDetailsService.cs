using RSCS.FinancingStatements.Core.Models.BusinessObjects.InvoiceDetails;
using RSCS.FinancingStatements.Core.Interfaces.Repository;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Services
{
    public class InvoiceDetailsService : IInvoiceDetailsService
    {

        private readonly IInvoiceDetailsRepository _invoiceDetailsRepository;
        public InvoiceDetailsService(IInvoiceDetailsRepository invoiceDetailsRepository)
        {
            _invoiceDetailsRepository = invoiceDetailsRepository;
        }

        public async Task<IEnumerable<InvoiceDetails>> FetchInvoiceDetails(int programId, string MasterId)
        {
            string query = "p_FinProgInvoices_GetInvoices";

            object param = new { programId, MasterId };
            List<InvoiceDetails> invoiceDetails = new List<InvoiceDetails>();
            foreach (var invoiceDetailsEntity in await _invoiceDetailsRepository.GetAllAsync(query, param))
            {
                invoiceDetails.Add(invoiceDetailsEntity.ToBusinessObject());
            }
            return invoiceDetails;
        }
    }
}
