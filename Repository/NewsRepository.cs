using VinaOfficeWebsite.Models.ViewModel;
using VinaOfficeWebsite.Database;
using Microsoft.Extensions.Configuration;
using VinaOfficeWebsite.Models.Common;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly BzVinaofficeContext _db;
        private readonly ICommonRepository _common;
        private readonly SystemConfig _config;

        public NewsRepository(BzVinaofficeContext db, ICommonRepository common, IOptions<SystemConfig> options)
        {
            _db = db;
            _common = common;
            _config = options.Value;
        }

        public List<NewsViewModel> GetNewsListHome(int limit)
        {
            try
            {
                var model = _db.BzLists.Where(x => x.Enabled == 1 && x.Level == 1).OrderByDescending(x => x.Order).Select(x => new NewsViewModel
                {
                    Title = x.TitleVn,
                    Description = x.DesVn,
                    Slug = _common.StringToSlug(x.TitleVn),
                    PicThumb = _config.AdminUrl + "/images/news/thumb/" + x.PicThumb,
                }).Take(limit).ToList();
                return model;
            }
            catch
            {
                return new List<NewsViewModel>();
            }
        }
        public List<NewsViewModel> GetNewsList()
        {
            try
            {
                var model = _db.BzLists.Where(x => x.Enabled == 1 && x.Level == 1).OrderByDescending(x => x.Order).Select(x => new NewsViewModel
                {
                    Title = x.TitleVn,
                    Slug = _common.StringToSlug(x.TitleVn),
                    Description = x.DesVn,
                    PicThumb = _config.AdminUrl + "/images/news/thumb/" + x.PicThumb,
                    IsPic = x.IsPicture,
                }).ToList();


                foreach (var item in model)
                {
                    if (item.IsPic == null && item.IsPic == 0)
                    {
                        item.PicThumb = "/logo.png";
                    }
                }

                return model;
            }
            catch
            {
                return new List<NewsViewModel>();
            }
        }
        public NewsViewModel GetNews(string slug)
        {
            try
            {
                var newsList = _db.BzLists.Where(x => x.Enabled == 1 && x.Level == 1).ToList();
                long newsId = 0;
                foreach (var item in newsList)
                {
                    if (slug == _common.StringToSlug(item.TitleVn))
                    {
                        newsId = item.ListId;
                    }
                }

                var model = _db.BzLists.Where(x => x.ListId == newsId).Select(x => new NewsViewModel
                {
                    Id = x.ListId,
                    Title = x.TitleVn,
                    Slug = _common.StringToSlug(x.TitleVn),
                    PicFull = _config.AdminUrl + "/images/news/full/" + x.PicFull,
                    PicThumb = _config.AdminUrl + "/images/news/thumb/" + x.PicThumb,
                    Description = System.Net.WebUtility.HtmlDecode(x.DesVn),
                    Content = System.Net.WebUtility.HtmlDecode(x.ContentVn),
                }).FirstOrDefault();

                return model;
            }
            catch
            {
                return null;
            }
        }
        public List<NewsViewModel> GetRelatedNewsList()
        {
            try
            {
                var r = new Random();
                var model = _db.BzLists.Where(x => x.Enabled == 1 && x.Level == 1).OrderBy(x => r.NextDouble()).Select(x => new NewsViewModel
                {
                    Title = x.TitleVn,
                    Slug = _common.StringToSlug(x.TitleVn),
                    Description = x.DesVn,
                    PicThumb = _config.AdminUrl + "/images/news/thumb/" + x.PicThumb,
                }).Take(5).ToList();

                return model;
            }
            catch
            {
                return new List<NewsViewModel>();
            }
        }
    }
}
