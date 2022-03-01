using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public interface IBookOrderRepository
    {
        IQueryable<BookOrder> BookOrders { get; }

        void SaveBookOrder(BookOrder bookOrder);
    }
}
