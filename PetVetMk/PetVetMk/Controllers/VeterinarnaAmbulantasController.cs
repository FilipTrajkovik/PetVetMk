using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetVetMk.Models;
using PagedList;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace PetVetMk.Controllers
{
    public class VeterinarnaAmbulantasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VeterinarnaAmbulantas
        public ActionResult Index(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var ambulanti = from a in db.VeterinarniAmbulanti select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                ambulanti = ambulanti.Where(s => s.VetAmbulantaIme.Contains(searchString));
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(ambulanti.OrderBy(i => i.Id).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Pocetna()
        {
            return View();
        }

        // GET: VeterinarnaAmbulantas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeterinarnaAmbulanta veterinarnaAmbulanta = db.VeterinarniAmbulanti.Find(id);
            if (veterinarnaAmbulanta == null)
            {
                return HttpNotFound();
            }
            return View(veterinarnaAmbulanta);
        }

        // GET: VeterinarnaAmbulantas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VeterinarnaAmbulantas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VetAmbulantaIme,VetAmbulantaLogoUrl,VetAmbulantaOpstina,VetAmbulantaAdresa,VetAmbulantaRabotnoVreme,VetAmbulantaEmail,VetAmbulantaTelBroj,VetAmbKratokOpis,VetAmbDolgOpis")] VeterinarnaAmbulanta veterinarnaAmbulanta)
        {
            if (ModelState.IsValid)
            {
                db.VeterinarniAmbulanti.Add(veterinarnaAmbulanta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(veterinarnaAmbulanta);
        }

        public ActionResult AddRating(int id, string userId, int rating)
        {
            VeterinarnaAmbulanta veterinarnaAmbulanta = db.VeterinarniAmbulanti.Find(id);
            VeterinarnaAmbulantaRating veterinarnaAmbulantaRating = new VeterinarnaAmbulantaRating();
            int number = 0;
            if (db.VeterinarnaAmbulantaRatings.ToList().Count > 0)
            {
                number = db.VeterinarnaAmbulantaRatings.ToList().Last().Id;
            }
            veterinarnaAmbulantaRating.Id = number + 1;
            veterinarnaAmbulantaRating.korisnikId = userId;
            veterinarnaAmbulantaRating.ambulantaId = id;
            veterinarnaAmbulantaRating.rating = rating;
            
            return RedirectToAction("Create", "VeterinarnaAmbulantaRatings", veterinarnaAmbulantaRating);
        }

        // GET: VeterinarnaAmbulantas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeterinarnaAmbulanta veterinarnaAmbulanta = db.VeterinarniAmbulanti.Find(id);
            if (veterinarnaAmbulanta == null)
            {
                return HttpNotFound();
            }
            return View(veterinarnaAmbulanta);
        }

        // POST: VeterinarnaAmbulantas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VetAmbulantaIme,VetAmbulantaLogoUrl,VetAmbulantaOpstina,VetAmbulantaAdresa,VetAmbulantaRabotnoVreme,VetAmbulantaEmail,VetAmbulantaTelBroj,VetAmbKratokOpis,VetAmbDolgOpis")] VeterinarnaAmbulanta veterinarnaAmbulanta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veterinarnaAmbulanta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinarnaAmbulanta);
        }

        // GET: VeterinarnaAmbulantas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeterinarnaAmbulanta veterinarnaAmbulanta = db.VeterinarniAmbulanti.Find(id);
            if (veterinarnaAmbulanta == null)
            {
                return HttpNotFound();
            }
            List<Milenik> milenici = db.Milenici.Where(m => m.veterinarnaAmbulanta.Id == veterinarnaAmbulanta.Id).ToList();
            milenici.ForEach(m => db.Milenici.Remove(m));
            List<VeterinarenDoktor> doktori = db.VeterinarniDoktori.Where(m => m.veterinarnaAmbulanta.Id == veterinarnaAmbulanta.Id).ToList();
            doktori.ForEach(m => db.VeterinarniDoktori.Remove(m));
            db.SaveChanges();

            db.VeterinarniAmbulanti.Remove(veterinarnaAmbulanta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //// POST: VeterinarnaAmbulantas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    VeterinarnaAmbulanta veterinarnaAmbulanta = db.VeterinarniAmbulanti.Find(id);
        //    //db.VeterinarniAmbulanti.Remove(veterinarnaAmbulanta);
        //    //db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult InsertNewDoctor(int? id)
        {
            //Debug.WriteLine(id);
            VeterinarnaAmbulanta veterinarnaAmbulanta = db.VeterinarniAmbulanti.Find(id);
            VeterinarenDoktor veterinarenDoktor = new VeterinarenDoktor();
            veterinarenDoktor.veterinarnaAmbulanta = veterinarnaAmbulanta;
            return View(veterinarenDoktor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertNewDoctor(VeterinarenDoktor veterinarenDoktor)
        {
            //var errors = ModelState.Where(x => x.Value.Errors.Any())
            //    .Select(x => new { x.Key, x.Value.Errors });
            //foreach (var error in errors)
            //{
            //    Debug.WriteLine(error);
            //}
            //Debug.WriteLine(ModelState.IsValid);

            if (ModelState.IsValid)
            {
                var veterinarnaambulanta = db.VeterinarniAmbulanti.Find(veterinarenDoktor.veterinarnaAmbulanta.Id);
                veterinarnaambulanta.vetdoktori.Add(veterinarenDoktor);
                veterinarenDoktor.veterinarnaAmbulanta = veterinarnaambulanta;
                db.VeterinarniDoktori.Add(veterinarenDoktor);
                db.SaveChanges();
                return Redirect("/VeterinarnaAmbulantas/Details/" + veterinarnaambulanta.Id);
            }

            return View(veterinarenDoktor);
        }

        public ActionResult RemoveDoctor(int? id, int? ambulantaId)
        {
            var doktor = db.VeterinarniDoktori.Find(id);
            var ambulanta = db.VeterinarniAmbulanti.Find(ambulantaId);
            ambulanta.vetdoktori.Remove(doktor);
            db.VeterinarniDoktori.Remove(doktor);
            db.SaveChanges();
            return Redirect("/VeterinarnaAmbulantas/Details/" + ambulantaId);
        }

        public ActionResult InsertNewPet(int? id)
        {
            //Debug.WriteLine(id);
            VeterinarnaAmbulanta veterinarnaAmbulanta = db.VeterinarniAmbulanti.Find(id);
            Milenik milenik  = new Milenik();
            milenik.veterinarnaAmbulanta = veterinarnaAmbulanta;
            return View(milenik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertNewPet(Milenik milenik)
        {
            //var errors = ModelState.Where(x => x.Value.Errors.Any())
            //    .Select(x => new { x.Key, x.Value.Errors });
            //foreach (var error in errors)
            //{
            //    Debug.WriteLine(error);
            //}
            //Debug.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid)
            {
                var veterinarnaambulanta = db.VeterinarniAmbulanti.Find(milenik.veterinarnaAmbulanta.Id);
                veterinarnaambulanta.milenici.Add(milenik);
                milenik.veterinarnaAmbulanta = veterinarnaambulanta;
                db.Milenici.Add(milenik);
                db.SaveChanges();
                return Redirect("/VeterinarnaAmbulantas/Details/" + veterinarnaambulanta.Id);
            }

            return View(milenik);
        }

        public ActionResult RemovePet(int? id, int? ambulantaId)
        {
            var milenik = db.Milenici.Find(id);
            var ambulanta = db.VeterinarniAmbulanti.Find(ambulantaId);
            ambulanta.milenici.Remove(milenik);
            db.Milenici.Remove(milenik);
            db.SaveChanges();
            return Redirect("/VeterinarnaAmbulantas/Details/" + ambulantaId);
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
