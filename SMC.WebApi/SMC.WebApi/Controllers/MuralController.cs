using SMC.WebApi.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SMC.WebApi.Controllers
{
    public class MuralController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private DbSet<MuralModel> dbset;

        public MuralController()
        {
            dbset = db.Set<MuralModel>();
        }

        // GET: Mural
        public ActionResult Index()
        {
            return View(dbset.ToList());
        }

        // GET: Mural/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuralModel muralModel = dbset.Find(id);
            if (muralModel == null)
            {
                return HttpNotFound();
            }
            return View(muralModel);
        }

        // GET: Mural/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mural/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Escola_Id,Conteudo,Curtidas")] MuralModel muralModel)
        {
            if (ModelState.IsValid)
            {
                dbset.Add(muralModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(muralModel);
        }

        // GET: Mural/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuralModel muralModel = dbset.Find(id);
            if (muralModel == null)
            {
                return HttpNotFound();
            }
            return View(muralModel);
        }

        // POST: Mural/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Escola_Id,Conteudo,Curtidas")] MuralModel muralModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muralModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(muralModel);
        }

        // GET: Mural/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuralModel muralModel = dbset.Find(id);
            if (muralModel == null)
            {
                return HttpNotFound();
            }
            return View(muralModel);
        }

        // POST: Mural/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MuralModel muralModel = dbset.Find(id);
            dbset.Remove(muralModel);
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