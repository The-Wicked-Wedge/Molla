using System.ComponentModel.DataAnnotations;

namespace Molla.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
