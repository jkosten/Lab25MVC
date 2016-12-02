using Lab25MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab25MVC.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            NorthwindEntities db = new NorthwindEntities();
            List<Customer> customerList = db.Customers.ToList();
            return View(customerList);
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            NorthwindEntities details = new NorthwindEntities();
            Customer customer = details.Customers.Find(id);
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                NorthwindEntities db = new NorthwindEntities();
                Customer newCustomer = new Customer();
                newCustomer.CompanyName = collection["CompanyName"];
                newCustomer.ContactName = collection["ContactName"];
                newCustomer.ContactTitle = collection["ContactTitle"];
                newCustomer.Address = collection["Address"];
                newCustomer.City = collection["City"];
                newCustomer.Region = collection["Region"];
                newCustomer.PostalCode = collection["PostalCode"];
                newCustomer.Country = collection["Country"];
                newCustomer.Phone = collection["Phone"];
                newCustomer.Fax = collection["Fax"];
                newCustomer.CustomerID = collection["CustomerID"];
                db.Customers.Add(newCustomer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.InnerException;
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            NorthwindEntities db = new NorthwindEntities();
            return View(db.Customers.Find(id));
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                NorthwindEntities db = new NorthwindEntities();
                Customer EditCustomer = db.Customers.Find(id);
                EditCustomer.CompanyName = collection["CompanyName"];
                EditCustomer.ContactName = collection["ContactName"];
                EditCustomer.ContactTitle = collection["ContactTitle"];
                EditCustomer.Address = collection["Address"];
                EditCustomer.City = collection["City"];
                EditCustomer.Region = collection["Region"];
                EditCustomer.PostalCode = collection["PostalCode"];
                EditCustomer.Country = collection["Country"];
                EditCustomer.Phone = collection["Phone"];
                EditCustomer.Fax = collection["Fax"];
                EditCustomer.CustomerID = collection["CustomerID"];
                db.SaveChanges();

                return RedirectToAction("Index");
                
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            NorthwindEntities db = new NorthwindEntities();
            return View(db.Customers.Find(id));
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                NorthwindEntities db = new NorthwindEntities();

                var foundCustomer = db.Customers.Find(id);
                db.Customers.Remove(foundCustomer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
