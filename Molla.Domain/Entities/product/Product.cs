using Molla.Domain.Common;
using Molla.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities.product
{
	public class Product : BaseEntity , IEntity
	{
		[Column(TypeName = "nvarchar(100)")]
		public string Name { get; set; }

		[Column(TypeName = "nvarchar(200)")]
		public string ShortDescription { get; set; }

		[Column(TypeName = "nvarchar(1000)")]
		public string Description { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Brand { get; set; }

		[Column(TypeName = "decimal(11, 2)")]
		public Decimal Price { get; set; }
		public int? DiscountPercent { get; set; }
		public Currency Currency { get; set; }
		public ProductEvents Status { get; set; }

		public Guid CategoryId { get; set; }
		public category.Category Category { get; set; }
		public ICollection<StockByColorSize> StockByColorSize { get; set;}
		public ICollection<Gallery> Gallery { get; set; }
    }
}
