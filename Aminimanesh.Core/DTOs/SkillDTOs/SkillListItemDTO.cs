using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.SkillDTOs
{
    public class SkillListItemDTO
    {
        public int SkillId { get; set; }
        public string Title { get; set; }

        public int? Value { get; set; }

        public int? Priority { get; set; }

        public bool IsSideSkill { get; set; }
    }
}
