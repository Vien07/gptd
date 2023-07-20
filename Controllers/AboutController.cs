using Microsoft.AspNetCore.Mvc;
using VinaOfficeWebsite.Dto;
using VinaOfficeWebsite.Models.ViewModel;
using VinaOfficeWebsite.Repository;
using X.PagedList;

using VinaOfficeWebsite.Constants;

namespace VinaOfficeWebsite.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutRepository _about;
        private readonly ICommonRepository _common;
        public AboutController(IAboutRepository about, ICommonRepository common)
        {
            _about = about;
            _common = common;
        }
        public IActionResult Index(string slug)
        {
            try
            {
                if (!string.IsNullOrEmpty(slug))
                {
                    slug = slug.Replace("/", "");
                }
                var data = _about.GetAbout(slug);
                var title = data.Title;
                ViewBag.Data = data;

                MetaDto _meta = new MetaDto();
                _meta.PageTitle = data.Title;
                //_meta.Description = data.Description;
                //_meta.ImageUrl = data.PicThumb;
                _meta.PageUrl = "/tong-quan/" + data.Slug + "/";
                _meta.OgType = WebConstants.OgTypeArticle;

                ViewBag.Meta = _common.GetMeta(_meta);

                return View();
            }
            catch
            {
                return View("~/Views/Error/Page404.cshtml");
            }
        }
        public IActionResult Policy(string slug)
        {
            try
            {
                if (!string.IsNullOrEmpty(slug))
                {
                    slug = slug.Replace("/", "");
                }
                var data = _about.GetPolicy(slug);
                var title = data.Title;
                ViewBag.Data = data;

                MetaDto _meta = new MetaDto();
                _meta.PageTitle = data.Title;
                //_meta.Description = data.Description;
                //_meta.ImageUrl = data.PicThumb;
                _meta.PageUrl = "/chinh-sach/" + data.Slug + "/";
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
