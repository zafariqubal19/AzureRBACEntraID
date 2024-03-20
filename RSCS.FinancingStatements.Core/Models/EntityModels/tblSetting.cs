using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.EntityModels
{
    public partial class tblSetting
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Value { get; set; }
    }
}
