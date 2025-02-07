using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.DataLayer.Entities.Owner
{
    public class HistoryLine
    {
        public HistoryLine()
        {

        }

        [Key]
        public int HistoryLineId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "{0} نمی‌تواند بیشتر از {1} کاراکتر باشد.")]
        public string Title { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Display(Name = "اولویت")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد.")]
        public int Priority { get; set; } = 1;


        #region Relations
        public ICollection<History> Histories { get; set; } = new List<History>();
        #endregion
    }
}
