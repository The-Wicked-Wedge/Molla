using Molla.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities.category
{
	public class CategoryGroup : BaseEntity, IEntity
	{
        public string Name { get; set; }


		//Relations:
		public ICollection<Category> Categories { get; set;}
    }
}
