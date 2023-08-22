using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VinaOfficeWebsite.Models;
using Microsoft.EntityFrameworkCore;
using VinaOfficeWebsite.Repository;
using VinaOfficeWebsite.Dto;
using static VinaOfficeWebsite.Constants.WebConstants;
using Newtonsoft.Json;

namespace VinaOfficeWebsite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductRepository _product;
    private readonly INewsRepository _news;
    private readonly ICommonRepository _common;

    public HomeController(ILogger<HomeController> logger, IProductRepository product, INewsRepository news, ICommonRepository common)
    {
        _logger = logger;
        _product = product;
        _news = news;
        _common = common;
    }
    public IActionResult Index()
    {
        try
        {
            ViewBag.LatestProductList = _product.GetLatestProductList(5);
            ViewBag.Menu = _product.GetProductMenu();
            ViewBag.Blogs = _news.GetNewsListHome(3);
            ViewBag.ProductCateAndProductList = _product.GetProductCateAndProductList();


            MetaDto _meta = new MetaDto();
            _meta.PageTitle = _common.GetConfigValue(WebsiteName);
            _meta.OgType = OgTypeWebsite;
            ViewBag.Meta = _common.GetMeta(_meta);

            return View();
        }
        catch (Exception ex)
        {
            return View("~/Views/Error/Page404.cshtml");
        }
    }
    public IActionResult Cart()
    {
        try
        {
        
            MetaDto _meta = new MetaDto();
            _meta.PageTitle = _common.GetConfigValue(WebsiteName);
            _meta.OgType = OgTypeWebsite;
            ViewBag.Meta = _common.GetMeta(_meta);

            return View();
        }
        catch (Exception ex)
        {
            return View("~/Views/Error/Page404.cshtml");
        }
    }
    public IActionResult Order()
    {
        try
        {

            MetaDto _meta = new MetaDto();
            _meta.PageTitle = _common.GetConfigValue(WebsiteName);
            _meta.OgType = OgTypeWebsite;
            ViewBag.Meta = _common.GetMeta(_meta);

            return View();
        }
        catch (Exception ex)
        {
            return View("~/Views/Error/Page404.cshtml");
        }
    }
    public JsonResult LoadCart(string data)
    {
        var res = _product.LoadCart(data);
        return new JsonResult(new { response = res });
    }
    public JsonResult SaveOrder(OrderDto order)
    {
        var res = _product.SaveOrder(order);
        return new JsonResult(new { response = res });
    }
}

