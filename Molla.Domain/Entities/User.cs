using Microsoft.AspNetCore.Identity;
using Molla.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities
{
    public class User : IdentityUser,IEntity
    {

    }
    public class Address
    {
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string FullAddress { get; set; }
        public string PostalCode { get; set; }
    }
}
