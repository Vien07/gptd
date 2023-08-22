using VinaOfficeWebsite.Models.ViewModel;
using VinaOfficeWebsite.Database;
using Microsoft.Extensions.Configuration;
using VinaOfficeWebsite.Models.Common;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Policy;
using System.Web;
using VinaOfficeWebsite.Constants;
using VinaOfficeWebsite.Dto;
using VinaOfficeWebsite.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net.Mail;
using NLog.Fluent;

namespace VinaOfficeWebsite.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly BzVinaofficeContext _db;
        private readonly ICommonRepository _common;
        private readonly SystemConfig _config;
        public ProductRepository(BzVinaofficeContext db, ICommonRepository common, IOptions<SystemConfig> options)
        {
            _db = db;
            _common = common;
            _config = options.Value;
        }
        public List<ProductViewModel> GetLatestProductList(int limit)
        {
            try
            {

                var model = _db.BzProducts.Where(x => x.Enabled == 1).OrderByDescending(x => x.Order).Select(x => new ProductViewModel
                {
                    Id = x.ProductId,
                    Title = x.TitleVn,
                    Description = x.DesVn,
                    Price = x.Price,
                    PriceString = "0",
                    PicThumb = _config.AdminUrl + "/images/product/" + x.PicThumb,
                    PicFull = _config.AdminUrl + "/images/product/" + x.PicFull,
                }).Take(limit).ToList();

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
                    item.Slug = _common.StringToSlug(item.Title);
                }
                return model;
            }
            catch (Exception ex)
            {
                return new List<ProductViewModel>();
            }
        }
        public List<ProductMenuViewModel> GetProductMenu()
        {
            try
            {
                var model = _db.BzMenus.Where(x => x.Enabled == 1).OrderByDescending(x => x.Order).Select(x => new ProductMenuViewModel
                {
                    Name = x.NameVn,
                    Slug = x.Url,
                    Image = _config.AdminUrl + "/images/menu/" + x.FileName,
                }).ToList();
                return model;
            }
            catch
            {
                return new List<ProductMenuViewModel>();
            }
        }
        public List<ProductMenuViewModel> GetProductCate()
        {
            try
            {
                var model = _db.BzProductCates.Where(x => x.Enabled == 1).OrderByDescending(x => x.Order).Select(x => new ProductMenuViewModel
                {
                    Name = x.NameVn,
                    Slug = _common.StringToSlug(x.NameVn),
                }).ToList();
                return model;
            }
            catch
            {
                return new List<ProductMenuViewModel>();
            }
        }
        public Dictionary<ProductCateViewModel, List<ProductViewModel>> GetProductCateAndProductList()
        {
            try
            {
                var dict = new Dictionary<ProductCateViewModel, List<ProductViewModel>>();

                var cateList = _db.BzProductCates.Where(x => x.Enabled == 1 && x.IsShowHome).OrderByDescending(x => x.Order).Select(x => new ProductCateViewModel
                {
                    Id = x.CateId,
                    Title = x.NameVn,
                }).ToList();

                var cateListId = cateList.Select(x => x.Id).ToList();

                var productList = _db.BzProducts.Where(x => x.Enabled == 1 && x.CateId != null && cateListId.Contains(x.CateId.Value)).OrderByDescending(x => x.Order).Select(x => new ProductViewModel
                {
                    Id = x.ProductId,
                    CateId = x.CateId,
                    Title = x.TitleVn,
                    Description = x.DesVn,
                    Price = x.Price,
                    PriceString = "0",
                    PicThumb = _config.AdminUrl + "/images/product/" + x.PicThumb,
                }).ToList();

                foreach (var item in cateList)
                {
                    var products = productList.Where(x => x.CateId == item.Id).Take(8).ToList();

                    foreach (var ele in products)
                    {
                        if (ele.Price == null)
                        {
                            ele.Price = 0;
                            ele.PriceString = "0";
                        }
                        else
                        {
                            ele.PriceString = _common.ConvertFormatMoney(ele.Price);
                        }

                        ele.Slug = _common.StringToSlug(ele.Title);
                    }
                    dict.Add(item, products);
                }
                return dict;
            }
            catch
            {
                return new Dictionary<ProductCateViewModel, List<ProductViewModel>>();
            }
        }
        public List<WareImageViewModel> GetWareImageList()
        {
            try
            {
                var model = _db.BzKhos.Where(x => x.Enabled == 1).OrderByDescending(x => x.Order).Select(x => new WareImageViewModel
                {
                    Image = _config.AdminUrl + "/images/stored/" + x.FileName,
                    Link = x.Url,
                }).ToList();
                return model;
            }
            catch
            {
                return new List<WareImageViewModel>();
            }
        }
        public List<SupportViewModel> GeSupportList()
        {
            try
            {
                var model = _db.BzSupports.Where(x => x.Enabled == 1).Select(x => new SupportViewModel
                {
                    Image = _config.AdminUrl + "/images/support/" + x.Images,
                    Name = x.NameFull,
                    Skype = x.Skype,
                    Zalo = x.Zalo,
                    Viber = x.Viber,
                    Phone = x.Phone,
                }).ToList();
                return model;
            }
            catch
            {
                return new List<SupportViewModel>();
            }
        }
        public List<ProductViewModel> GetProductList()
        {
            try
            {

                var model = _db.BzProducts.Where(x => x.Enabled == 1).OrderByDescending(x => x.Order).Select(x => new ProductViewModel
                {
                    Id = x.ProductId,
                    Title = x.TitleVn,
                    Description = x.DesVn,
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
                }

                return model;
            }
            catch
            {
                return new List<ProductViewModel>();
            }
        }
        public List<ProductViewModel> GetProductListByKey(string key)
        {
            try
            {
                var data = new List<ProductViewModel>();

                var keySlug = _common.StringToSlug(key);

                var model = _db.BzProducts.Where(x => x.Enabled == 1).OrderByDescending(x => x.Order).Select(x => new ProductViewModel
                {
                    Id = x.ProductId,
                    Title = x.TitleVn,
                    Slug = _common.StringToSlug(x.TitleVn),
                    Description = x.DesVn,
                    Price = x.Price,
                    PriceString = "0",
                    PicThumb = _config.AdminUrl + "/images/product/" + x.PicThumb,
                }).ToList();

                foreach (var item in model)
                {
                    if (item.Slug.Contains(keySlug))
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
                        data.Add(item);
                    }
                }
                return data;
            }
            catch
            {
                return new List<ProductViewModel>();
            }
        }
        public List<ProductViewModel> GetProductListBySlug(string slug, ref ProductCateViewModel cateViewModel)
        {
            try
            {
                long cateId = 0;
                var cateList = _db.BzProductCates.Where(x => x.Enabled == 1).ToList();
                foreach (var cate in cateList)
                {
                    if (slug == _common.StringToSlug(cate.NameVn))
                    {
                        cateViewModel = new ProductCateViewModel() { Id = cate.CateId, Title = cate.NameVn, Slug = slug, Description = System.Net.WebUtility.HtmlDecode(cate.DesVn) };
                        cateId = cate.CateId;
                        break;
                    }
                }

                var model = _db.BzProducts.Where(x => x.Enabled == 1 && x.CateId == cateId).OrderByDescending(x => x.Order).Select(x => new ProductViewModel
                {
                    Id = x.ProductId,
                    Title = x.TitleVn,
                    Description = x.DesVn,
                    Price = x.Price,
                    PriceString = "0",
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
                    item.Slug = _common.StringToSlug(item.Title);
                }
                return model;
            }
            catch
            {
                return new List<ProductViewModel>();
            }
        }
        public List<ProductCateViewModel> GetProductCateList()
        {
            try
            {
                var model = _db.BzProductCates.Where(x => x.Enabled == 1).OrderByDescending(x => x.Order).Select(x => new ProductCateViewModel
                {
                    Id = x.CateId,
                    Title = x.NameVn,
                }).ToList();

                foreach (var item in model)
                {
                    item.Slug = _common.StringToSlug(item.Title);
                }
                return model;
            }
            catch
            {
                return new List<ProductCateViewModel>();
            }
        }
        public ProductViewModel GetProduct(string slug)
        {
            try
            {
                var products = _db.BzProducts.Where(x => x.Enabled == 1).ToList();
                long productId = 0;
                foreach (var item in products)
                {
                    if (slug == _common.StringToSlug(item.TitleVn))
                    {
                        productId = item.ProductId;
                    }
                }

                var model = _db.BzProducts.Where(x => x.ProductId == productId).Select(x => new ProductViewModel
                {
                    Id = x.ProductId,
                    Title = x.TitleVn,
                    PicFull = _config.AdminUrl + "/images/product/" + x.PicFull,
                    PicThumb = _config.AdminUrl + "/images/product/" + x.PicThumb,
                    Description = System.Net.WebUtility.HtmlDecode(x.DesVn),
                    Content = System.Net.WebUtility.HtmlDecode(x.ContentVn),
                    Price = x.Price,
                    CateId = x.CateId,
                    Slug = _common.StringToSlug(x.TitleVn),
                    PriceString = "0",
                }).FirstOrDefault();


                var cate = _db.BzProductCates.Where(x => x.CateId == model.CateId).FirstOrDefault();
                model.CateName = cate.NameVn;
                model.CateSlug = _common.StringToSlug(cate.NameVn);

                if (model.Price == null)
                {
                    model.Price = 0;
                    model.PriceString = "0";
                }
                else
                {
                    model.PriceString = _common.ConvertFormatMoney(model.Price);
                }

                model.Pictures = new List<ProductPicture>();
                var pictures = _db.BzProductPictures.Where(x => x.ProductId == model.Id).OrderByDescending(x => x.Order).ToList();
                foreach (var ele in pictures)
                {
                    model.Pictures.Add(new ProductPicture
                    {
                        PicThumb = _config.AdminUrl + "/images/product/" + ele.PicThumb,
                        PicFull = _config.AdminUrl + "/images/product/" + ele.PicFull,
                    });
                }

                return model;
            }
            catch
            {
                return null;
            }
        }
        public List<ProductViewModel> GetRelatedList(long cateId, string slug)
        {
            try
            {
                var model = _db.BzProducts.Where(x => x.Enabled == 1 && x.CateId == cateId).OrderByDescending(x => x.Order).Select(x => new ProductViewModel
                {
                    Id = x.ProductId,
                    Title = x.TitleVn,
                    Description = x.DesVn,
                    Slug = _common.StringToSlug(x.TitleVn),
                    Price = x.Price,
                    PriceString = "0",
                    PicThumb = _config.AdminUrl + "/images/product/" + x.PicThumb,
                }).Take(13).ToList();

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
                    item.Slug = _common.StringToSlug(item.Title);
                }
                model = model.Where(x => x.Slug != slug).ToList();
                model = model.Take(12).ToList();
                return model;
            }
            catch
            {
                return new List<ProductViewModel>();
            }
        }
        public Response<CartViewModel> LoadCart(string data)
        {
            Response<CartViewModel> rs = new Response<CartViewModel>();
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    rs.isError = true;
                    rs.Message = "Có lỗi xảy ra trong quá trình đăng ký! Vui lòng liên hệ với Vinaoffice nhé.";
                }

                var carts = JsonConvert.DeserializeObject<List<CartDto>>(data);

                var productIds = carts.Select(x => x.ProductId).ToList();

                var model = _db.BzProducts.Where(x => x.Enabled == 1 && productIds.Contains(x.ProductId)).OrderByDescending(x => x.Order).Select(x => new Items
                {
                    ProductId = x.ProductId,
                    Title = x.TitleVn,
                    Price = x.Price,
                    PriceString = "0",
                    Image = _config.AdminUrl + "/images/product/" + x.PicThumb,
                }).ToList();

                foreach (var item in model)
                {
                    item.Quantity = carts.Where(x => x.ProductId == item.ProductId).FirstOrDefault().Quantity;
                    if (item.Price == null)
                    {
                        item.Price = 0;
                        item.PriceString = "0";
                    }
                    else
                    {
                        item.PriceString = _common.ConvertFormatMoney(item.Price);
                        item.Price = item.Price;
                        item.TotalPrice = item.Price * item.Quantity;
                        item.TotalPriceString = _common.ConvertFormatMoney(item.TotalPrice);
                    }

                }
                var cartViewModel = new CartViewModel();
                cartViewModel.TotalQuantity = model.Count;
                cartViewModel.Items = model;
                cartViewModel.TotalPrice = model.Sum(x => x.TotalPrice).Value;
                cartViewModel.TotalPriceString = _common.ConvertFormatMoney(model.Sum(x => x.TotalPrice).Value);

                rs.Data = cartViewModel;
            }
            catch (Exception ex)
            {
                rs.isError = true;
                rs.Message = "Có lỗi xảy ra trong quá trình đăng ký! Vui lòng liên hệ với Vinaoffice nhé.";
            }
            return rs;
        }
        public Response<CartViewModel> SaveOrder(OrderDto order)
        {
            Response<CartViewModel> rs = new Response<CartViewModel>();
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var tableProduct = "";

                    if (string.IsNullOrEmpty(order.Cart))
                    {
                        rs.isError = true;
                        rs.Message = "Không có sản phẩm trong giỏ hàng. Cần hỗ trợ vui lòng liên hệ vinaoffice nhé";
                        return rs;
                    }

                    CartViewModel cartInfo = null;

                    var getCartInfo = LoadCart(order.Cart);

                    if (getCartInfo.Data != null)
                    {
                        cartInfo = getCartInfo.Data;
                    }
                    else
                    {
                        rs.isError = true;
                        rs.Message = getCartInfo.Message;
                        return rs;
                    }

                    string orderCode = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString();
                    var bzOrderNew = new BzOrderNew();
                    bzOrderNew.FullName = order.FullName;
                    bzOrderNew.Address = order.Address;
                    bzOrderNew.Phone = order.PhoneNumber;
                    bzOrderNew.Email = order.Email;
                    bzOrderNew.Subject = order.Note;
                    bzOrderNew.Fax = orderCode;
                    bzOrderNew.PostedDate = DateTime.Now;
                    bzOrderNew.Status = 1;
                    if (order.IsCOD == "1")
                    {
                        bzOrderNew.Payment = 0;
                    }
                    else
                    {
                        bzOrderNew.Payment = 1;

                    }
                    _db.BzOrderNews.Add(bzOrderNew);
                    _db.SaveChanges();

                    foreach (var item in cartInfo.Items)
                    {
                        var bzOrderNewProduct = new BzOrderNewProduct();
                        bzOrderNewProduct.ProductId = item.ProductId;
                        bzOrderNewProduct.Quantity = item.Quantity;
                        bzOrderNewProduct.Price = Convert.ToInt32(item.Price);
                        bzOrderNewProduct.OrderId = bzOrderNew.OrderId;
                        _db.BzOrderNewProducts.Add(bzOrderNewProduct);
                        _db.SaveChanges();

                        tableProduct += "<tr>"
                         + "<td style=\"border:none;background:white;padding:5px\">"
                         + "<p class=\"MsoNormal\">"
                         + "<a class=\"product-image\" href=\"http://www.vinaoffice.com/chi-tiet-" + _common.StringToSlug(item.Title) + ".html\">"
                         + "<img  src=\"" + item.Image + "\" width=\"50\" /></a></p>"
                         + "</td>"
                          + "<td style=\"border:none;background:white;padding:5px;color:green\">"
                         + "<p class=\"MsoNormal\"><strong>" + item.Title + "</strong></p>"
                         + "</td>"
                          + "<td style=\"border:none;background:white;padding:5px;text-align:center\">"
                         + "<p class=\"MsoNormal\">" + item.Quantity + "</p>"
                         + "</td>"
                        + "<td style=\"border:none;background:white;padding:5px;text-align:right\">"
                         + "<p class=\"MsoNormal\">" + item.PriceString + "</p>"
                         + "</td>"
                        + "</tr>";

                    }

                    tableProduct += "<tr style=\"mso-yfti-irow:0;mso-yfti-firstrow:yes\">"
                        + "<td colspan=\"3\" style=\"width:120.0pt;border:none;background:#FBFAFE;"
                        + "padding:5px;text-align:right;\">"
                        + "<p class=\"MsoNormal\"><strong style=\"mso-fareast-font-family:Times New Roman\">TỔNG TỀN</strong></p>"
                        + "</td>"
                        + "<td width=\"160\" style=\"width:120.0pt;border:none;background:#FBFAFE;"
                        + "padding:5px;text-align:right;font-size:20PX\">"
                        + "<p class=\"MsoNormal\"><strong style=\"mso-fareast-font-family:Times New Roman;color:green\">" + cartInfo.TotalPriceString + "</strong></p>"
                        + "</td>"
                       + "</tr>";

                    transaction.Commit();

                    //nội dung mail
                    var absolutepath = Directory.GetCurrentDirectory();
                    var emailTemplateSendAdmin = Path.Combine(absolutepath + "\\wwwroot\\email\\EmailTemplateAdmin.htm");
                    StreamReader sr = new StreamReader(emailTemplateSendAdmin);
                    string content = sr.ReadToEnd();
                    content = content.Replace("{UserName}", order.FullName);
                    content = content.Replace("{content}", tableProduct);
                    content = content.Replace("{OrderCode}", orderCode + bzOrderNew.OrderId);
                    content = content.Replace("{NameFull}", order.FullName);
                    content = content.Replace("{Phone}", order.PhoneNumber);
                    content = content.Replace("{Address}", order.Address);
                    content = content.Replace("{Email}", order.Email);
                    content = content.Replace("{Note}", System.Net.WebUtility.HtmlDecode(order.Note));

                    //send mail to customer
                    if (!string.IsNullOrEmpty(order.Email))
                    {
                        _common.SendMail(order.Email, "[Vinaoffice] Xác nhận đơn đặt hàng", content);
                    }

                    //send mail to admin

                    _common.SendMail(WebConstants.EmailAdmin, "Đơn đặt hàng mới từ vinaoffice.com", content);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    rs.isError = true;
                    rs.Message = "Có lỗi xảy ra trong quá trình đăng ký! Vui lòng liên hệ với Vinaoffice nhé.";
                }
            }

            return rs;
        }
    }
}
