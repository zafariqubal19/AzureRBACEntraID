using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.RequestParameters
{
    public class FinProgramRequestParameter
    {
        public int ProgramId { get; set; }
        public DateTime? StartDate { get; set; } = null!;
        public DateTime? EndDate { get; set; } = null!;
        public string? ActiveProcess { get; set; } = null!;
        public string? ActiveWeb { get; set; } = null!;
        public string? PaymentTermsCode { get; set; } = null!;
        public string? Comments { get; set; } = null!;
    }
}
