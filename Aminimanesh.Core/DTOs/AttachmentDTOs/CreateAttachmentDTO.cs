using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.AttachmentDTOs
{
    public class CreateAttachmentDTO
    {
        [Required]
        public int ProjectId { get; set; }

        [Display(Name = "نام فایل")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength]
        public string FileName { get; set; }

        [Display(Name = "نام نمایشی فایل")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string ShowName { get; set; }

        [Display(Name = "توضیح کوتاه فایل")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string ShortDescription { get; set; } = null!;

        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public bool IsImage { get; set; }

        [Display(Name = "اولویت")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public int Priority { get; set; } = 1;
    }
}
