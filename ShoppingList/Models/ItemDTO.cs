using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Models
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public int Priority { get; set; }
        public decimal Price { get; set; }
    }
}