﻿namespace Market.Api.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryResource Category { get; set; }
    }
}