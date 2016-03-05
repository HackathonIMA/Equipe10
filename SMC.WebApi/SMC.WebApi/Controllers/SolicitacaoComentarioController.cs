using SMC.WebApi.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace SMC.WebApi.Controllers
{
    public class SolicitacaoComentarioController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SolicitacaoComentarioModels
        public IQueryable<SolicitacaoComentarioModels> GetSolicitacaoComentarioModels()
        {
            return db.SolicitacaoComentarioModels;
        }

        // GET: api/SolicitacaoComentarioModels/5
        [ResponseType(typeof(SolicitacaoComentarioModels))]
        public IHttpActionResult GetSolicitacaoComentario(string id)
        {
            SolicitacaoComentarioModels solicitacaoComentarioModels = db.SolicitacaoComentarioModels.Find(id);
            if (solicitacaoComentarioModels == null)
            {
                return NotFound();
            }

            return Ok(solicitacaoComentarioModels);
        }

        // PUT: api/SolicitacaoComentarioModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSolicitacaoComentario(string id, SolicitacaoComentarioModels solicitacaoComentarioModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solicitacaoComentarioModels.Id)
            {
                return BadRequest();
            }

            db.Entry(solicitacaoComentarioModels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitacaoComentarioModelsExists(id))
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

        // POST: api/SolicitacaoComentarioModels
        [ResponseType(typeof(SolicitacaoComentarioModels))]
        public IHttpActionResult PostSolicitacaoComentario(SolicitacaoComentarioModels solicitacaoComentarioModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SolicitacaoComentarioModels.Add(solicitacaoComentarioModels);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SolicitacaoComentarioModelsExists(solicitacaoComentarioModels.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = solicitacaoComentarioModels.Id }, solicitacaoComentarioModels);
        }

        // DELETE: api/SolicitacaoComentarioModels/5
        [ResponseType(typeof(SolicitacaoComentarioModels))]
        public IHttpActionResult DeleteSolicitacaoComentario(string id)
        {
            SolicitacaoComentarioModels solicitacaoComentarioModels = db.SolicitacaoComentarioModels.Find(id);
            if (solicitacaoComentarioModels == null)
            {
                return NotFound();
            }

            db.SolicitacaoComentarioModels.Remove(solicitacaoComentarioModels);
            db.SaveChanges();

            return Ok(solicitacaoComentarioModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SolicitacaoComentarioModelsExists(string id)
        {
            return db.SolicitacaoComentarioModels.Count(e => e.Id == id) > 0;
        }
    }
}