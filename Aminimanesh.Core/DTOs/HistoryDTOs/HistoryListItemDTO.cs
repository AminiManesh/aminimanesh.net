using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.HistoryDTOs
{
    public class HistoryListItemDTO
    {
        public string Title { get; set; }

        public string Adjective { get; set; }

        public string Description { get; set; }

        public string StartTime { get; set; }

        public string? EndTime { get; set; }

        public bool Finished { get; set; }

        public string LinkAddress { get; set; }

        public string LinkLabel { get; set; }

        public int Priority { get; set; } = 1;
    }
}
