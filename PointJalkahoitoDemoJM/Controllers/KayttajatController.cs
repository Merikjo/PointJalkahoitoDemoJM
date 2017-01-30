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
    public class KayttajatController : Controller
    {
        private JohaMeriSQL1Entities db = new JohaMeriSQL1Entities();

        // GET: Kayttajat
        public ActionResult Index()
        {
            var kayttaja = db.Kayttaja.Include(k => k.Asiakas1).Include(k => k.Henkilokunta1).Include(k => k.Hoitaja1);
            return View(kayttaja.ToList());
        }

        // GET: Kayttajat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kayttaja kayttaja = db.Kayttaja.Find(id);
            if (kayttaja == null)
            {
                return HttpNotFound();
            }
            return View(kayttaja);
        }

        // GET: Kayttajat/Create
        public ActionResult Create()
        {
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi");
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi");
            ViewBag.Hoitaja_Id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi");
            return View();
        }

        // POST: Kayttajat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Käyttäjä_id,Käyttäjätunnus,Salasana,Asiakas_id,Hoitaja_Id,Henkilokunta_id")] Kayttaja kayttaja)
        {
            if (ModelState.IsValid)
            {
                db.Kayttaja.Add(kayttaja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", kayttaja.Asiakas_id);
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi", kayttaja.Henkilokunta_id);
            ViewBag.Hoitaja_Id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", kayttaja.Hoitaja_Id);
            return View(kayttaja);
        }

        // GET: Kayttajat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kayttaja kayttaja = db.Kayttaja.Find(id);
            if (kayttaja == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", kayttaja.Asiakas_id);
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi", kayttaja.Henkilokunta_id);
            ViewBag.Hoitaja_Id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", kayttaja.Hoitaja_Id);
            return View(kayttaja);
        }

        // POST: Kayttajat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Käyttäjä_id,Käyttäjätunnus,Salasana,Asiakas_id,Hoitaja_Id,Henkilokunta_id")] Kayttaja kayttaja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kayttaja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", kayttaja.Asiakas_id);
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi", kayttaja.Henkilokunta_id);
            ViewBag.Hoitaja_Id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", kayttaja.Hoitaja_Id);
            return View(kayttaja);
        }

        // GET: Kayttajat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kayttaja kayttaja = db.Kayttaja.Find(id);
            if (kayttaja == null)
            {
                return HttpNotFound();
            }
            return View(kayttaja);
        }

        // POST: Kayttajat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kayttaja kayttaja = db.Kayttaja.Find(id);
            db.Kayttaja.Remove(kayttaja);
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
