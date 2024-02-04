using Molla.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities.category
{
	public class Category : BaseEntity , IEntity
	{
        public string Name { get; set; }
        public Guid CategoryGroupId { get; set; }


        public CategoryGroup CategoryGroup { get; set; }

    }
}
