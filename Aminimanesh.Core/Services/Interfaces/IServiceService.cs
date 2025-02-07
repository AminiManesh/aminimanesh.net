using Aminimanesh.Core.DTOs.ServiceDTOs;
using Aminimanesh.Core.DTOs.SpeechDTOs;
using Aminimanesh.DataLayer.Entities.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.Services.Interfaces
{
    public interface IServiceService
    {
        Task<List<ServiceListItemDTO>> GetAllServicesAsync();

        #region Speech
        Task<List<SpeechListItemDTO>> GetAllSpeechsAsync();
        Task<int> AddSpeechAsync(Speech speech);
        Task<int> UpdateSpeechAsync(Speech speech);
        Task<Speech> GetSpeechByIdAsync(int speechId);
        Task RemoveSpeechbyIdAsync(int speechId);
        #endregion

        Task<int> AddServiceAsync(CreateServiceDTO serviceDTO);
        Task<int> UpdateServiceAsync(EditServiceDTO serviceDTO);
        Task<EditServiceDTO> GetServiceForEditAsync(int serviceId);
        Task RemoveServiceByIdAsync(int serviceId);

        #region Message
        Task<List<Message>> GetAllMessages();
        Task<List<Message>> GetNewMessages(int take);
        Task<List<Message>> GetDeletedMessages();
        Task<int> AddMessageAsync(Message message);

        Task RemoveMessageByIdAsync(int messageId);
        Task RestoreMessageByIdAsync(int messageId);

        Task<Message> GetMessageByIdAsync(int messageId);
        #endregion
    }
}
