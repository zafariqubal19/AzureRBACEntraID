using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.BusinessObjects.StatementDetails
{
    public class StatementDetails
    {
        public string Program { get; set; }
        public string Statement { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime DateAdded { get; set; }
        public string QARoot { get; set; }
        public string ProdRoot { get; set; }
        public int StatementID { get; set; }
        public int ProgramID { get; set; }
        public string FranchiseeID { get; set; }
        public string MasterID { get; set; }
    }
}
