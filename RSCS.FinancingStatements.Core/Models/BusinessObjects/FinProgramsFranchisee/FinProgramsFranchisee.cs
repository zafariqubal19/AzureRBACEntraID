using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.BusinessObjects.FinProgramsFranchisee
{
    public class FinProgramsFranchisee
    {
        public int ProgramID { get; set; }
        public string MasterID { get; set; }
        public string Reference { get; set; }
        public float InvoiceAmount { get; set; }
        public int InvoiceStores { get; set; }
        public int Invoices { get; set; }
        public DateTime InvoiceDateFrom { get; set; }
        public DateTime InvoiceDateTo { get; set; }
        public int Statements { get; set; }
        public int StatementFrom { get; set; }
        public int StatementTo { get; set; }
    }
}
