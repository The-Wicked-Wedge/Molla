using Molla.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.ValueObjects
{

    public class Tags:BaseValueObject
    {
        public Tags(string tag1,string tag2,string tag3,string tag4)
        {
            if(string.IsNullOrEmpty(tag1)) throw new ArgumentNullException(nameof(tag1));
            if(string.IsNullOrEmpty(tag2)) throw new ArgumentNullException(nameof(tag2));
            if(string.IsNullOrEmpty(tag3)) throw new ArgumentNullException(nameof(tag3));
            if(string.IsNullOrEmpty(tag4)) throw new ArgumentNullException(nameof(tag4));

            Tag1 = tag1;
            Tag2 = tag2;
            Tag3 = tag3;
            Tag4 = tag4;
        }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public string Tag4 { get; set; }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Tag1;
            yield return Tag2;
            yield return Tag3;
            yield return Tag4;
        }
    }
}
