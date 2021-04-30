using AspApiBackend.Data;
using AspApiCommons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Description;

namespace AspApiBackend.Controllers
{
    [RoutePrefix("api/frontend")]
    public class FrontendController : ApiController
    {
        private AspApiBackendContext db = new AspApiBackendContext();

        [Route("{companyId}/articlestypes")]
        [ResponseType(typeof(List<ArticleType>))]
        public IHttpActionResult GetArticlesForCompany(long companyId)
        {
            var result = this.db.ArticleTypes.Where(x => x.Company.Id == companyId).ToList();
            return Ok(result);
        }

        [Route("articletypes/{articletypeId}")]
        [ResponseType(typeof(ArticleType))]
        public IHttpActionResult GetArticleTypeFromId(long articletypeId)
        {
            var result = this.db.ArticleTypes.Include(x => x.InStock).Include(x => x.Selled).FirstOrDefault(x => x.Id == articletypeId);
            return Ok(result);
        }

        [Route("articles/fromarticletype/{articletypeId}")]
        [ResponseType(typeof(Article))]
        public IHttpActionResult GetArticleFromArticleType(long articletypeId)
        {
            var result = this.db.ArticleTypes.Include(x => x.InStock).FirstOrDefault(x => x.Id == articletypeId).InStock.FirstOrDefault();
            return Ok(result);
        }
    }
}
