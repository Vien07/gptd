using Microsoft.AspNetCore.Mvc;
using VinaOfficeWebsite.Constants;
using VinaOfficeWebsite.Dto;
using VinaOfficeWebsite.Models.ViewModel;
using VinaOfficeWebsite.Repository;
using X.PagedList;

namespace VinaOfficeWebsite.Controllers
{
    public class BlogController : Controller
    {
        private readonly IProductRepository _product;
        private readonly INewsRepository _news;
        private readonly ICommonRepository _common;
        public BlogController(IProductRepository product, INewsRepository news, ICommonRepository common)
        {
            _product = product;
            _news = news;
            _common = common;
        }
        public IActionResult Index(int page)
        {
            try
            {
                if (page < 1)
                {
                    page = 1;
                }
                ViewBag.LatestProductList = _product.GetLatestProductList(5);

                var products = _news.GetNewsList();

                var pageLimit = 12;
                PagedList<NewsViewModel> dataPaging = new PagedList<NewsViewModel>(products, page, pageLimit);
                ViewBag.Data = dataPaging.ToList();
                ViewBag.PageTotal = dataPaging.PageCount;
                ViewBag.CurrentPage = page;

                MetaDto _meta = new MetaDto();
                _meta.PageTitle = "Blogs";
                //_meta.Description = data.Description;
                //_meta.ImageUrl = data.PicThumb;
                //_meta.PageUrl = "/blogs/" + data.Slug + ".html";
                _meta.OgType = WebConstants.OgTypeArticle;
                ViewBag.Meta = _common.GetMeta(_meta);

                return View();
            }
            catch (Exception ex)
            {
                return View("~/Views/Error/Page404.cshtml");
            }
        }
        public IActionResult Detail(string slug)
        {
            try
            {
                if (!string.IsNullOrEmpty(slug))
                {
                    slug = slug.Replace("/", "");
                }
                ViewBag.LatestProductList = _product.GetLatestProductList(5);
                var data = _news.GetNews(slug);
                ViewBag.Data = data;
                ViewBag.RelatedList = _news.GetRelatedNewsList();


                MetaDto _meta = new MetaDto();
                _meta.PageTitle = data.Title;
                _meta.Description = data.Description;
                _meta.ImageUrl = data.PicThumb;
                _meta.PageUrl = "/blogs/" + data.Slug + ".html";
                _meta.OgType = WebConstants.OgTypeArticle;

                ViewBag.Meta = _common.GetMeta(_meta);

                return View();
            }
            catch
            {
                return View("~/Views/Error/Page404.cshtml");
            }
        }
    }
}
