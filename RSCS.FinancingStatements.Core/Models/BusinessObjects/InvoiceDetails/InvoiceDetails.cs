using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.BusinessObjects.InvoiceDetails
{
    public class InvoiceDetails
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public float TotalAmount { get; set; }
        public int ViewCount { get; set; }
        public string BilltoCustomerNo { get; set; }
        public string BilltoName { get; set; }
        public string SelltoCustomerNo { get; set; }
        public string StoreID { get; set; }
        public string SelltoCustomerName { get; set; }
        public string SelltoAddress { get; set; }
        public string SelltoCity { get; set; }
        public string SelltoState { get; set; }
        public string SelltoZip { get; set; }
        public string OrigFilePath { get; set; }
        public string FilePath { get; set; }
        public DateTime DateAdded { get; set; }
        public int Copied { get; set; }
        public int ProgramID { get; set; }
        public string masterID { get; set; }
        public string FranchiseeID { get; set; }
    }
}
