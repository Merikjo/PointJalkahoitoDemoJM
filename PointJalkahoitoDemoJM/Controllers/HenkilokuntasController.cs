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
    public class HenkilokuntasController : Controller
    {
        private JohaMeriSQL1Entities db = new JohaMeriSQL1Entities();

        // GET: Henkilokuntas
        public ActionResult Index()
        {
            var henkilokunta = db.Henkilokunta.Include(h => h.Osoite).Include(h => h.Puhelin).Include(h => h.Hoitaja).Include(h => h.Varaus).Include(h => h.Palvelu).Include(h => h.Kayttaja);
            return View(henkilokunta.ToList());
        }

        // GET: Henkilokuntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilokunta henkilokunta = db.Henkilokunta.Find(id);
            if (henkilokunta == null)
            {
                return HttpNotFound();
            }
            return View(henkilokunta);
        }

        // GET: Henkilokuntas/Create
        public ActionResult Create()
        {
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite");
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1");
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi");
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_Nimi");
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi");
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus");
            return View();
        }

        // POST: Henkilokuntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Henkilokunta_id,Etunimi,Sukunimi,Henkilotunnus,Huomiot,Sahkoposti,Käyttäjä_id,Osoite_id,Puhelin_id,Asiakas_id,Hoitaja_id,Varaus_id,Palvelu_id,Kurssi_id")] Henkilokunta henkilokunta)
        {
            if (ModelState.IsValid)
            {
                db.Henkilokunta.Add(henkilokunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", henkilokunta.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", henkilokunta.Puhelin_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", henkilokunta.Hoitaja_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_Nimi", henkilokunta.Varaus_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", henkilokunta.Palvelu_id);
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", henkilokunta.Käyttäjä_id);
            return View(henkilokunta);
        }

        // GET: Henkilokuntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilokunta henkilokunta = db.Henkilokunta.Find(id);
            if (henkilokunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", henkilokunta.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", henkilokunta.Puhelin_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", henkilokunta.Hoitaja_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_Nimi", henkilokunta.Varaus_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", henkilokunta.Palvelu_id);
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", henkilokunta.Käyttäjä_id);
            return View(henkilokunta);
        }

        // POST: Henkilokuntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Henkilokunta_id,Etunimi,Sukunimi,Henkilotunnus,Huomiot,Sahkoposti,Käyttäjä_id,Osoite_id,Puhelin_id,Asiakas_id,Hoitaja_id,Varaus_id,Palvelu_id,Kurssi_id")] Henkilokunta henkilokunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(henkilokunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", henkilokunta.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", henkilokunta.Puhelin_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", henkilokunta.Hoitaja_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_Nimi", henkilokunta.Varaus_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", henkilokunta.Palvelu_id);
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", henkilokunta.Käyttäjä_id);
            return View(henkilokunta);
        }

        // GET: Henkilokuntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilokunta henkilokunta = db.Henkilokunta.Find(id);
            if (henkilokunta == null)
            {
                return HttpNotFound();
            }
            return View(henkilokunta);
        }

        // POST: Henkilokuntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Henkilokunta henkilokunta = db.Henkilokunta.Find(id);
            db.Henkilokunta.Remove(henkilokunta);
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
