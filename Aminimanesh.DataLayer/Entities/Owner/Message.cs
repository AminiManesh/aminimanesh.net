using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.DataLayer.Entities.Owner
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public int? IpApiResponseId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(100, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string SenderName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        [EmailAddress(ErrorMessage = "فرمت ورودی {0} صحیح نمی‌باشد.")]
        public string SenderEmail { get; set; }

        [Display(Name = "موبایل")]
        [MaxLength(200, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string? SenderMobile { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength]
        public string Content { get; set; }

        [Display(Name = "تاریخ ارسال")]
        public DateTime? SendDate { get; set; }

        [Display(Name = "RemoteIPAddress")]
        [MaxLength]
        public string? RemoteIPAddress { get; set; }

        [Display(Name = "ActualIPAddress")]
        [MaxLength]
        public string? ActualIPAddress { get; set; }

        [Display(Name = "CloudflareActualIPAddress")]
        [MaxLength]
        public string? CloudflareActualIPAddress { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }

        #region Relations
        [ForeignKey("IpApiResponseId")]
        public IpApiResponse? IpApiResponse { get; set; }
        #endregion
    }
}
