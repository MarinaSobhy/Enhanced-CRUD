﻿using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

    }
}
