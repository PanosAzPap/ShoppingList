using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingList.Controllers
{
    public class HomeController : Controller
    {
        public static List<ItemVM> ItemsDB;
        public HomeController()
        {
            Random r = new Random();
            if (ItemsDB == null)
            {
                ItemsDB = new List<ItemVM>();
                ItemsDB.Add(new ItemVM() { Id = 1, User = "mnikolaidis", Text = "sdsfgsfdg", Link = "", Price = r.Next(5, 50), Priority = r.Next(1, 4) });
                ItemsDB.Add(new ItemVM() { Id = 2, User = "mnikolaidis", Text = "sdsfgsfdg", Link = "http://www.google.com", Price = r.Next(5, 50), Priority = r.Next(1, 4) });
                ItemsDB.Add(new ItemVM() { Id = 3, User = "mnikolaidis", Text = "sdsfgsfdg", Link = "", Price = r.Next(5, 50), Priority = r.Next(1, 4) });
                ItemsDB.Add(new ItemVM() { Id = 4, User = "John", Text = "sdsfgsfdg", Link = "", Price = r.Next(5, 50), Priority = r.Next(1, 4) });
                ItemsDB.Add(new ItemVM() { Id = 5, User = "John", Text = "sdsfgsfdg", Link = "http://www.google.com", Price = r.Next(5, 50), Priority = r.Next(1, 4) });
                ItemsDB.Add(new ItemVM() { Id = 6, User = "John", Text = "sdsfgsfdg", Link = "", Price = r.Next(5, 50), Priority = r.Next(1, 4) });
                ItemsDB.Add(new ItemVM() { Id = 7, User = "John", Text = "sdsfgsfdg", Link = "http://www.google.com", Price = r.Next(5, 50), Priority = r.Next(1, 4) });
            }
        }

        public ActionResult Seed()
        {
            using (AppContext db = new AppContext())
            {
                foreach (var item in ItemsDB)
                {
                    ItemDTO newItem = new ItemDTO();
                    newItem.Text = item.Text;
                    newItem.Link = item.Link;
                    newItem.Price = item.Price;
                    newItem.Priority = item.Priority;

                    db.Items.Add(newItem);
                }

                db.SaveChanges();
            }

            return RedirectToAction("List", "Home");
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult List()
        {
            if(Session["Counter"] == null)
            {
                Session["Counter"] = 1;
            }
            else
            {
                object counterObj = Session["Counter"];
                int counter = (int)counterObj;
                Session["Counter"] = counter + 1;
            }

            List<ItemVM> Items = ItemsDB;

            using (AppContext db = new AppContext())
            {
                List<ItemDTO> items = db.Items.ToList();

                List<ItemVM> itemsVm = items.Select(i => new ItemVM
                {
                    Id = i.Id,
                    Link = i.Link,
                    Price = i.Price,
                    Priority = i.Priority,
                    Text = i.Text
                }).ToList();

                return View(itemsVm);

            }

            //if(User.Identity.IsAuthenticated)
            //{
            //    return View(Items.Where(i => i.User == User.Identity.Name).ToList());
            //}
            //else
            //{
            //    return View(Items);
            //}
        }

        public ActionResult Edit(int id)
        {
            //TODO: Fetch item with id=id from DB

            using (AppContext db = new AppContext())
            {
                var item = db.Items.FirstOrDefault(x => x.Id == id);
                if(item != null)
                {
                    ItemVM vm = new ItemVM();
                    vm.Id = item.Id;
                    vm.Text = item.Text;
                    vm.Link = item.Link;
                    vm.Price = item.Price;
                    vm.Priority = item.Priority;
                    return View(vm);
                }
                else
                {
                    return null;
                }

            }

            //ItemVM Item = ItemsDB.FirstOrDefault(x => x.Id == id);
            //if (Item == null)
            //{
            //    return null;
            //}

            //return View(Item);
        }

        [HttpPost]
        public ActionResult EditSubmit(ItemVM itemWeb)
        {
            //TODO: Get the data from the action and go to db and bla bla many birds.
            ItemVM Item = ItemsDB.FirstOrDefault(x => x.Id == itemWeb.Id);
            Item.Text = itemWeb.Text;
            Item.Price = itemWeb.Price;
            Item.Priority = itemWeb.Priority;
            Item.Link = itemWeb.Link;

            return RedirectToAction("List", "Home");
        }

    }
}