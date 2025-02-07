using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.DataLayer.Entities.Owner
{
    public class Owner
    {
        public Owner()
        {

        }


        [Key]
        public int OwnerId { get; set; }

        [Display(Name = "نام و نام‌خانوادگی")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(100, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string FullName { get; set; }

        [Display(Name = "لقب اصلی")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string FirstJob { get; set; }

        [Display(Name = "لقب فرعی")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string SecondJob { get; set; }

        [Display(Name = "نمایه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Avatar { get; set; }

        [Display(Name = "فایل رزومه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string CVFile { get; set; }

        [Display(Name = "کشور")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Country { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Province { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string City { get; set; }

        [Display(Name = "سن")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public int Age { get; set; }

        [Display(Name = "ایمیل دریافت پیام‌ها")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        [EmailAddress(ErrorMessage = "فرمت ورودی {0} صحیح نمی‌باشد.")]
        public string IncomeEmail { get; set; }


        #region Work Stats
        [Display(Name = "تجربه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public string ExperienceYears { get; set; }

        [Display(Name = "پروژه کامل شده")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public string CompletedProjects { get; set; }

        [Display(Name = "مشتری خوشحال")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public string SatisfiedCustomer { get; set; }

        [Display(Name = "جوایز و افتخارات")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public string Awards { get; set; }
        #endregion

        #region Contact Info
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        [EmailAddress(ErrorMessage = "فرمت ورودی {0} صحیح نمی‌باشد.")]
        public string Email { get; set; }

        [Display(Name = "تلگرام")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Telegram { get; set; }

        [Display(Name = "واتساپ")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Whatsapp { get; set; }

        [Display(Name = "اینستاگرام")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Instagram { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Mobile { get; set; }

        [Display(Name = "تلفن همراه 2")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Mobile2 { get; set; }
        #endregion
    }
}
