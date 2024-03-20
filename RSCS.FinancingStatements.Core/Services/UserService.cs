using RSCS.FinancingStatements.Core.Models.BusinessObjects.User;
using RSCS.FinancingStatements.Core.Models.EntityModels;
using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using RSCS.FinancingStatements.Core.Interfaces.Repository;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using RSCS.FinancingStatements.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSCS.FinancingStatements.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IUserPermissionRepository userPermissionRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public Models.BusinessObjects.User.User CreateUser(Models.BusinessObjects.User.User user)
        {
            var allExistingUsers = _userRepository.GetAllAsync().Result;
            var existingUserEntity = allExistingUsers.FirstOrDefault(x => x.ID == user.ID);
            if (existingUserEntity == null)
            {
                int userCount = allExistingUsers.Count();
                user.NameID = ++userCount;
                _userRepository.InsertAsync(user.ToEntityModel()).Wait();
                _unitOfWork.Commit();
                ///object initialization should be moved to conversion helper
                _userPermissionRepository.InsertAsync(new tblUserPermission
                {
                    UserId = user.NameID,
                    Name = "RSCSFP",
                }).Wait();
                _unitOfWork.Commit();
            }
            return FetchUserByUsername(user.ID);
        }

        public Models.BusinessObjects.User.User FetchUserByUsername(string username)
        {
            Models.BusinessObjects.User.User existingUser = null;
            var allExistingUsers = _userRepository.GetAllAsync("Select NameID,ID,FirstName,LastName,Email From [Attendance].[dbo].[Resource] where Active = 'A'").Result;
            var existingUserEntity = allExistingUsers.FirstOrDefault(x => x.ID == username);
            if (existingUserEntity != null)
            {
                existingUser = existingUserEntity.ToBusinessObject();
                existingUser.Permissions = _userPermissionRepository.GetAllAsync("Select * From [Attendance].[dbo].[UserPermission]").Result.Where(x => x.UserId == existingUser.NameID).Select(x => x.Name);
            }
            return existingUser;
        }


    }
}
