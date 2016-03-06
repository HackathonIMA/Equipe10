using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SMC.WebApi.Models;

namespace SMC.WebApi.Controllers
{
    public class ComentarioController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private DbSet<ComentarioModel> dbset;

        public ComentarioController()
        {
            dbset = db.Set<ComentarioModel>();
        }

        // GET: api/Comentario
        public IQueryable<ComentarioModel> GetComentarioModels()
        {
            return dbset;
        }

        // GET: api/Comentario/5
        [ResponseType(typeof(ComentarioModel))]
        public IHttpActionResult GetComentarioModel(int id)
        {
            ComentarioModel comentarioModel = dbset.Find(id);
            if (comentarioModel == null)
            {
                return NotFound();
            }

            return Ok(comentarioModel);
        }

        // PUT: api/Comentario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComentarioModel(int id, ComentarioModel comentarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comentarioModel.Id)
            {
                return BadRequest();
            }

            db.Entry(comentarioModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioModelExists(id))
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

        // POST: api/Comentario
        [ResponseType(typeof(ComentarioModel))]
        public IHttpActionResult PostComentarioModel(ComentarioModel comentarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbset.Add(comentarioModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comentarioModel.Id }, comentarioModel);
        }

        // DELETE: api/Comentario/5
        [ResponseType(typeof(ComentarioModel))]
        public IHttpActionResult DeleteComentarioModel(int id)
        {
            ComentarioModel comentarioModel = dbset.Find(id);
            if (comentarioModel == null)
            {
                return NotFound();
            }

            dbset.Remove(comentarioModel);
            db.SaveChanges();

            return Ok(comentarioModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComentarioModelExists(int id)
        {
            return dbset.Count(e => e.Id == id) > 0;
        }
    }
}