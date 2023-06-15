using VinaOfficeWebsite.Models;
using VinaOfficeWebsite.Models.Common;
using VinaOfficeWebsite.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml;
using Microsoft.Extensions.Options;
using VinaOfficeWebsite.Database;
using SimpleMvcSitemap;

namespace VinaOfficeWebsite.Controllers
{
    public class SitemapController : Controller
    {
        ICommonRepository _common;
        BzVinaofficeContext _db;
        private readonly SystemConfig _config;

        public SitemapController(ICommonRepository common, IOptions<SystemConfig> options, BzVinaofficeContext db)
        {
            _common = common;
            _config = options.Value;
            _db = db;
        }

        public async Task<IActionResult> SitemapXml()
        {

            string host = Request.Scheme + "://" + Request.Host;

            List<SitemapNode> nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Index","Home")) {Priority = 1},
            };

            var products = _db.BzProducts.Where(p => p.Enabled == 1).ToList();
            foreach (var item in products)
            {
                nodes.Add(new SitemapNode(host + "/chi-tiet-" + _common.StringToSlug(item.TitleVn) + ".html") { Priority = 0.5M });
            }

            var news = _db.BzLists.Where(p => p.Enabled == 1).ToList();
            foreach (var item in news)
            {
                nodes.Add(new SitemapNode(host + "/blogs/" + _common.StringToSlug(item.TitleVn) + ".html") { Priority = 0.5M });
            }

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }


        public IActionResult RobotServices()
        {
            try
            {
                string host = Request.Scheme + "://" + Request.Host;
                var result = "";
                string DisallowRobots = "User-agent: * \nAllow: /\nSitemap: " + host + "/sitemap.xml\nDisallow: https://id.vinaoffice.com/webadmin";
                if (_config.Robots == true)
                {
                    result = DisallowRobots;
                }
                else
                {
                    result = "User-agent:* \r\n Disallow:/ ";
                }
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                return Ok("");
            }
        }

    }
}
