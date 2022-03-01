using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Infrastructure;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public ShoppingCartModel(IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddBook(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
        
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveBook(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { RetrnUrl = returnUrl });
        }
    }
}
