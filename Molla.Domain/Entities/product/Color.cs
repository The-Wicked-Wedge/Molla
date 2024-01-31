using Molla.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities.product
{
	public class Color : IEntity
	{
		[Key]
		public Guid ID { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		[Required]
		public string Name { get; set; }

        public ICollection<StockByColorSize> stockByColorSizes { get; set; }
    }
}
