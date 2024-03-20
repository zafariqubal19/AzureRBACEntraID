using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects = RSCS.FinancingStatements.Core.Models.BusinessObjects;


namespace RSCS.FinancingStatements.Core.Interfaces.Service
{
	public interface ISettingService
	{
		Task<IEnumerable<BusinessObjects.Setting.Setting>> FetchSystemSettingsAsync();
	}
}
