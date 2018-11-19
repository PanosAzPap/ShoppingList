using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Models
{
    public class ItemVM
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public int Priority { get; set; }
        public decimal Price { get; set; }
        public string User { get; set; }

        public bool HasLink
        {
            get
            {
                return !String.IsNullOrEmpty(Link);
            }
        }

    }
}