using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.DataLayer.Entities.Owner
{
    public class Social
    {
        [Key]
        public int SocialId { get; set; }

        [Display(Name = "عنوان شبکه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Title { get; set; }

        [Display(Name = "لینک شبکه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength]
        public string LinkAddress { get; set; }

        [Display(Name = "آیکون شبکه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public bool IsDeleted { get; set; }
    }
}
