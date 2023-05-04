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
    public class VeterinarnaAmbulantaRatingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VeterinarnaAmbulantaRatings
        public ActionResult Index()
        {
            return View(db.VeterinarnaAmbulantaRatings.ToList());
        }

        // GET: VeterinarnaAmbulantaRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeterinarnaAmbulantaRating veterinarnaAmbulantaRating = db.VeterinarnaAmbulantaRatings.Find(id);
            if (veterinarnaAmbulantaRating == null)
            {
                return HttpNotFound();
            }
            return View(veterinarnaAmbulantaRating);
        }

        // GET: VeterinarnaAmbulantaRatings/Create
        public ActionResult Create(VeterinarnaAmbulantaRating ambulantaRating)
        { 
            if (db.VeterinarnaAmbulantaRatings.Where(v => v.korisnikId == ambulantaRating.korisnikId && v.ambulantaId == ambulantaRating.ambulantaId).Count() == 1)
            {
                var veterinarnaAmbulantaRating = db.VeterinarnaAmbulantaRatings.Where(v => v.korisnikId == ambulantaRating.korisnikId && v.ambulantaId == ambulantaRating.ambulantaId).First();
                db.VeterinarnaAmbulantaRatings.Remove(veterinarnaAmbulantaRating);
                db.SaveChanges();
            }
            db.VeterinarnaAmbulantaRatings.Add(ambulantaRating);
            db.SaveChanges();
            return View();
        }

        // POST: VeterinarnaAmbulantaRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ambulantaId,korisnikId,rating")] VeterinarnaAmbulantaRating veterinarnaAmbulantaRating)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.VeterinarnaAmbulantaRatings.Add(veterinarnaAmbulantaRating);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(veterinarnaAmbulantaRating);
        //}

        // GET: VeterinarnaAmbulantaRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeterinarnaAmbulantaRating veterinarnaAmbulantaRating = db.VeterinarnaAmbulantaRatings.Find(id);
            if (veterinarnaAmbulantaRating == null)
            {
                return HttpNotFound();
            }
            return View(veterinarnaAmbulantaRating);
        }

        // POST: VeterinarnaAmbulantaRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ambulantaId,korisnikId,rating")] VeterinarnaAmbulantaRating veterinarnaAmbulantaRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veterinarnaAmbulantaRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinarnaAmbulantaRating);
        }

        // GET: VeterinarnaAmbulantaRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeterinarnaAmbulantaRating veterinarnaAmbulantaRating = db.VeterinarnaAmbulantaRatings.Find(id);
            if (veterinarnaAmbulantaRating == null)
            {
                return HttpNotFound();
            }
            return View(veterinarnaAmbulantaRating);
        }

        // POST: VeterinarnaAmbulantaRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VeterinarnaAmbulantaRating veterinarnaAmbulantaRating = db.VeterinarnaAmbulantaRatings.Find(id);
            db.VeterinarnaAmbulantaRatings.Remove(veterinarnaAmbulantaRating);
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
