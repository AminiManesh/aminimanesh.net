using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aminimanesh.Core.DTOs.UserDTOs;
using Aminimanesh.Core.Security;
using Aminimanesh.Core.Services.Interfaces;
using Aminimanesh.DataLayer.Context;
using Aminimanesh.DataLayer.Entities.User;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Aminimanesh.Core.Services
{
    public class UserService : IUserService
    {
        private readonly AminimaneshContext _context;
        private readonly IMapper _mapper;
        public UserService(AminimaneshContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task ChagneUserCredentialsAsync(ChangeCredentialsDTO credentialsDTO)
        {
            var existingEntity = _context.Set<User>().Local.FirstOrDefault(e => e.UserId == credentialsDTO.UserId);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            var user = _mapper.Map<User>(credentialsDTO);
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckUserCredentialsAsync(ChangeCredentialsDTO credentialsDTO)
        {
            var user = await _context.User.SingleAsync();

            if (user == null)
            {
                return false;
            }

            if (PasswordHelper.VerifyPasswordBcrypt(credentialsDTO.OldPasword, user.Pasword))
            {
                return true;
            }

            return false;
        }

        public async Task<User> CheckUserCredentialsAsync(string userName, string password)
        {
            var user = await _context.User.SingleOrDefaultAsync();

            if (user != null && PasswordHelper.VerifyPasswordBcrypt(password, user.Pasword) && user.UserName == userName)
            {
                return user;
            }

            return null;
        }

        public async Task<User> GetUserAsync()
        {
            var user = await _context.User.SingleAsync();
            return user;
        }

        public async Task<ChangeCredentialsDTO> GetUserCredentialsAsync()
        {
            var user = await _context.User.SingleAsync();
            return _mapper.Map<ChangeCredentialsDTO>(user);
        }
    }
}
