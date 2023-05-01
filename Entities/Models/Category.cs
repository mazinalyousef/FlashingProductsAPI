﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }


        public virtual ICollection<Product> Products { get; set; }

    }
}
