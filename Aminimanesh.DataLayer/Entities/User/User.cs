using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.DataLayer.Entities.User
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        [EmailAddress(ErrorMessage = "فرمت ورودی {0} صحیح نمی‌باشد.")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength]
        public string Pasword { get; set; }
    }
}
