using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksSales.Core.Abstract
{
    public interface ISalesOrderRepository : IGenericRepository<SalesOrder>
    {
        IEnumerable<decimal> GetAllLineTotal();
        IEnumerable<SalesOrder> GetAllProductSales(int prodId);
    }
}
