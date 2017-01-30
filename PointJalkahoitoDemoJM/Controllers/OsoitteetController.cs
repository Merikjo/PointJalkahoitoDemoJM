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
    public class OsoitteetController : Controller
    {
        private JohaMeriSQL1Entities db = new JohaMeriSQL1Entities();

        // GET: Osoitteet
        public ActionResult Index()
        {
            var osoite = db.Osoite.Include(o => o.Asiakas1).Include(o => o.Henkilokunta1).Include(o => o.Hoitaja1).Include(o => o.Toimipiste);
            return View(osoite.ToList());
        }

        // GET: Osoitteet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoite osoite = db.Osoite.Find(id);
            if (osoite == null)
            {
                return HttpNotFound();
            }
            return View(osoite);
        }

        // GET: Osoitteet/Create
        public ActionResult Create()
        {
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi");
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi");
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi");
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi");
            return View();
        }

        // POST: Osoitteet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Osoite_id,Katuosoite,Postinumero,Postitoimipaikka,Asiakas_id,Hoitaja_id,Henkilokunta_id,Toimipiste_id")] Osoite osoite)
        {
            if (ModelState.IsValid)
            {
                db.Osoite.Add(osoite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", osoite.Asiakas_id);
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi", osoite.Henkilokunta_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", osoite.Hoitaja_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", osoite.Toimipiste_id);
            return View(osoite);
        }

        // GET: Osoitteet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoite osoite = db.Osoite.Find(id);
            if (osoite == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", osoite.Asiakas_id);
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi", osoite.Henkilokunta_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", osoite.Hoitaja_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", osoite.Toimipiste_id);
            return View(osoite);
        }

        // POST: Osoitteet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Osoite_id,Katuosoite,Postinumero,Postitoimipaikka,Asiakas_id,Hoitaja_id,Henkilokunta_id,Toimipiste_id")] Osoite osoite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osoite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", osoite.Asiakas_id);
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi", osoite.Henkilokunta_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", osoite.Hoitaja_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", osoite.Toimipiste_id);
            return View(osoite);
        }

        // GET: Osoitteet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osoite osoite = db.Osoite.Find(id);
            if (osoite == null)
            {
                return HttpNotFound();
            }
            return View(osoite);
        }

        // POST: Osoitteet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Osoite osoite = db.Osoite.Find(id);
            db.Osoite.Remove(osoite);
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
