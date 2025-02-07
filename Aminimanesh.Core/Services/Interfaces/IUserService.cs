using Aminimanesh.Core.DTOs.UserDTOs;
using Aminimanesh.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CheckUserCredentialsAsync(string userName, string password);
        Task<bool> CheckUserCredentialsAsync(ChangeCredentialsDTO credentialsDTO);

        Task ChagneUserCredentialsAsync(ChangeCredentialsDTO credentialsDTO);

        Task<User> GetUserAsync();
        Task<ChangeCredentialsDTO> GetUserCredentialsAsync();
    }
}
