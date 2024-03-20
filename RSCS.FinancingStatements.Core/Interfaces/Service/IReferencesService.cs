using RSCS.FinancingStatements.Core.Models.BusinessObjects.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Interfaces.Service
{
    public interface IReferencesService
    {
        Task<IEnumerable<References>> FetchReferences();
    }
}
