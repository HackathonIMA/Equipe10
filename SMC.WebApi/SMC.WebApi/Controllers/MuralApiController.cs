using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SMC.WebApi.Models;

namespace SMC.WebApi.Controllers
{
    public class MuralApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private DbSet<MuralModel> dbset;

        public MuralApiController()
        {
            dbset = db.Set<MuralModel>();
        }


        // GET: api/MuralApi
        public IQueryable<MuralModel> GetMuralModels()
        {
            return dbset;
        }

        //public IQueryable<MuralModel> GetMuralModelEscola(string id)
        //{
        //    return dbset.Where(x => x.Escola.Id == id);
        //}

        // GET: api/MuralApi/5
        [ResponseType(typeof(MuralModel))]
        public IHttpActionResult GetMuralModel(int id)
        {
            MuralModel muralModel = dbset.Find(id);
            if (muralModel == null)
            {
                return NotFound();
            }

            return Ok(muralModel);
        }

        public IHttpActionResult GetEscolaMural(int id)
        {
            MuralModel muralModel = dbset.Find(id);
            if (muralModel == null)
            {
                return NotFound();
            }

            return Ok(muralModel);
        }

        // PUT: api/MuralApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMuralModel(int id, MuralModel muralModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != muralModel.Id)
            {
                return BadRequest();
            }

            db.Entry(muralModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuralModelExists(id))
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

        // POST: api/MuralApi
        [ResponseType(typeof(MuralModel))]
        public IHttpActionResult PostMuralModel(MuralModel muralModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbset.Add(muralModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = muralModel.Id }, muralModel);
        }

        // DELETE: api/MuralApi/5
        [ResponseType(typeof(MuralModel))]
        public IHttpActionResult DeleteMuralModel(int id)
        {
            MuralModel muralModel = dbset.Find(id);
            if (muralModel == null)
            {
                return NotFound();
            }

            dbset.Remove(muralModel);
            db.SaveChanges();

            return Ok(muralModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MuralModelExists(int id)
        {
            return dbset.Count(e => e.Id == id) > 0;
        }
    }
}