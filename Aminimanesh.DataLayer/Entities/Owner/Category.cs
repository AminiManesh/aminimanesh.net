using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.DataLayer.Entities.Owner
{
    public class Category
    {
        public Category()
        {

        }

        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "عنوان دسته بندی")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Title { get; set; }

        [Display(Name = " عنوان دسته‌بندی برای Url")]
        [MaxLength(100, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string? UrlTitle { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        #region Relations
        public List<Project>? Projects { get; set; }
        #endregion
    }
}
