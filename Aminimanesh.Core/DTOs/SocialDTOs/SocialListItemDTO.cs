using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.SocialDTOs
{
    public class SocialListItemDTO
    {
        public int SocialId { get; set; }

        public string Title { get; set; }

        public string LinkAddress { get; set; }

        public string Icon { get; set; }

        public bool IsDeleted { get; set; }
    }
}
