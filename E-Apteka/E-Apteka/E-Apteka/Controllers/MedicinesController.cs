using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_Apteka.Models;

namespace E_Apteka.Controllers
{
    [Authorize]
    public class MedicinesController : Controller
    {
        private MedicineContext db = new MedicineContext();
        public List<Medicine> lekovi = new List<Medicine>();
        // GET: Medicines
        public ActionResult Index()
        {
            return View(db.Medicines.ToList());
        }

        // GET: Medicines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // GET: Medicines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Producer,Price,Name")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Medicines.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicine);
        }

        // GET: Medicines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Producer,Price,Name")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicine medicine = db.Medicines.Find(id);
            db.Medicines.Remove(medicine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [Authorize(Roles ="User")]
        public ActionResult Naracaj()
        {
            Pharmacy model = new Pharmacy();
            return View(model);
            
        }

        [HttpPost]
        public ActionResult Naracaj(Pharmacy p)
        {
            
            List<Item> cart = (List<Item>)Session["cart"];
            Random r = new Random();
            int idOrder = r.Next();
            foreach (var item in cart)
            {
                OrderItem model = new OrderItem() { Medicine = item.medicine.Name, Pharmacy = p.selectedPharmacy, OrderId = idOrder };
                db.Orders.Add(model);
                db.SaveChanges();
            }

            Session["cart"] = null;
            return RedirectToAction("ZavrsiNaracka");
        }
        [Authorize(Roles = "User")]
        public ActionResult ZavrsiNaracka()
        {
            return View();
        }

        [Authorize(Roles ="Administrator")]
        public ActionResult ListOrders()
        {
            List<OrderItem> listOrders = db.Orders.ToList();
            List<Order> orders = new List<Order>();
            List<int> orderIds = new List<int>();
            foreach (var item in listOrders)
            {
                if (!orderIds.Contains(item.OrderId))
                {
                    orderIds.Add(item.OrderId);
                    orders.Add(new Order() { orderId = item.OrderId, pharmacy = item.Pharmacy });
                }
            }
            foreach (var item in listOrders)
            {
                orders.Find(m => m.orderId == item.OrderId).medicines.Add(item.Medicine);
            }

            return View(orders);
        }


    }
}
