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
    public class ZawodniksController : Controller
    {
        private ProjektEntities db = new ProjektEntities();

        // GET: Zawodniks
        public async Task<ActionResult> Index()
        {
            var zawodnik = db.Zawodnik.Include(z => z.Druzyna).Include(z => z.Pozycja);
            return View(await zawodnik.ToListAsync());
        }

        // GET: Zawodniks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zawodnik zawodnik = await db.Zawodnik.FindAsync(id);
            if (zawodnik == null)
            {
                return HttpNotFound();
            }
            return View(zawodnik);
        }

        // GET: Zawodniks/Create
        public ActionResult Create()
        {
            ViewBag.id_druzyna = new SelectList(db.Druzyna, "id_druzyna", "nazwa");
            ViewBag.id_pozycja = new SelectList(db.Pozycja, "id_pozycja", "nazwa");
            return View();
        }

        // POST: Zawodniks/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_zawodnik,imie,nazwisko,id_pozycja,id_druzyna")] Zawodnik zawodnik)
        {
            if (ModelState.IsValid)
            {
                db.Zawodnik.Add(zawodnik);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_druzyna = new SelectList(db.Druzyna, "id_druzyna", "nazwa", zawodnik.id_druzyna);
            ViewBag.id_pozycja = new SelectList(db.Pozycja, "id_pozycja", "nazwa", zawodnik.id_pozycja);
            return View(zawodnik);
        }

        // GET: Zawodniks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zawodnik zawodnik = await db.Zawodnik.FindAsync(id);
            if (zawodnik == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_druzyna = new SelectList(db.Druzyna, "id_druzyna", "nazwa", zawodnik.id_druzyna);
            ViewBag.id_pozycja = new SelectList(db.Pozycja, "id_pozycja", "nazwa", zawodnik.id_pozycja);
            return View(zawodnik);
        }

        // POST: Zawodniks/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_zawodnik,imie,nazwisko,id_pozycja,id_druzyna")] Zawodnik zawodnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zawodnik).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_druzyna = new SelectList(db.Druzyna, "id_druzyna", "nazwa", zawodnik.id_druzyna);
            ViewBag.id_pozycja = new SelectList(db.Pozycja, "id_pozycja", "nazwa", zawodnik.id_pozycja);
            return View(zawodnik);
        }

        // GET: Zawodniks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zawodnik zawodnik = await db.Zawodnik.FindAsync(id);
            if (zawodnik == null)
            {
                return HttpNotFound();
            }
            return View(zawodnik);
        }

        // POST: Zawodniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Zawodnik zawodnik = await db.Zawodnik.FindAsync(id);
            db.Zawodnik.Remove(zawodnik);
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
