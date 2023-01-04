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
    public class MasazystasController : Controller
    {
        private ProjektEntities db = new ProjektEntities();

        // GET: Masazystas
        public async Task<ActionResult> Index()
        {
            return View(await db.Masazysta.ToListAsync());
        }

        // GET: Masazystas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masazysta masazysta = await db.Masazysta.FindAsync(id);
            if (masazysta == null)
            {
                return HttpNotFound();
            }
            return View(masazysta);
        }

        // GET: Masazystas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masazystas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_masazysta,imie,nazwisko")] Masazysta masazysta)
        {
            if (ModelState.IsValid)
            {
                db.Masazysta.Add(masazysta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(masazysta);
        }

        // GET: Masazystas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masazysta masazysta = await db.Masazysta.FindAsync(id);
            if (masazysta == null)
            {
                return HttpNotFound();
            }
            return View(masazysta);
        }

        // POST: Masazystas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_masazysta,imie,nazwisko")] Masazysta masazysta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masazysta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(masazysta);
        }

        // GET: Masazystas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masazysta masazysta = await db.Masazysta.FindAsync(id);
            if (masazysta == null)
            {
                return HttpNotFound();
            }
            return View(masazysta);
        }

        // POST: Masazystas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Masazysta masazysta = await db.Masazysta.FindAsync(id);
            db.Masazysta.Remove(masazysta);
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
