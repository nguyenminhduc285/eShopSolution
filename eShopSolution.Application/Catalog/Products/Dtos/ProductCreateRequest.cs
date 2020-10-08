using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace eShopSolution.Application.Catalog.Products.Dtos
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
