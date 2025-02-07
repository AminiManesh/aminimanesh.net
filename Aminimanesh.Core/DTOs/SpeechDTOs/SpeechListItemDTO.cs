using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.SpeechDTOs
{
    public class SpeechListItemDTO
    {
        public int SpeechId { get; set; }

        public string Text { get; set; }

        public int Priority { get; set; } = 1;
    }
}
