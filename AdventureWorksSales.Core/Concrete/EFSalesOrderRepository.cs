using AdventureWorksSales.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksSales.Core.Concrete
{
    public class EFSalesOrderRepository : GenericRepository<SalesOrder>, ISalesOrderRepository
    {
        public EFSalesOrderRepository(AdventureWorksSalesEntities ctx)
        {
            _context = ctx;

        }

        public IEnumerable<decimal> GetAllLineTotal()
        {
            var saleorderslinetotal = Query().Select(x => x.LineTotal);
            return saleorderslinetotal;
        }
        public IEnumerable<SalesOrder> GetAllProductSales(int prodId)
        {
            var model = Query().Where(x => x.ProductID == prodId);
            return model;
        }
    }
}
