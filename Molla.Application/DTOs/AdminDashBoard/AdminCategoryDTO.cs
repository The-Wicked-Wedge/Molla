﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.DTOs.AdminDashBoard
{
	public class AdminCategroyDTO
	{
		public Guid id { get; set; }
		public string name { get; set; }
        public List<string> categoryGroup { get; set; }
    }
}
