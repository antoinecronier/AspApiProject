using AspiApiShop.Models;
using AspiApiShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspiApiShop.Controllers
{
    public class HomeController : Controller
    {
        public ApiCallService service = new ApiCallService();

        public async Task<ActionResult> Index()
        {
            //List<IndexViewModel> model = new List<IndexViewModel>()
            //{
            //    new IndexViewModel{ Id = 1, ArticleName = "article1" },
            //    new IndexViewModel{ Id = 2, ArticleName = "article2" },
            //    new IndexViewModel{ Id = 3, ArticleName = "article3" }
            //};
            return View(await service.GetIndexVm());
        }

        public async Task<ActionResult> Details(long id)
        {
            //DetailsViewModel vm = new DetailsViewModel();
            //vm.DeliveryDays = 5;
            //vm.Id = 1;
            //vm.Name = "article1";
            //vm.NbElem = 10;
            //vm.SellingPrice = 30.60M;
            return View(await service.GetDetailsVmFromArticleTypeId(id));
        }

        public async Task<ActionResult> Buy(long id)
        {
            //BuyViewModel vm = new BuyViewModel();
            //vm.Name = "article1";
            //vm.DeliveredOn = DateTime.Now.AddDays(2);
            return View(await service.GetBuyVmFromArticleTypeId(id));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}