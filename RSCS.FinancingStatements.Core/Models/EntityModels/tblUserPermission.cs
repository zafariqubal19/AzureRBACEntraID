using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.EntityModels
{
    public partial class tblUserPermission
    {
        public int PermissionId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; } = null!;
    }
}
