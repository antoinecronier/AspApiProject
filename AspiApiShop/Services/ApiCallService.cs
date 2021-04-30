using AspApiCommons.Entities;
using AspiApiShop.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspiApiShop.Services
{
    public class ApiCallService
    {
        private BackendApi backend;

        public ApiCallService()
        {
            this.backend = RestService.For<BackendApi>("http://localhost:56220/api/frontend");
        }

        public async Task<List<IndexViewModel>> GetIndexVm()
        {
            List<IndexViewModel> result = new List<IndexViewModel>();

            List<ArticleType> datas = new List<ArticleType>();
            try
            {
                datas = await this.backend.GetArticlesForCompany(1);
            }
            catch (Exception e)
            {
                throw e;
            }
            

            result.AddRange(datas.Select(x => new IndexViewModel { Id = x.Id, ArticleName = x.Name }));

            return result;
        }

        public async Task<DetailsViewModel> GetDetailsVmFromArticleTypeId(long id)
        {
            DetailsViewModel result = new DetailsViewModel();

            ArticleType articleType = null;
            try
            {
                articleType = await this.backend.GetArticleTypeFromId(id);
            }
            catch (Exception e)
            {
                throw e;
            }

            result.Id = articleType.Id;
            result.Name = articleType.Name;
            result.NbElem = articleType.InStock.Count;
            result.SellingPrice = articleType.StandardBuyingPrice;
            result.DeliveryDays = articleType.StandardDeliveryTime;

            return result;
        }

        public async Task<BuyViewModel> GetBuyVmFromArticleTypeId(long id)
        {
            BuyViewModel result = new BuyViewModel();

            Article article = await this.backend.GetArticleFromArticleType(id);

            result.Name = article.Name;
            result.DeliveredOn = article.DeliveryAt;

            return result;
        }
    }
}