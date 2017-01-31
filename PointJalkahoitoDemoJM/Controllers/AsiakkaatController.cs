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
    public class AsiakkaatController : Controller
    {
        private JohaMeriSQL1Entities db = new JohaMeriSQL1Entities();

        // GET: Asiakkaat
        public ActionResult Index()
        {
            var asiakas = db.Asiakas.Include(a => a.Osoite).Include(a => a.Puhelin).Include(a => a.Hoitaja).Include(a => a.Varaus).Include(a => a.Palvelu).Include(a => a.Kayttaja);
            return View(asiakas.ToList());
        }


        //31.1.2017 Lisätty tietokantataulujen suodatukset:
        public ActionResult OrderByFirstName()
        {
            var asiakkaat = from a in db.Asiakas
                            orderby a.Etunimi ascending
                            select a;
            return View(asiakkaat);
        }
        public ActionResult OrderByLastName()
        {
            var asiakkaat = from a in db.Asiakas
                            orderby a.Sukunimi ascending
                            select a;
            return View(asiakkaat);
        }//23.5.2016 Lisätty
    

        // GET: Asiakkaat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakas asiakas = db.Asiakas.Find(id);
            if (asiakas == null)
            {
                return HttpNotFound();
            }
            return View(asiakas);
        }

        // GET: Asiakkaat/Create
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

        // POST: Asiakkaat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakas_id,Etunimi,Sukunimi,Henkilotunnus,Huomiot,Sahkoposti,Käyttäjä_id,Osoite_id,Puhelin_id,Hoitaja_id,Varaus_id,Palvelu_id")] Asiakas asiakas)
        {
            if (ModelState.IsValid)
            {
                db.Asiakas.Add(asiakas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", asiakas.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", asiakas.Puhelin_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", asiakas.Hoitaja_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_Nimi", asiakas.Varaus_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", asiakas.Palvelu_id);
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", asiakas.Käyttäjä_id);
            return View(asiakas);
        }

        // GET: Asiakkaat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakas asiakas = db.Asiakas.Find(id);
            if (asiakas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", asiakas.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", asiakas.Puhelin_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", asiakas.Hoitaja_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_Nimi", asiakas.Varaus_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", asiakas.Palvelu_id);
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", asiakas.Käyttäjä_id);
            return View(asiakas);
        }

        // POST: Asiakkaat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakas_id,Etunimi,Sukunimi,Henkilotunnus,Huomiot,Sahkoposti,Käyttäjä_id,Osoite_id,Puhelin_id,Hoitaja_id,Varaus_id,Palvelu_id")] Asiakas asiakas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiakas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", asiakas.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", asiakas.Puhelin_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", asiakas.Hoitaja_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_Nimi", asiakas.Varaus_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", asiakas.Palvelu_id);
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", asiakas.Käyttäjä_id);
            return View(asiakas);
        }

        // GET: Asiakkaat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakas asiakas = db.Asiakas.Find(id);
            if (asiakas == null)
            {
                return HttpNotFound();
            }
            return View(asiakas);
        }

        // POST: Asiakkaat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asiakas asiakas = db.Asiakas.Find(id);
            db.Asiakas.Remove(asiakas);
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
