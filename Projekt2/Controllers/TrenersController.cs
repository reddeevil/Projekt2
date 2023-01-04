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
    public class TrenersController : Controller
    {
        private ProjektEntities db = new ProjektEntities();

        // GET: Treners
        public async Task<ActionResult> Index()
        {
            var trener = db.Trener.Include(t => t.Licencja);
            return View(await trener.ToListAsync());
        }

        // GET: Treners/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trener trener = await db.Trener.FindAsync(id);
            if (trener == null)
            {
                return HttpNotFound();
            }
            return View(trener);
        }

        // GET: Treners/Create
        public ActionResult Create()
        {
            ViewBag.id_licencja = new SelectList(db.Licencja, "id_licencja", "nazwa");
            return View();
        }

        // POST: Treners/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_trener,imie,nazwisko,id_licencja")] Trener trener)
        {
            if (ModelState.IsValid)
            {
                db.Trener.Add(trener);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_licencja = new SelectList(db.Licencja, "id_licencja", "nazwa", trener.id_licencja);
            return View(trener);
        }

        // GET: Treners/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trener trener = await db.Trener.FindAsync(id);
            if (trener == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_licencja = new SelectList(db.Licencja, "id_licencja", "nazwa", trener.id_licencja);
            return View(trener);
        }

        // POST: Treners/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_trener,imie,nazwisko,id_licencja")] Trener trener)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trener).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_licencja = new SelectList(db.Licencja, "id_licencja", "nazwa", trener.id_licencja);
            return View(trener);
        }

        // GET: Treners/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trener trener = await db.Trener.FindAsync(id);
            if (trener == null)
            {
                return HttpNotFound();
            }
            return View(trener);
        }

        // POST: Treners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Trener trener = await db.Trener.FindAsync(id);
            db.Trener.Remove(trener);
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
