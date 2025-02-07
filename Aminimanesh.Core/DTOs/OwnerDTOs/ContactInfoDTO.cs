using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.OwnerDTOs
{
    public class ContactInfoDTO
    {
        public string Country { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public string Telegram { get; set; }

        public string Whatsapp { get; set; }

        public string Instagram { get; set; }

        public string Mobile { get; set; }

        public string Mobile2 { get; set; }
    }
}
