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
using VinaOfficeWebsite.Models.ViewModel;
using MimeKit.Text;

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

        public IActionResult RssXml()
        {
            var feed = BuildXmlFeed();
            return Content(feed, "text/xml");
        }

        public string BuildXmlFeed()
        {
            string host = Request.Scheme + "://" + Request.Host;

            StringWriter parent = new StringWriter();
            using (XmlTextWriter writer = new XmlTextWriter(parent))
            {
                writer.WriteStartElement("rss");
                writer.WriteAttributeString("xmlns", "g", null, "http://base.google.com/ns/1.0");
                writer.WriteAttributeString("version", "2.0");
                writer.WriteStartElement("channel");
                writer.WriteElementString("title", "Danh sách sản phẩm");
                writer.WriteElementString("link", host + "/san-pham/");
                writer.WriteElementString("description", "Chuyên thiết kế, sản xuất các sản phẩm nội thất văn phòng, bàn ghế văn phòng, bàn ghế nhà hàng khách sạn, trường học theo yêu cầu với đội ngũ chuyên nghiệp");


                var model = _db.BzProducts.Where(x => x.Enabled == 1).OrderByDescending(x => x.Order).Select(x => new ProductViewModel
                {
                    Id = x.ProductId,
                    Title = x.TitleVn,
                    Description = System.Net.WebUtility.HtmlDecode(x.DesVn),
                    Price = x.Price,
                    PriceString = "0",
                    Slug = _common.StringToSlug(x.TitleVn),
                    PicThumb = _config.AdminUrl + "/images/product/" + x.PicThumb,
                }).ToList();

                foreach (var item in model)
                {
                    if (item.Price == null)
                    {
                        item.Price = 0;
                        item.PriceString = "0";
                    }
                    else
                    {
                        item.PriceString = _common.ConvertFormatMoney(item.Price);
                    }

                    writer.WriteStartElement("item");
                    writer.WriteElementString("g", "id", null, item.Id.ToString());
                    writer.WriteElementString("g", "title", null, item.Title);
                    writer.WriteElementString("g", "description", null, item.Description);
                    writer.WriteElementString("g", "link", null, host + "/chi-tiet-" + item.Slug + ".html");
                    writer.WriteElementString("g", "image_link", null, item.PicThumb);
                    writer.WriteElementString("g", "availability", null, "in_stock");
                    if (item.Price != 0)
                    {
                        writer.WriteElementString("g", "price", null, item.Price + " VND");

                    }
                    else
                    {
                        writer.WriteElementString("g", "price", null, "0 VND");

                    }
                    writer.WriteElementString("g", "condition", null, "new");
                    writer.WriteElementString("g", "identifier_exists", null, "no");
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
            }

            return parent.ToString();
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
                nodes.Add(new SitemapNode(host + "/chi-tiet-" + _common.StringToSlug(item.TitleVn) + ".html") { Priority = 0.8M });
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
