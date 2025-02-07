using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.LanguageDTOs
{
    public class LanguageListItemDTO
    {
        public int LanguageId { get; set; }

        public string Title { get; set; }

        public int Value { get; set; }
    }
}
