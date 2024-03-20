using RSCS.FinancingStatements.Core.Models.BusinessObjects.Setting;
using RSCS.FinancingStatements.Core.Interfaces.DataAccess;
using RSCS.FinancingStatements.Core.Interfaces.Repository;
using RSCS.FinancingStatements.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects = RSCS.FinancingStatements.Core.Models.BusinessObjects;

namespace RSCS.FinancingStatements.Core.Services
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISettingRepository _settingRepository;

        public SettingService(IUnitOfWork unitOfWork, ISettingRepository settingRepository)
        {
            _unitOfWork = unitOfWork;
            _settingRepository = settingRepository;
        }

        public async Task<IEnumerable<Setting>> FetchSystemSettingsAsync()
        {
            List<Setting> systemSettings = new List<Setting>();
            foreach (var systemSettingEntity in await _settingRepository.GetAllAsync())
            {
                systemSettings.Add(systemSettingEntity.ToBusinessObject());
            }
            return systemSettings;
        }
    }
}
