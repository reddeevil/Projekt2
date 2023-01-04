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
    public class KierowniksController : Controller
    {
        private ProjektEntities db = new ProjektEntities();

        // GET: Kierowniks
        public async Task<ActionResult> Index()
        {
            return View(await db.Kierownik.ToListAsync());
        }

        // GET: Kierowniks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kierownik kierownik = await db.Kierownik.FindAsync(id);
            if (kierownik == null)
            {
                return HttpNotFound();
            }
            return View(kierownik);
        }

        // GET: Kierowniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kierowniks/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_kierownik,imie,nazwisko")] Kierownik kierownik)
        {
            if (ModelState.IsValid)
            {
                db.Kierownik.Add(kierownik);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(kierownik);
        }

        // GET: Kierowniks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kierownik kierownik = await db.Kierownik.FindAsync(id);
            if (kierownik == null)
            {
                return HttpNotFound();
            }
            return View(kierownik);
        }

        // POST: Kierowniks/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_kierownik,imie,nazwisko")] Kierownik kierownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kierownik).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(kierownik);
        }

        // GET: Kierowniks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kierownik kierownik = await db.Kierownik.FindAsync(id);
            if (kierownik == null)
            {
                return HttpNotFound();
            }
            return View(kierownik);
        }

        // POST: Kierowniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kierownik kierownik = await db.Kierownik.FindAsync(id);
            db.Kierownik.Remove(kierownik);
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
