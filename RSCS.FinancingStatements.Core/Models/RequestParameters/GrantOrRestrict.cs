using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.RequestParameters
{
    public class GrantOrRestrict
    {
        public int NameID { get; set; }
        public int ResourceSecurityTypeID { get; set; }
        public string ResourceSecurityValue { get; set; }
        public string LastModifiedBy { get; set; }
        public string? Contact { get; set; } = null;
    }
}
