using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.EntityModels
{
    public partial class tblUser
    {
        //public int UserId { get; set; }

        //public string Username { get; set; } = null!;
        public int NameID { get; set; }

        public string ID { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
    }
}
