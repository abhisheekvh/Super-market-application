using System;
using System.ComponentModel.DataAnnotations;

namespace SharedClasses
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string name { get; set; }
        public string Description { get; set; }
    }
}
