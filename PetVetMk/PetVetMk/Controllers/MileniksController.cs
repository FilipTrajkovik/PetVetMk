using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetVetMk.Models;

namespace PetVetMk.Controllers
{
    public class MileniksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mileniks
        public ActionResult Index()
        {
            return View(db.Milenici.ToList());
        }

        // GET: Mileniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Milenik milenik = db.Milenici.Find(id);
            if (milenik == null)
            {
                return HttpNotFound();
            }
            return View(milenik);
        }

        // GET: Mileniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mileniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MilenikIme,MilenikSopstvenik,MilenikDataRaganje,MilenikVid,MilenikRasa,MilenikBoja")] Milenik milenik)
        {
            if (ModelState.IsValid)
            {
                db.Milenici.Add(milenik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(milenik);
        }

        // GET: Mileniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Milenik milenik = db.Milenici.Find(id);
            if (milenik == null)
            {
                return HttpNotFound();
            }
            return View(milenik);
        }

        // POST: Mileniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MilenikIme,MilenikSopstvenik,MilenikDataRaganje,MilenikVid,MilenikRasa,MilenikBoja")] Milenik milenik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(milenik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(milenik);
        }

        // GET: Mileniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Milenik milenik = db.Milenici.Find(id);
            if (milenik == null)
            {
                return HttpNotFound();
            }
            return View(milenik);
        }

        // POST: Mileniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Milenik milenik = db.Milenici.Find(id);
            db.Milenici.Remove(milenik);
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
    }
}
