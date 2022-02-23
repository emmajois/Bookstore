﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Book boo, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == boo.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = boo,
                    Quantity = qty,
                    Price = boo.Price
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Price);
            return sum;
        }
    }


    public class BasketLineItem
    {
        public int LineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}

