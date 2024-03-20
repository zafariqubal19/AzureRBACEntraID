using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.EntityModels
{
    public class tblFinPrograms
    {
        public int ProgramID { get; set; }
        public string CampaignCode { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PaymentTermsCode { get; set; }
        public DateTime DateAdded { get; set; }
        public string ActiveProcess { get; set; }
        public string ActiveWeb { get; set; }
        public string Comments { get; set; }
        public int FranchiseeCount { get; set; }
        public int InvoiceCount { get; set; }
        public int StatementCount { get; set; }
        public int StoreCount { get; set; }
        public int StatementFranchiseeCount { get; set; }
        public int LastStatementPeriod { get; set; }
        public int FirstStatementPeriod { get; set; }
        public DateTime FirstInvoice { get; set; }
        public DateTime lastInvoice { get; set; }
    }
}
