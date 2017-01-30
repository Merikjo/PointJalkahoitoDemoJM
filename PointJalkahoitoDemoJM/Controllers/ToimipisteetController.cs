using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointJalkahoitoDemoJM.Models;

namespace PointJalkahoitoDemoJM.Controllers
{
    public class ToimipisteetController : Controller
    {
        private JohaMeriSQL1Entities db = new JohaMeriSQL1Entities();

        // GET: Toimipisteet
        public ActionResult Index()
        {
            var toimipiste = db.Toimipiste.Include(t => t.Hoitopaikka1).Include(t => t.Osoite1).Include(t => t.Puhelin1);
            return View(toimipiste.ToList());
        }

        // GET: Toimipisteet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toimipiste toimipiste = db.Toimipiste.Find(id);
            if (toimipiste == null)
            {
                return HttpNotFound();
            }
            return View(toimipiste);
        }

        // GET: Toimipisteet/Create
        public ActionResult Create()
        {
            ViewBag.Hoitopaikka_id = new SelectList(db.Hoitopaikka, "Hoitopaikka_id", "Hoitopaikan_Nimi");
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite");
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1");
            return View();
        }

        // POST: Toimipisteet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Toimipiste_id,Toimipiste_Nimi,Huomio,Hoitopaikka_id,Osoite_id,Puhelin_id")] Toimipiste toimipiste)
        {
            if (ModelState.IsValid)
            {
                db.Toimipiste.Add(toimipiste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hoitopaikka_id = new SelectList(db.Hoitopaikka, "Hoitopaikka_id", "Hoitopaikan_Nimi", toimipiste.Hoitopaikka_id);
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", toimipiste.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", toimipiste.Puhelin_id);
            return View(toimipiste);
        }

        // GET: Toimipisteet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toimipiste toimipiste = db.Toimipiste.Find(id);
            if (toimipiste == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hoitopaikka_id = new SelectList(db.Hoitopaikka, "Hoitopaikka_id", "Hoitopaikan_Nimi", toimipiste.Hoitopaikka_id);
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", toimipiste.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", toimipiste.Puhelin_id);
            return View(toimipiste);
        }

        // POST: Toimipisteet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Toimipiste_id,Toimipiste_Nimi,Huomio,Hoitopaikka_id,Osoite_id,Puhelin_id")] Toimipiste toimipiste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toimipiste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hoitopaikka_id = new SelectList(db.Hoitopaikka, "Hoitopaikka_id", "Hoitopaikan_Nimi", toimipiste.Hoitopaikka_id);
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", toimipiste.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", toimipiste.Puhelin_id);
            return View(toimipiste);
        }

        // GET: Toimipisteet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toimipiste toimipiste = db.Toimipiste.Find(id);
            if (toimipiste == null)
            {
                return HttpNotFound();
            }
            return View(toimipiste);
        }

        // POST: Toimipisteet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Toimipiste toimipiste = db.Toimipiste.Find(id);
            db.Toimipiste.Remove(toimipiste);
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
