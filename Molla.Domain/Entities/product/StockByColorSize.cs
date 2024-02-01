using Molla.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities.product
{
    public class StockByColorSize : BaseEntity , IEntity
    {
        public Guid ProductId { get; set; }
        public Guid SizeId { get; set; }
        public Guid ColorId { get; set; }
        public int Count { get; set; }

        //relation
        public Size Size { get; set; }
        public Color Color { get; set; }
        public Product Product { get; set; }
    }
}
