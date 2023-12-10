using Molla.Domain.Common;
using Molla.Domain.Enums;
using Molla.Domain.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Molla.Domain.Entities
{
    public class Slider:BaseEntity,IEntity
    {

        public required string ImageSource { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string Tag { get; set; }
        public string? Link { get; set; }
        public ProductEvents? Events { get; set; }
    }
}
