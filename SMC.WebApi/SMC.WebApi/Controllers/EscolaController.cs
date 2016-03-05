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

        // GET: api/Escola
        public IQueryable<Escola> GetEscolas()
        {
            return db.Escolas;
        }

        // GET: api/Escola/5
        [ResponseType(typeof(Escola))]
        public IHttpActionResult GetEscola(string id)
        {
            Escola escola = db.Escolas.Find(id);
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

            db.Escolas.Add(escola);

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
            Escola escola = db.Escolas.Find(id);
            if (escola == null)
            {
                return NotFound();
            }

            db.Escolas.Remove(escola);
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
            return db.Escolas.Count(e => e.Id == id) > 0;
        }
    }
}