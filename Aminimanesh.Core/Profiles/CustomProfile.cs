using Aminimanesh.Core.DTOs.AttachmentDTOs;
using Aminimanesh.Core.DTOs.CategoryDTOs;
using Aminimanesh.Core.DTOs.HistoryDTOs;
using Aminimanesh.Core.DTOs.LanguageDTOs;
using Aminimanesh.Core.DTOs.OwnerDTOs;
using Aminimanesh.Core.DTOs.ProjectDTOs;
using Aminimanesh.Core.DTOs.ServiceDTOs;
using Aminimanesh.Core.DTOs.SkillDTOs;
using Aminimanesh.Core.DTOs.SocialDTOs;
using Aminimanesh.Core.DTOs.SpeechDTOs;
using Aminimanesh.Core.DTOs.UserDTOs;
using Aminimanesh.Core.Security;
using Aminimanesh.DataLayer.Entities.Owner;
using Aminimanesh.DataLayer.Entities.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aminimanesh.Core.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Language, LanguageListItemDTO>();

            CreateMap<Skill, SkillListItemDTO>();
            CreateMap<CreateSkillDTO, Skill>();
            CreateMap<EditSkillDTO, Skill>()
                .ReverseMap();

            CreateMap<Owner, ProfileInfoDTO>();
            CreateMap<Owner, ContactInfoDTO>();
            CreateMap<Owner, CommonInfoDTO>();
            CreateMap<Owner, ExperienceInfoDTO>();
            CreateMap<Owner, OwnerGeneralDTO>();
            CreateMap<Owner, EditOwnerDTO>()
                .ReverseMap();
            CreateMap<CreateOwnerDTO, Owner>();

            CreateMap<Service, ServiceListItemDTO>();
            CreateMap<CreateServiceDTO, Service>();
            CreateMap<EditServiceDTO, Service>()
                .ReverseMap();


            CreateMap<Project, ProjectListItemDTO>()
                .ForMember(dest => dest.CategoryTitle, i => i.MapFrom(src => src.Category.Title));
            CreateMap<Project, ProjectGeneralDTO>();
            CreateMap<CreateProjectDTO, Project>()
                .ForMember(dest => dest.Thumbnail, i => i.MapFrom(src => src.Thumbnail.FileName))
                .ForMember(dest => dest.UrlTitle, i => i.MapFrom(src => Regex.Replace(src.Title, @"\s*-\s*|\s+", "-")));
            CreateMap<Project, EditProjectDTO>()
                .ReverseMap()
                .ForMember(dest => dest.UrlTitle, i => i.MapFrom(src => Regex.Replace(src.Title, @"\s*-\s*|\s+", "-")));

            CreateMap<Category, CategoryListItemDTO>()
                .ForMember(dest => dest.ProjectsCount, i => i.MapFrom(src => src.Projects.Count));

            CreateMap<History, HistoryListItemDTO>();
            CreateMap<HistoryLine, HistoryLineListItemDTO>();

            CreateMap<Speech, SpeechListItemDTO>();

            CreateMap<Social, SocialListItemDTO>();

            CreateMap<CreateAttachmentDTO, Attachment>();
            CreateMap<Attachment, AttachmentListItemDTO>();

            CreateMap<ChangeCredentialsDTO, User>()
                .ForMember(dest => dest.Pasword, i => i.MapFrom(src => PasswordHelper.HashPasswordBcrypt(src.NewPasword)))
                .ReverseMap();
        }
    }
}
