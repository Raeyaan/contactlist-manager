﻿using System.ComponentModel.DataAnnotations;

namespace ContactList.Models
{
    public class Category
    {
        
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
