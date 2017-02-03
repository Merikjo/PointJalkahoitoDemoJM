using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointJalkahoitoDemoJM.Models;
using System.Globalization;

namespace PointJalkahoitoDemoJM.Controllers
{
    public class VarauksetController : Controller
    {
        private JohaMeriSQL1Entities db = new JohaMeriSQL1Entities();

        // GET: Varaukset
        public ActionResult Index()
        {
            var varaus = db.Varaus.Include(v => v.Asiakas1).Include(v => v.Henkilokunta1).Include(v => v.Hoitaja1).Include(v => v.Hoitopaikka1).Include(v => v.Palvelu1).Include(v => v.Toimipiste);
            return View(varaus.ToList());
        }

        // GET: Varaukset/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Varaus varaus = db.Varaus.Find(id);
            if (varaus == null)
            {
                return HttpNotFound();
            }
            return View(varaus);
        }

        // GET: Varaukset/Create
        public ActionResult Create()
        {
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", "Sukunimi");
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi");
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi");
            ViewBag.Hoitopaikka_id = new SelectList(db.Hoitopaikka, "Hoitopaikka_id", "Hoitopaikan_Nimi");
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi");
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi");
            return View();
        }

        // POST: Varaukset/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Varaus_id,Palvelun_Nimi,Alku,Loppu,pvm,Type,Huomio,Hoitaja_id,Hoitopaikka_id,Asiakas_id,Henkilokunta_id,Toimipiste_id,Palvelu_id")] Varaus varaus)
        {
            if (ModelState.IsValid)
            {
                db.Varaus.Add(varaus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        // Lisätty aikamääre 1.2.12017
            CultureInfo fiFi = new CultureInfo("fi-FI");

            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", "Sukunimi", varaus.Asiakas_id);
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi", varaus.Henkilokunta_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", varaus.Hoitaja_id);
            ViewBag.Hoitopaikka_id = new SelectList(db.Hoitopaikka, "Hoitopaikka_id", "Hoitopaikan_Nimi", varaus.Hoitopaikka_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", varaus.Palvelu_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", varaus.Toimipiste_id);
            return View(varaus);
        }

        //Varauksen tietojen muuttaminen 1.2.2017
        //https://www.youtube.com/watch?v=l06JSQDuOwo
        //OHJE
        //https://msdn.microsoft.com/fi-fi/data/jj592676

        public ActionResult Resize(int id, DateTime pvm, string newStart, string newEnd)
        {
            using (var dp = new JohaMeriSQL1Entities())
            {
                var varaus = dp.Varaus.First(c => c.Varaus_id == id);

                varaus.pvm = pvm;
                varaus.Alku = newStart;
                varaus.Loppu = newEnd;
           
                dp.SaveChanges();
            }

            return new EmptyResult();
        }

        // GET: Varaukset/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Varaus varaus = db.Varaus.Find(id);
            if (varaus == null)
            {
                return HttpNotFound();
            }

            // Lisätty aikamääre 1.2.12017
            CultureInfo fiFi = new CultureInfo("fi-FI");

            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", "Sukunimi", varaus.Asiakas_id);
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi", varaus.Henkilokunta_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", varaus.Hoitaja_id);
            ViewBag.Hoitopaikka_id = new SelectList(db.Hoitopaikka, "Hoitopaikka_id", "Hoitopaikan_Nimi", varaus.Hoitopaikka_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", varaus.Palvelu_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", varaus.Toimipiste_id);
            return View(varaus);
        }

        // POST: Varaukset/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Varaus_id,Palvelun_Nimi,Alku,Loppu,pvm,Type,Huomio,Hoitaja_id,Hoitopaikka_id,Asiakas_id,Henkilokunta_id,Toimipiste_id,Palvelu_id")] Varaus varaus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(varaus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Lisätty aikamääre 1.2.12017
            CultureInfo fiFi = new CultureInfo("fi-FI");

            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", "Sukunimi", varaus.Asiakas_id);
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi", varaus.Henkilokunta_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", varaus.Hoitaja_id);
            ViewBag.Hoitopaikka_id = new SelectList(db.Hoitopaikka, "Hoitopaikka_id", "Hoitopaikan_Nimi", varaus.Hoitopaikka_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", varaus.Palvelu_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", varaus.Toimipiste_id);
            return View(varaus);
        }

        // GET: Varaukset/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Varaus varaus = db.Varaus.Find(id);
            if (varaus == null)
            {
                return HttpNotFound();
            }
            return View(varaus);
        }

        // POST: Varaukset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Varaus varaus = db.Varaus.Find(id);
            db.Varaus.Remove(varaus);
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
