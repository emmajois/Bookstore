using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EFBookOrderRepository : IBookOrderRepository
    {
        private BookstoreContext context;

        public EFBookOrderRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<BookOrder> BookOrders => context.BookOrders.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveBookOrder(BookOrder bookOrder)
        {
            context.AttachRange(bookOrder.Lines.Select(x => x.Book));
            if (bookOrder.BookId == 0)
            {
                context.BookOrders.Add(bookOrder);
            }

            context.SaveChanges();
        }
    }
}
