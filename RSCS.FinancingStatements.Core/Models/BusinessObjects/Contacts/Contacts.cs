using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.BusinessObjects.Contacts
{
    public class Contacts
    {
        public string Status { get; set; }
        public string FOR { get; set; }
        public string Contact { get; set; }
        public string Title { get; set; }
        public string RT { get; set; }
        public string A { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModBy { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string NameID { get; set; }
    }
}
