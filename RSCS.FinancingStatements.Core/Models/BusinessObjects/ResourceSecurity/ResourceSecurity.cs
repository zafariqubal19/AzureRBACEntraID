using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.BusinessObjects.ResourceSecurity
{
    public class ResourceSecurity
    {
        public int ResourceSecurityID { get; set; }
        public int NameID { get; set; }
        public int SystemID { get; set; }
        public int ResourceSecurityTypeID { get; set; }
        public string ResourceSecurityValue { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string Comments { get; set; }
        public int Active { get; set; }
    }
}
