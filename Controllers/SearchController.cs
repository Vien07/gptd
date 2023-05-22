using Azure;
using Microsoft.AspNetCore.Mvc;
using VinaOfficeWebsite.Constants;
using VinaOfficeWebsite.Dto;
using VinaOfficeWebsite.Models.ViewModel;
using VinaOfficeWebsite.Repository;
using X.PagedList;

namespace VinaOfficeWebsite.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductRepository _product;
        private readonly ICommonRepository _common;
        public SearchController(IProductRepository product, ICommonRepository common)
        {
            _product = product;
            _common = common;
        }
        public IActionResult Index(int page, string q)
        {
            try
            {
                if (!string.IsNullOrEmpty(q))
                {
                    q = q.Replace("/", "");
                }
                if (page < 1)
                {
                    page = 1;
                }
                ViewBag.Categories = _product.GetProductCateList();
                ViewBag.LatestProductList = _product.GetLatestProductList(5);
                ViewBag.Key = q;
                var products = _product.GetProductListByKey(q);
                var pageLimit = 24;
                PagedList<ProductViewModel> dataPaging = new PagedList<ProductViewModel>(products, page, pageLimit);
                ViewBag.Data = dataPaging.ToList();
                ViewBag.PageTotal = dataPaging.PageCount;
                ViewBag.CurrentPage = page;

                MetaDto _meta = new MetaDto();
                _meta.PageTitle = q;
                _meta.OgType = WebConstants.OgTypeWebsite;
                ViewBag.Meta = _common.GetMeta(_meta);

                return View();
            }
            catch (Exception ex)
            {
                return View("~/Views/Error/Page404.cshtml");
            }
        }
    }
}
