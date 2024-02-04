using Molla.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities.product
{
	public class Gallery : BaseEntity , IEntity
	{
		public Guid ProductId { get; set; }
        public string ImagePath { get; set; }

		public bool IsOriginImage { get; set; }

		//relation
		public Product Product { get; set; }
    }
}
