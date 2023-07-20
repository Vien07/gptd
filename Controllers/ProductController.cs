using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VinaOfficeWebsite.Constants;
using VinaOfficeWebsite.Dto;
using VinaOfficeWebsite.Models.ViewModel;
using VinaOfficeWebsite.Repository;
using X.PagedList;

namespace VinaOfficeWebsite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _product;
        private readonly ICommonRepository _common;
        public ProductController(IProductRepository product, ICommonRepository common)
        {
            _product = product;
            _common = common;
        }
        public IActionResult Index(string slug, int page)
        {
            try
            {
                if (!string.IsNullOrEmpty(slug))
                {
                    slug = slug.Replace("/", "");
                }

                if (page < 1)
                {
                    page = 1;
                }

                ViewBag.Categories = _product.GetProductCateList();
                ViewBag.LatestProductList = _product.GetLatestProductList(5);

                var products = new List<ProductViewModel>();
                var currentCate = new ProductCateViewModel();

                if (string.IsNullOrEmpty(slug) || slug == "san-pham")
                {
                    products = _product.GetProductList();
                }
                else if (slug == "webadmin")
                {
                    return Redirect("https://id.vinaoffice.com/webadmin/");
                }
                else
                {
                    products = _product.GetProductListBySlug(slug, ref currentCate);
                }

                var pageLimit = 32;
                PagedList<ProductViewModel> dataPaging = new PagedList<ProductViewModel>(products, page, pageLimit);
                ViewBag.Data = dataPaging.ToList();
                ViewBag.PageTotal = dataPaging.PageCount;
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCate = currentCate;


                MetaDto _meta = new MetaDto();
                if (string.IsNullOrEmpty(currentCate.Title))
                {
                    _meta.PageTitle = "Sản phẩm";
                    //_meta.Description = "";
                    _meta.PageUrl = "/san-pham/";
                }
                else
                {
                    _meta.PageTitle = currentCate.Title;
                    //_meta.Description = currentCate.Description;
                    _meta.PageUrl = "/" + currentCate.Slug + "/";
                }
                _meta.OgType = WebConstants.OgTypeProduct;
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

                ViewBag.Categories = _product.GetProductCateList();
                ViewBag.LatestProductList = _product.GetLatestProductList(5);
                var data = _product.GetProduct(slug);
                ViewBag.Data = data;
                ViewBag.RelatedList = _product.GetRelatedList(data.CateId.Value, slug);

                MetaDto _meta = new MetaDto();
                _meta.PageTitle = data.Title;
                _meta.Description = data.Description;
                _meta.ImageUrl = data.PicThumb;
                _meta.PageUrl = "/chi-tiet-" + data.Slug + ".html";
                _meta.OgType = WebConstants.OgTypeProduct;
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
