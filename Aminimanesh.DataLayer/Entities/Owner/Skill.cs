using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.DataLayer.Entities.Owner
{
    public class Skill
    {
        public Skill()
        {

        }


        [Key]
        public int SkillId { get; set; }

        [Display(Name = "عنوان مهارت")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Title { get; set; }

        [Display(Name = "درصد تسلط")]
        public int? Value { get; set; }

        [Display(Name = "اولویت")]
        public int? Priority { get; set; }

        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public bool IsSideSkill { get; set; }
    }
}
