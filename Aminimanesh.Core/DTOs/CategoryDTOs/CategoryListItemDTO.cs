using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.CategoryDTOs
{
    public class CategoryListItemDTO
    {
        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string UrlTitle { get; set; }

        public int ProjectsCount { get; set; }
    }
}
