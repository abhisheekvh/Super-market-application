﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClasses
{
    public class Product
    {
      
        public int ProductId { get; set; }
        [Required]
       
        public int CategoryId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double price { get; set; }

        
        public Category Category { get; set; }
    }
}
