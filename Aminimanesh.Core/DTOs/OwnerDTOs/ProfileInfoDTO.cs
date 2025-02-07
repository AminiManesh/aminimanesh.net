using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.OwnerDTOs
{
    public class ProfileInfoDTO
    {
        public string FullName { get; set; }

        public string FirstJob { get; set; }

        public string SecondJob { get; set; }

        public string Avatar { get; set; }
    }
}
