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
    public class VeterinarenDoktorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VeterinarenDoktors
        public ActionResult Index()
        {
            return View(db.VeterinarniDoktori.ToList());
        }

        // GET: VeterinarenDoktors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeterinarenDoktor veterinarenDoktor = db.VeterinarniDoktori.Find(id);
            if (veterinarenDoktor == null)
            {
                return HttpNotFound();
            }
            return View(veterinarenDoktor);
        }

        // GET: VeterinarenDoktors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VeterinarenDoktors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DoktorImePrezime,DoktorOpstina,DoktorTelBroj,DoktorEmail")] VeterinarenDoktor veterinarenDoktor)
        {
            if (ModelState.IsValid)
            {
                db.VeterinarniDoktori.Add(veterinarenDoktor);
                db.SaveChanges();
                return RedirectToAction("InsertNewDoctor", "VeterinarnaAmbulantas", new { id = veterinarenDoktor.Id });
            }

            return View(veterinarenDoktor);
        }

        // GET: VeterinarenDoktors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeterinarenDoktor veterinarenDoktor = db.VeterinarniDoktori.Find(id);
            if (veterinarenDoktor == null)
            {
                return HttpNotFound();
            }
            return View(veterinarenDoktor);
        }

        // POST: VeterinarenDoktors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DoktorImePrezime,DoktorOpstina,DoktorTelBroj,DoktorEmail")] VeterinarenDoktor veterinarenDoktor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veterinarenDoktor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinarenDoktor);
        }

        // GET: VeterinarenDoktors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeterinarenDoktor veterinarenDoktor = db.VeterinarniDoktori.Find(id);
            if (veterinarenDoktor == null)
            {
                return HttpNotFound();
            }
            return View(veterinarenDoktor);
        }

        // POST: VeterinarenDoktors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VeterinarenDoktor veterinarenDoktor = db.VeterinarniDoktori.Find(id);
            db.VeterinarniDoktori.Remove(veterinarenDoktor);
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
