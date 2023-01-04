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
    public class LicencjasController : Controller
    {
        private ProjektEntities db = new ProjektEntities();

        // GET: Licencjas
        public async Task<ActionResult> Index()
        {
            return View(await db.Licencja.ToListAsync());
        }

        // GET: Licencjas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencja licencja = await db.Licencja.FindAsync(id);
            if (licencja == null)
            {
                return HttpNotFound();
            }
            return View(licencja);
        }

        // GET: Licencjas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Licencjas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_licencja,nazwa")] Licencja licencja)
        {
            if (ModelState.IsValid)
            {
                db.Licencja.Add(licencja);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(licencja);
        }

        // GET: Licencjas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencja licencja = await db.Licencja.FindAsync(id);
            if (licencja == null)
            {
                return HttpNotFound();
            }
            return View(licencja);
        }

        // POST: Licencjas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_licencja,nazwa")] Licencja licencja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licencja).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(licencja);
        }

        // GET: Licencjas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencja licencja = await db.Licencja.FindAsync(id);
            if (licencja == null)
            {
                return HttpNotFound();
            }
            return View(licencja);
        }

        // POST: Licencjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Licencja licencja = await db.Licencja.FindAsync(id);
            db.Licencja.Remove(licencja);
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
