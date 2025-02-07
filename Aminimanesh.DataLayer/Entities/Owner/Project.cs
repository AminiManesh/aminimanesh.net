using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.DataLayer.Entities.Owner
{
    public class Project
    {
        public Project()
        {

        }


        [Key]
        public int ProjectId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Display(Name = "عنوان پروژه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(100, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Title { get; set; }

        [Display(Name = " عنوان پروژه برای Url")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string UrlTitle { get; set; }

        [Display(Name = "توضیحات پروژه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public string Description { get; set; }

        [Display(Name = "توضیح مختصر پروژه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string ShortDescription { get; set; }

        [Display(Name = "کاور پروژه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Thumbnail { get; set; }

        [Display(Name = "تاریخ شروع پروژه")]
        public string OrderDate { get; set; }

        [Display(Name = "تاریخ اتمام")]
        public string FinishDate { get; set; }

        [Display(Name = "وضعیت پروژه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public bool IsFinished { get; set; }

        [Display(Name = "نام مشتری پروژه")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public string CustomerName { get; set; }

        [Display(Name = "دسته‌بندی")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public string WebsiteCategory { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [MaxLength]
        [Display(Name = "لینک مشاهده پروژه")]
        [Url(ErrorMessage = "فرمت {0} صحیح نیست.")]
        public string? Url { get; set; }

        [Display(Name = "اولویت")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public int Priority { get; set; } = 1;

        #region Relations
        public List<Attachment> Attachments { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        #endregion
    }
}
