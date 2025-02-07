using Aminimanesh.Core.DTOs.AttachmentDTOs;
using Aminimanesh.Core.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.ProjectDTOs
{
    public class ProjectGeneralDTO
    {
        public int ProjectId { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string Thumbnail { get; set; }

        public string OrderDate { get; set; }

        public string FinishDate { get; set; }

        public bool IsFinished { get; set; }

        public string CustomerName { get; set; }

        public string WebsiteCategory { get; set; }

        public string? Url { get; set; }

        public List<AttachmentListItemDTO> Attachments { get; set; }

        public CategoryListItemDTO Category { get; set; }
    }
}
