using Azure;
using Microsoft.AspNetCore.Mvc;
using VinaOfficeWebsite.Constants;
using VinaOfficeWebsite.Dto;
using VinaOfficeWebsite.Models.ViewModel;
using VinaOfficeWebsite.Repository;
using X.PagedList;

namespace VinaOfficeWebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contact;
        private readonly ICommonRepository _common;
        public ContactController(IContactRepository contact, ICommonRepository common)
        {
            _contact = contact;
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
                MetaDto _meta = new MetaDto();
                _meta.PageTitle = "Liên hệ";
                _meta.OgType = WebConstants.OgTypeWebsite;
                ViewBag.Meta = _common.GetMeta(_meta);

                return View();
            }
            catch
            {
                return View("~/Views/Error/Page404.cshtml");
            }
        }
        [HttpPost]
        public JsonResult Send(ContactDto data)
        {
            var res = _contact.Send(data);
            return new JsonResult(new { response = res });
        }
    }
}
