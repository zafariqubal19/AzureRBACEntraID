using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.BusinessObjects.References
{
    public class References
    {
        public int MasterId { get; set; }
        public string Reference { get; set; }
        public int Contacts { get; set; }
        public string AuthContacts { get; set; }
        public string AutoContacts { get; set; }


    }
}
