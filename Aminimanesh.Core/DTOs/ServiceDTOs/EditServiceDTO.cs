using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.DTOs.ServiceDTOs
{
    public class EditServiceDTO
    {
        [Key]
        public int ServiceId { get; set; }

        [Display(Name = "عنوان سرویس")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Title { get; set; }

        [Display(Name = "توضیحات سرویس")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public string Description { get; set; }

        [Display(Name = "اولویت")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public int Priority { get; set; } = 1;
    }
}
