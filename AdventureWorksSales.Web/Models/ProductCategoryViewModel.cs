using AdventureWorksSales.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class ProductCategoryViewModel
    {
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}