using Aminimanesh.Core.DTOs.HistoryDTOs;
using Aminimanesh.Core.DTOs.LanguageDTOs;
using Aminimanesh.Core.DTOs.OwnerDTOs;
using Aminimanesh.Core.DTOs.SkillDTOs;
using Aminimanesh.Core.DTOs.SocialDTOs;
using Aminimanesh.DataLayer.Entities.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<bool> HasOwner();

        Task<EditOwnerDTO> GetOwnerForEditAsync();

        Task<int> AddOwnerAsync(CreateOwnerDTO ownerDTO);

        Task<int> UpdateOwnerAsync(EditOwnerDTO ownerDTO);

        Task<OwnerGeneralDTO> GetOwnerForShowAsync();

        Task<string> GetIncomeEmailAsync();

        Task<ProfileInfoDTO> GetProfileInfoAsync();

        Task<List<LanguageListItemDTO>> GetAllLanguagesAsync();
        Task<Language> GetLanguageByIdAsync(int languageId);
        Task<int> AddLanguageAsync(Language language);
        Task<int> UpdateLanguageAsync(Language language);
        Task RemoveLanguageByIdAsync(int languageId);


        #region Skills
        Task<List<SkillListItemDTO>> GetAllMainSkillsAsync();

        Task<List<SkillListItemDTO>> GetAllSideSkillsAsync();

        Task<int> AddSkillAsync(CreateSkillDTO skillDTO);
        Task<int> UpdateSkillAsync(EditSkillDTO skillDTO);
        Task<EditSkillDTO> GetSkillForEditAsync(int skillId);
        Task<List<SkillListItemDTO>> GetAllSkillsAsync();
        Task RemoveSkillByIdAsync(int skillId);
        #endregion


        Task<ContactInfoDTO> GetContactInfoAsync();

        Task<ExperienceInfoDTO> GetExperienceInfoAsync();


        #region History Line
        Task<List<HistoryLineListItemDTO>> GetAllHistoryLinesAsync();
        Task<int> AddHistoryLineAsync(HistoryLine line);
        Task<int> UpdateHistoryLineAsync(HistoryLine line);
        Task<HistoryLine> GetHistoryLineByIdAsync(int lineId);
        Task RemoveHistoryLineByIdAsync(int lineId);
        #endregion

        #region History
        Task<List<HistoryListItemDTO>> GetLineHistoriesAsync(int lineId);
        Task<int> AddHistoryAsync(History history);
        Task<int> UpdateHistoryAsync(History history);
        Task<History> GetHistoryByIdAsync(int historyId);
        Task<int> RemoveHistoryByIdAsync(int historyId);
        #endregion

        #region Socials
        Task<List<SocialListItemDTO>> GetAllSocialsAsync();
        Task<Social> GetSocialByIdAsync(int socialId);
        Task<int> AddSocialAsync(Social social);
        Task<int> UpdateSocialAsync(Social social);
        Task RemoveSocialByIdAsync(int socialId);
        #endregion

        Task<CommonInfoDTO> GetCommonInfoAsync();
    }
}
