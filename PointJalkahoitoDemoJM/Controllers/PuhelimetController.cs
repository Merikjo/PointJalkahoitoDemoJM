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
    public class PuhelimetController : Controller
    {
        private JohaMeriSQL1Entities db = new JohaMeriSQL1Entities();

        // GET: Puhelimet
        public ActionResult Index()
        {
            var puhelin = db.Puhelin.Include(p => p.Asiakas1).Include(p => p.Henkilokunta1).Include(p => p.Hoitaja1).Include(p => p.Toimipiste);
            return View(puhelin.ToList());
        }

        // GET: Puhelimet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puhelin puhelin = db.Puhelin.Find(id);
            if (puhelin == null)
            {
                return HttpNotFound();
            }
            return View(puhelin);
        }

        // GET: Puhelimet/Create
        public ActionResult Create()
        {
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi");
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi");
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi");
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi");
            return View();
        }

        // POST: Puhelimet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Puhelin_id,Puhelinnumero_1,Puhelinnumero_2,Puhelinnumero_3,Asiakas_id,Hoitaja_id,Henkilokunta_id,Toimipiste_id")] Puhelin puhelin)
        {
            if (ModelState.IsValid)
            {
                db.Puhelin.Add(puhelin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", puhelin.Asiakas_id);
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi", puhelin.Henkilokunta_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", puhelin.Hoitaja_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", puhelin.Toimipiste_id);
            return View(puhelin);
        }

        // GET: Puhelimet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puhelin puhelin = db.Puhelin.Find(id);
            if (puhelin == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", puhelin.Asiakas_id);
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi", puhelin.Henkilokunta_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", puhelin.Hoitaja_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", puhelin.Toimipiste_id);
            return View(puhelin);
        }

        // POST: Puhelimet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Puhelin_id,Puhelinnumero_1,Puhelinnumero_2,Puhelinnumero_3,Asiakas_id,Hoitaja_id,Henkilokunta_id,Toimipiste_id")] Puhelin puhelin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puhelin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", puhelin.Asiakas_id);
            ViewBag.Henkilokunta_id = new SelectList(db.Henkilokunta, "Henkilokunta_id", "Etunimi", puhelin.Henkilokunta_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", puhelin.Hoitaja_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", puhelin.Toimipiste_id);
            return View(puhelin);
        }

        // GET: Puhelimet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puhelin puhelin = db.Puhelin.Find(id);
            if (puhelin == null)
            {
                return HttpNotFound();
            }
            return View(puhelin);
        }

        // POST: Puhelimet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Puhelin puhelin = db.Puhelin.Find(id);
            db.Puhelin.Remove(puhelin);
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
