using Aminimanesh.Core.DTOs.HistoryDTOs;
using Aminimanesh.Core.DTOs.LanguageDTOs;
using Aminimanesh.Core.DTOs.OwnerDTOs;
using Aminimanesh.Core.DTOs.SkillDTOs;
using Aminimanesh.Core.DTOs.SocialDTOs;
using Aminimanesh.Core.Services.Interfaces;
using Aminimanesh.DataLayer.Context;
using Aminimanesh.DataLayer.Entities.Owner;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly AminimaneshContext _context;
        private readonly IMapper _mapper;
        public OwnerService(AminimaneshContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> AddHistoryAsync(History history)
        {
            await _context.Histories.AddAsync(history);
            await _context.SaveChangesAsync();
            return history.HistoryLineId;
        }

        public async Task<int> AddHistoryLineAsync(HistoryLine line)
        {
            await _context.HistoryLines.AddAsync(line);
            await _context.SaveChangesAsync();
            return line.HistoryLineId;
        }

        public async Task<int> AddLanguageAsync(Language language)
        {
            await _context.Languages.AddAsync(language);
            await _context.SaveChangesAsync();
            return language.LanguageId;
        }

        public async Task<int> AddOwnerAsync(CreateOwnerDTO ownerDTO)
        {
            var owner = _mapper.Map<Owner>(ownerDTO);
            await _context.Owner.AddAsync(owner);
            await _context.SaveChangesAsync();
            return owner.OwnerId;
        }

        public async Task<int> AddSkillAsync(CreateSkillDTO skillDTO)
        {
            var skill = _mapper.Map<Skill>(skillDTO);
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
            return skill.SkillId;
        }

        public async Task<int> AddSocialAsync(Social social)
        {
            await _context.Socials.AddAsync(social);
            await _context.SaveChangesAsync();
            return social.SocialId;
        }

        public async Task<List<HistoryLineListItemDTO>> GetAllHistoryLinesAsync()
        {
            var lines = await _context.HistoryLines.Include(hl => hl.Histories).OrderBy(hl => hl.Priority).ToListAsync();
            return _mapper.Map<List<HistoryLineListItemDTO>>(lines);
        }

        public async Task<List<LanguageListItemDTO>> GetAllLanguagesAsync()
        {
            var languages = await _context.Languages.ToListAsync();
            return _mapper.Map<List<LanguageListItemDTO>>(languages);
        }

        public async Task<List<SkillListItemDTO>> GetAllMainSkillsAsync()
        {
            var skills = await _context.Skills.Where(s => !s.IsSideSkill).OrderBy(s => s.Priority).ToListAsync();
            return _mapper.Map<List<SkillListItemDTO>>(skills);
        }

        public async Task<List<SkillListItemDTO>> GetAllSideSkillsAsync()
        {
            var skills = await _context.Skills.Where(s => s.IsSideSkill).OrderBy(s => s.Priority).ToListAsync();
            return _mapper.Map<List<SkillListItemDTO>>(skills);
        }

        public async Task<List<SkillListItemDTO>> GetAllSkillsAsync()
        {
            var skill = await _context.Skills.ToListAsync();
            return _mapper.Map<List<SkillListItemDTO>>(skill);
        }

        public async Task<List<SocialListItemDTO>> GetAllSocialsAsync()
        {
            var socials = await _context.Socials.ToListAsync();
            return _mapper.Map<List<SocialListItemDTO>>(socials);
        }

        public async Task<CommonInfoDTO> GetCommonInfoAsync()
        {
            var info = await _context.Owner.FirstOrDefaultAsync();
            return _mapper.Map<CommonInfoDTO>(info);
        }

        public async Task<ContactInfoDTO> GetContactInfoAsync()
        {
            var owner = (await _context.Owner.FirstOrDefaultAsync());
            return _mapper.Map<ContactInfoDTO>(owner);
        }

        public async Task<ExperienceInfoDTO> GetExperienceInfoAsync()
        {
            var owner = await _context.Owner.FirstOrDefaultAsync();
            return _mapper.Map<ExperienceInfoDTO>(owner);
        }

        public async Task<History> GetHistoryByIdAsync(int historyId)
        {
            var history = await _context.Histories.FindAsync(historyId);
            return history;
        }

        public async Task<HistoryLine> GetHistoryLineByIdAsync(int lineId)
        {
            return await _context.HistoryLines.Include(hl => hl.Histories).SingleOrDefaultAsync(hl => hl.HistoryLineId == lineId);
        }

        public async Task<string> GetIncomeEmailAsync()
        {
            var res = (await _context.Owner.FirstOrDefaultAsync()).IncomeEmail;
            return res;
        }

        public async Task<Language> GetLanguageByIdAsync(int languageId)
        {
            return await _context.Languages.FindAsync(languageId);
        }

        public async Task<List<HistoryListItemDTO>> GetLineHistoriesAsync(int lineId)
        {
            var histories = await _context.Histories.Where(h => h.HistoryLineId == lineId).OrderBy(h => h.Priority).ToListAsync();
            return _mapper.Map<List<HistoryListItemDTO>>(histories);
        }

        public async Task<EditOwnerDTO> GetOwnerForEditAsync()
        {
            var owner = await _context.Owner.SingleOrDefaultAsync();
            return _mapper.Map<EditOwnerDTO>(owner);
        }

        public async Task<OwnerGeneralDTO> GetOwnerForShowAsync()
        {
            var owner = await _context.Owner.SingleOrDefaultAsync();
            return _mapper.Map<OwnerGeneralDTO>(owner);
        }

        public async Task<ProfileInfoDTO> GetProfileInfoAsync()
        {
            var owner = await _context.Owner.FirstOrDefaultAsync();
            return _mapper.Map<ProfileInfoDTO>(owner);
        }

        public async Task<EditSkillDTO> GetSkillForEditAsync(int skillId)
        {
            var skill = await _context.Skills.FindAsync(skillId);
            return _mapper.Map<EditSkillDTO>(skill);
        }

        public async Task<Social> GetSocialByIdAsync(int socialId)
        {
            var social = await _context.Socials.FindAsync(socialId);
            return social;
        }

        public async Task<bool> HasOwner()
        {
            return await _context.Owner.AnyAsync();
        }

        public async Task<int> RemoveHistoryByIdAsync(int historyId)
        {
            var history = await _context.Histories.FindAsync(historyId);
            _context.Histories.Remove(history);
            await _context.SaveChangesAsync();
            return history.HistoryLineId;
        }

        public async Task RemoveHistoryLineByIdAsync(int lineId)
        {
            var history = await _context.HistoryLines.FindAsync(lineId);
            history.IsDeleted = true;
            await UpdateHistoryLineAsync(history);
        }

        public async Task RemoveLanguageByIdAsync(int languageId)
        {
            var language = await _context.Languages.FindAsync(languageId);
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveSkillByIdAsync(int skillId)
        {
            var skill = await _context.Skills.FindAsync(skillId);
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveSocialByIdAsync(int socialId)
        {
            var social = await _context.Socials.FindAsync(socialId);
            _context.Socials.Remove(social);
            await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateHistoryAsync(History history)
        {
            _context.Histories.Update(history);
            await _context.SaveChangesAsync();
            return history.HistoryLineId;
        }

        public async Task<int> UpdateHistoryLineAsync(HistoryLine line)
        {
            _context.HistoryLines.Update(line);
            await _context.SaveChangesAsync();
            return line.HistoryLineId;
        }

        public async Task<int> UpdateLanguageAsync(Language language)
        {
            _context.Languages.Update(language);
            await _context.SaveChangesAsync();
            return language.LanguageId;
        }

        public async Task<int> UpdateOwnerAsync(EditOwnerDTO ownerDTO)
        {
            var owner = _mapper.Map<Owner>(ownerDTO);
            _context.Owner.Update(owner);
            await _context.SaveChangesAsync();
            return owner.OwnerId;
        }

        public async Task<int> UpdateSkillAsync(EditSkillDTO skillDTO)
        {
            var skill = _mapper.Map<Skill>(skillDTO);
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
            return skill.SkillId;
        }

        public async Task<int> UpdateSocialAsync(Social social)
        {
            _context.Socials.Update(social);
            await _context.SaveChangesAsync();
            return social.SocialId;
        }
    }
}
