using SMC.WebApi.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace SMC.WebApi.Controllers
{
    public class EscolaController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private DbSet<Escola> dbset;

        public EscolaController()
        {
            dbset = db.Set<Escola>();
        }

        // GET: api/Escola
        public IQueryable<Escola> GetEscolas()
        {
            return dbset;
        }

        // GET: api/Escola/5
        [ResponseType(typeof(Escola))]
        public IHttpActionResult GetEscola(string id)
        {
            Escola escola = dbset.Find(id);
            if (escola == null)
            {
                return NotFound();
            }

            return Ok(escola);
        }

        // PUT: api/Escola/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEscola(string id, Escola escola)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != escola.Id)
            {
                return BadRequest();
            }

            db.Entry(escola).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EscolaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Escola
        [ResponseType(typeof(Escola))]
        public IHttpActionResult PostEscola(Escola escola)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbset.Add(escola);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EscolaExists(escola.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = escola.Id }, escola);
        }

        // DELETE: api/Escola/5
        [ResponseType(typeof(Escola))]
        public IHttpActionResult DeleteEscola(string id)
        {
            Escola escola = dbset.Find(id);
            if (escola == null)
            {
                return NotFound();
            }

            dbset.Remove(escola);
            db.SaveChanges();

            return Ok(escola);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EscolaExists(string id)
        {
            return dbset.Count(e => e.Id == id) > 0;
        }
    }
}