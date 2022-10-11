using AdventureWorksSales.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksSales.Core.Concrete
{
    public class EFProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository{ }
}
