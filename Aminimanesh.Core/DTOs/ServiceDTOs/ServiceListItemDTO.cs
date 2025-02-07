using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.ServiceDTOs
{
    public class ServiceListItemDTO
    {
        public int ServiceId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; } = 1;
    }
}
