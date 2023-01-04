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
    public class PozycjasController : Controller
    {
        private ProjektEntities db = new ProjektEntities();

        // GET: Pozycjas
        public async Task<ActionResult> Index()
        {
            return View(await db.Pozycja.ToListAsync());
        }

        // GET: Pozycjas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozycja pozycja = await db.Pozycja.FindAsync(id);
            if (pozycja == null)
            {
                return HttpNotFound();
            }
            return View(pozycja);
        }

        // GET: Pozycjas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pozycjas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_pozycja,nazwa")] Pozycja pozycja)
        {
            if (ModelState.IsValid)
            {
                db.Pozycja.Add(pozycja);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pozycja);
        }

        // GET: Pozycjas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozycja pozycja = await db.Pozycja.FindAsync(id);
            if (pozycja == null)
            {
                return HttpNotFound();
            }
            return View(pozycja);
        }

        // POST: Pozycjas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_pozycja,nazwa")] Pozycja pozycja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pozycja).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pozycja);
        }

        // GET: Pozycjas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozycja pozycja = await db.Pozycja.FindAsync(id);
            if (pozycja == null)
            {
                return HttpNotFound();
            }
            return View(pozycja);
        }

        // POST: Pozycjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pozycja pozycja = await db.Pozycja.FindAsync(id);
            db.Pozycja.Remove(pozycja);
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
