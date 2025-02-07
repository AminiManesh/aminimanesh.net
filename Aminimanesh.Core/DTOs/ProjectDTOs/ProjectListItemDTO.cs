using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.ProjectDTOs
{
    public class ProjectListItemDTO
    {
        public int ProjectId { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string UrlTitle { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string Thumbnail { get; set; }

        public string CategoryTitle { get; set; }

        public int Priority { get; set; } = 1;
    }
}
