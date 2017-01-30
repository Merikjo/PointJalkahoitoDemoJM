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
    public class HoitajatController : Controller
    {
        private JohaMeriSQL1Entities db = new JohaMeriSQL1Entities();

        // GET: Hoitajat
        public ActionResult Index()
        {
            var hoitaja = db.Hoitaja.Include(h => h.Asiakas1).Include(h => h.Osoite).Include(h => h.Puhelin).Include(h => h.Varaus).Include(h => h.Palvelu).Include(h => h.Kayttaja);
            return View(hoitaja.ToList());
        }

        // GET: Hoitajat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoitaja hoitaja = db.Hoitaja.Find(id);
            if (hoitaja == null)
            {
                return HttpNotFound();
            }
            return View(hoitaja);
        }

        // GET: Hoitajat/Create
        public ActionResult Create()
        {
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi");
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite");
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1");
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_Nimi");
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi");
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus");
            return View();
        }

        // POST: Hoitajat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Hoitaja_id,Etunimi,Sukunimi,Henkilotunnus,Huomiot,Sahkoposti,Käyttäjä_id,Osoite_id,Puhelin_id,Asiakas_id,Varaus_id,Palvelu_id")] Hoitaja hoitaja)
        {
            if (ModelState.IsValid)
            {
                db.Hoitaja.Add(hoitaja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", hoitaja.Asiakas_id);
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", hoitaja.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", hoitaja.Puhelin_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_Nimi", hoitaja.Varaus_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", hoitaja.Palvelu_id);
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", hoitaja.Käyttäjä_id);
            return View(hoitaja);
        }

        // GET: Hoitajat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoitaja hoitaja = db.Hoitaja.Find(id);
            if (hoitaja == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", hoitaja.Asiakas_id);
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", hoitaja.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", hoitaja.Puhelin_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_Nimi", hoitaja.Varaus_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", hoitaja.Palvelu_id);
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", hoitaja.Käyttäjä_id);
            return View(hoitaja);
        }

        // POST: Hoitajat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Hoitaja_id,Etunimi,Sukunimi,Henkilotunnus,Huomiot,Sahkoposti,Käyttäjä_id,Osoite_id,Puhelin_id,Asiakas_id,Varaus_id,Palvelu_id")] Hoitaja hoitaja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoitaja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", hoitaja.Asiakas_id);
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", hoitaja.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", hoitaja.Puhelin_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_Nimi", hoitaja.Varaus_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", hoitaja.Palvelu_id);
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", hoitaja.Käyttäjä_id);
            return View(hoitaja);
        }

        // GET: Hoitajat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoitaja hoitaja = db.Hoitaja.Find(id);
            if (hoitaja == null)
            {
                return HttpNotFound();
            }
            return View(hoitaja);
        }

        // POST: Hoitajat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hoitaja hoitaja = db.Hoitaja.Find(id);
            db.Hoitaja.Remove(hoitaja);
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
