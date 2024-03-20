using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.BusinessObjects.Authentication
{
    public class AuthResult
    {
    }

    public class CustomPrincipalClaim
    {
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; } = false;
        public string AccessToken { get; set; }
    }
}
