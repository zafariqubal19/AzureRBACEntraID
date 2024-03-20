using BusinessObjects = RSCS.FinancingStatements.Core.Models.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Interfaces.Service
{
	public interface IUserService
	{
		BusinessObjects.User.User FetchUserByUsername(string username);
		BusinessObjects.User.User CreateUser(BusinessObjects.User.User user);
	}
}
