using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;
using WebApplication15.Models;



namespace lab20.Controllers

{

    public class HomeController : Controller

    {

        public ActionResult Index()

        {

            return View();

        }



        public ActionResult Menu()

        {

            ViewBag.Message = "GC Menu.";



            return View();

        }



        public ActionResult Contact()

        {

            ViewBag.Message = "Your contact page.";



            return View();

        }
        public ActionResult showItems()

        {

            return View("show");

        }
        public ActionResult item()
        {
            return View();
        }

        public ActionResult register()

        {

            return View();

        }
        public ActionResult AddNewCustomer(User NewUser)
        {
            if(!ModelState.IsValid)
            {
                return View("../Shared/Error");
            }
            CofeeShopDBEntities UsersOrm = new CofeeShopDBEntities();
            UsersOrm.Users.Add(NewUser);
            UsersOrm.SaveChanges();
            ViewBag.itemlist = UsersOrm.Users.ToList();
            return View("item");
        }


        public ActionResult SearchByItemName(string ItemName)
        {
            CofeeShopDBEntities itemOrm = new CofeeShopDBEntities();
            ViewBag.itemlist = itemOrm.Items.Where(X => X.Name.Contains(ItemName)).ToList();

            return View("show");


        }


        public ActionResult displayItems()
        {
            CofeeShopDBEntities itemOrm = new CofeeShopDBEntities();
            ViewBag.itemlist = itemOrm.Items.ToList();


            return View("show");
        }



        public ActionResult UpdateItem(int itemID)
        {
            
            CofeeShopDBEntities Orm = new CofeeShopDBEntities();
            Item ItemToBeUpdated = Orm.Items.Find(itemID);

            ViewBag.ItemToBeUpdated = ItemToBeUpdated;

            return View("UpdateItem");
            
        }

        public ActionResult SaveChanges(Item NewItem)
                {
                     
        
                    if (!ModelState.IsValid)
                    {
                        
                        return View("../Shared/Error");
        
                    }
        
        
                    
                   CofeeShopDBEntities ORM = new CofeeShopDBEntities();
        
                   
                   ORM.Entry(ORM.Items.Find(NewItem.itemID)).
                       CurrentValues.SetValues(NewItem);
                   
                   ORM.SaveChanges();
       
        
                   return View("item");
               }




    }
    
}

