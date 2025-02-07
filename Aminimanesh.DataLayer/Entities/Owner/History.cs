using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.DataLayer.Entities.Owner
{
    public class History
    {
        public History()
        {

        }


        [Key]
        public int HistoryId { get; set; }

        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public int HistoryLineId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Title { get; set; }

        [Display(Name = "صفت")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Adjective { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(200, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Description { get; set; }

        [Display(Name = "زمان شروع")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string StartTime { get; set; }

        [Display(Name = "زمان پایان")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string? EndTime { get; set; }

        [Display(Name = "به پایان رسیده ؟")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public bool Finished { get; set; }

        [Display(Name = "متن لینک")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string? LinkAddress { get; set; }

        [Display(Name = "مسیر لینک")]
        public string? LinkLabel { get; set; }

        [Display(Name = "اولویت")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public int Priority { get; set; } = 1;

        #region Relations
        public virtual HistoryLine? HistoryLine { get; set; }
        #endregion
    }
}
