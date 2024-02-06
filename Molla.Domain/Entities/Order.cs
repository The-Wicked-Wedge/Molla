﻿using Molla.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Molla.Domain.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public string UserId{ get; set; }
        public Guid ProductId { get; set; }
        public float Price { get; set; }
        public bool Completed { get; set; }
    }
}