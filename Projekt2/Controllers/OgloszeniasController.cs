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
    public class OgloszeniasController : Controller
    {
        private ProjektEntities db = new ProjektEntities();

        // GET: Ogloszenias
        public async Task<ActionResult> Index()
        {
            var ogloszenia = db.Ogloszenia.Include(o => o.Druzyna);
            return View(await ogloszenia.ToListAsync());
        }

        // GET: Ogloszenias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenia ogloszenia = await db.Ogloszenia.FindAsync(id);
            if (ogloszenia == null)
            {
                return HttpNotFound();
            }
            return View(ogloszenia);
        }

        // GET: Ogloszenias/Create
        public ActionResult Create()
        {
            ViewBag.id_druzyna = new SelectList(db.Druzyna, "id_druzyna", "nazwa");
            return View();
        }

        // POST: Ogloszenias/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_ogloszenia,id_druzyna,tytul,tresc")] Ogloszenia ogloszenia)
        {
            if (ModelState.IsValid)
            {
                db.Ogloszenia.Add(ogloszenia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_druzyna = new SelectList(db.Druzyna, "id_druzyna", "nazwa", ogloszenia.id_druzyna);
            return View(ogloszenia);
        }

        // GET: Ogloszenias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenia ogloszenia = await db.Ogloszenia.FindAsync(id);
            if (ogloszenia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_druzyna = new SelectList(db.Druzyna, "id_druzyna", "nazwa", ogloszenia.id_druzyna);
            return View(ogloszenia);
        }

        // POST: Ogloszenias/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_ogloszenia,id_druzyna,tytul,tresc")] Ogloszenia ogloszenia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogloszenia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_druzyna = new SelectList(db.Druzyna, "id_druzyna", "nazwa", ogloszenia.id_druzyna);
            return View(ogloszenia);
        }

        // GET: Ogloszenias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogloszenia ogloszenia = await db.Ogloszenia.FindAsync(id);
            if (ogloszenia == null)
            {
                return HttpNotFound();
            }
            return View(ogloszenia);
        }

        // POST: Ogloszenias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ogloszenia ogloszenia = await db.Ogloszenia.FindAsync(id);
            db.Ogloszenia.Remove(ogloszenia);
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
