using AspApiCommons.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspiApiShop.Services
{
    public interface BackendApi
    {
        [Get("/{companyId}/articlestypes")]
        Task<List<ArticleType>> GetArticlesForCompany(long companyId);

        [Get("/articletypes/{articletypeId}")]
        Task<ArticleType> GetArticleTypeFromId(long articletypeId);

        [Get("/articles/fromarticletype/{articletypeId}")]
        Task<Article> GetArticleFromArticleType(long articletypeId);
    }
}
