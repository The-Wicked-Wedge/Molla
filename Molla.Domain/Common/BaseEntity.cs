using System.ComponentModel.DataAnnotations;

namespace Molla.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid ID { get; set; }
        [Display(Name = "Create date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:MM AM/PM}")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Update date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:MM AM/PM}")]
        public DateTime? UpdateDate { get; set; }
    }
}
