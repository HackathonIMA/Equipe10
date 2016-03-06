using SMC.WebApi.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SMC.WebApi.Controllers
{
    public class PerfilEscolaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private DbSet<Escola> dbset;

        public PerfilEscolaController()
        {
            dbset = db.Set<Escola>();
        }

        // GET: PerfilEscola
        public ActionResult Index()
        {
            return View(dbset.ToList());
        }

        // GET: PerfilEscola/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escola escola = dbset.Find(id);
            if (escola == null)
            {
                return HttpNotFound();
            }
            return View(escola);
        }

        // GET: PerfilEscola/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilEscola/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Regime,NomeUnidadeEscolar,Bairro,Descricao,EnderecoEscolaDemanda,LogradouroDemanda,MunicipioDemanda,UfDemanda,CepDemanda,Telefone,Endereco")] Escola escola)
        {
            if (ModelState.IsValid)
            {
                dbset.Add(escola);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(escola);
        }

        // GET: PerfilEscola/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escola escola = dbset.Find(id);
            if (escola == null)
            {
                return HttpNotFound();
            }
            return View(escola);
        }

        // POST: PerfilEscola/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Regime,NomeUnidadeEscolar,Bairro,Descricao,EnderecoEscolaDemanda,LogradouroDemanda,MunicipioDemanda,UfDemanda,CepDemanda,Telefone,Endereco")] Escola escola)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escola).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escola);
        }

        // GET: PerfilEscola/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escola escola = dbset.Find(id);
            if (escola == null)
            {
                return HttpNotFound();
            }
            return View(escola);
        }

        // POST: PerfilEscola/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Escola escola = dbset.Find(id);
            dbset.Remove(escola);
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