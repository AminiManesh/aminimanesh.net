using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.DataLayer.Entities.Owner
{
    public class Language
    {
        public Language()
        {

        }

        [Key]
        public int LanguageId { get; set; }

        [Display(Name = "نام زبان")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Title { get; set; }

        [Display(Name = "درصد تسلط")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public int Value { get; set; }
    }
}
