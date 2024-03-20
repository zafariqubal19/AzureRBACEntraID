using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSCS.FinancingStatements.Core.Models.BusinessObjects.Setting;
using RSCS.FinancingStatements.Core.Models.BusinessObjects.User;
using BusinessObjects = RSCS.FinancingStatements.Core.Models.BusinessObjects;

namespace RSCS.FinancingStatements.Core.Models.BusinessObjects.ViewModel
{
    public class IndexViewModel
    {
        public User.User User { get; set; }
        public IEnumerable<Setting.Setting> Settings { get; set; }
    }
}
