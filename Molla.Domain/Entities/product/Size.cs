using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities.product
{
	public class Size
	{

		[Key]
		public Guid ID { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(6)")]
		public string Value { get; set; }

        public ICollection<StockByColorSize> stockByColorSizes { get; set; }
    }
}
