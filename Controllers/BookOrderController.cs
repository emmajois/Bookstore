using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class BookOrderController : Controller
    {
        private IBookOrderRepository repo { get; set; }
        private Basket basket { get; set; }
        public BookOrderController (IBookOrderRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new BookOrder());
        }

        [HttpPost]
        public IActionResult Checkout(BookOrder bookOrder)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                bookOrder.Lines = basket.Items.ToArray();
                repo.SaveBookOrder(bookOrder);
                basket.ClearBasket();

                return RedirectToPage("/ConfirmationCheckout");
            }
            else
            {
                return View();
            }
        }
    }
}
