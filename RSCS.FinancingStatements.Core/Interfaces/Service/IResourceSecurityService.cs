using RSCS.FinancingStatements.Core.Models.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Interfaces.Service
{
    public interface IResourceSecurityService
    {
        Task<int> SecurityAcces(GrantOrRestrict grantRestrictParameter);
    }
}
