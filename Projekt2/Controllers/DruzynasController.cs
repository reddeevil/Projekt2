using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekt2.Models;

namespace Projekt2.Controllers
{
    [Authorize(Roles = "Zawodnik,Trener,Admin")]
    public class DruzynasController : Controller
    {
        private ProjektEntities db = new ProjektEntities();

        // GET: Druzynas
        public async Task<ActionResult> Index()
        {
            var druzyna = db.Druzyna.Include(d => d.Kierownik).Include(d => d.Masazysta).Include(d => d.Trener);
            return View(await druzyna.ToListAsync());
        }

        // GET: Druzynas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Druzyna druzyna = await db.Druzyna.FindAsync(id);
            if (druzyna == null)
            {
                return HttpNotFound();
            }
            return View(druzyna);
        }

        // GET: Druzynas/Create
        public ActionResult Create()
        {
            ViewBag.id_kierownik = new SelectList(db.Kierownik, "id_kierownik", "imie");
            ViewBag.id_masazysta = new SelectList(db.Masazysta, "id_masazysta", "imie");
            ViewBag.id_trener = new SelectList(db.Trener, "id_trener", "imie");
            return View();
        }

        // POST: Druzynas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_druzyna,nazwa,id_trener,id_masazysta,id_kierownik")] Druzyna druzyna)
        {
            if (ModelState.IsValid)
            {
                db.Druzyna.Add(druzyna);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_kierownik = new SelectList(db.Kierownik, "id_kierownik", "imie", druzyna.id_kierownik);
            ViewBag.id_masazysta = new SelectList(db.Masazysta, "id_masazysta", "imie", druzyna.id_masazysta);
            ViewBag.id_trener = new SelectList(db.Trener, "id_trener", "imie", druzyna.id_trener);
            return View(druzyna);
        }

        // GET: Druzynas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Druzyna druzyna = await db.Druzyna.FindAsync(id);
            if (druzyna == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_kierownik = new SelectList(db.Kierownik, "id_kierownik", "imie", druzyna.id_kierownik);
            ViewBag.id_masazysta = new SelectList(db.Masazysta, "id_masazysta", "imie", druzyna.id_masazysta);
            ViewBag.id_trener = new SelectList(db.Trener, "id_trener", "imie", druzyna.id_trener);
            return View(druzyna);
        }

        // POST: Druzynas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_druzyna,nazwa,id_trener,id_masazysta,id_kierownik")] Druzyna druzyna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(druzyna).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_kierownik = new SelectList(db.Kierownik, "id_kierownik", "imie", druzyna.id_kierownik);
            ViewBag.id_masazysta = new SelectList(db.Masazysta, "id_masazysta", "imie", druzyna.id_masazysta);
            ViewBag.id_trener = new SelectList(db.Trener, "id_trener", "imie", druzyna.id_trener);
            return View(druzyna);
        }

        // GET: Druzynas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Druzyna druzyna = await db.Druzyna.FindAsync(id);
            if (druzyna == null)
            {
                return HttpNotFound();
            }
            return View(druzyna);
        }

        // POST: Druzynas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Druzyna druzyna = await db.Druzyna.FindAsync(id);
            db.Druzyna.Remove(druzyna);
            await db.SaveChangesAsync();
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
