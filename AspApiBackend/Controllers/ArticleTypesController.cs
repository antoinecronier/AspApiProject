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
using AspApiBackend.Data;
using AspApiCommons.Entities;

namespace AspApiBackend.Controllers
{
    public class ArticleTypesController : ApiController
    {
        private AspApiBackendContext db = new AspApiBackendContext();

        // GET: api/ArticleTypes
        public IQueryable<ArticleType> GetArticleTypes()
        {
            return db.ArticleTypes;
        }

        // GET: api/ArticleTypes/5
        [ResponseType(typeof(ArticleType))]
        public IHttpActionResult GetArticleType(long id)
        {
            ArticleType articleType = db.ArticleTypes.Find(id);
            if (articleType == null)
            {
                return NotFound();
            }

            return Ok(articleType);
        }

        // PUT: api/ArticleTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticleType(long id, ArticleType articleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articleType.Id)
            {
                return BadRequest();
            }

            db.Entry(articleType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleTypeExists(id))
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

        // POST: api/ArticleTypes
        [ResponseType(typeof(ArticleType))]
        public IHttpActionResult PostArticleType(ArticleType articleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ArticleTypes.Add(articleType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = articleType.Id }, articleType);
        }

        // DELETE: api/ArticleTypes/5
        [ResponseType(typeof(ArticleType))]
        public IHttpActionResult DeleteArticleType(long id)
        {
            ArticleType articleType = db.ArticleTypes.Find(id);
            if (articleType == null)
            {
                return NotFound();
            }

            db.ArticleTypes.Remove(articleType);
            db.SaveChanges();

            return Ok(articleType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticleTypeExists(long id)
        {
            return db.ArticleTypes.Count(e => e.Id == id) > 0;
        }
    }
}