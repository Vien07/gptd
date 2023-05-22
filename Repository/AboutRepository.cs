using VinaOfficeWebsite.Models.ViewModel;
using VinaOfficeWebsite.Database;
using Microsoft.Extensions.Configuration;
using VinaOfficeWebsite.Models.Common;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Repository
{
    public class AboutRepository : IAboutRepository
    {
        private readonly BzVinaofficeContext _db;
        private readonly ICommonRepository _common;
        private readonly SystemConfig _config;

        public AboutRepository(BzVinaofficeContext db, ICommonRepository common, IOptions<SystemConfig> options)
        {
            _db = db;
            _common = common;
            _config = options.Value;
        }
        public List<AboutViewModel> GetList()
        {
            try
            {
                var model = _db.BzAboutLists.Where(x => x.Enabled == 1).OrderByDescending(x => x.Order).Select(x => new AboutViewModel
                {
                    Title = x.TitleVn,
                    Slug = _common.StringToSlug(x.TitleVn)
                }).ToList();

                return model;
            }
            catch
            {
                return new List<AboutViewModel>();
            }
        }
        public List<AboutViewModel> GetListTopMenu()
        {
            try
            {
                var model = _db.BzAboutLists.Where(x => x.Enabled == 1 && x.Top == 1).OrderByDescending(x => x.Order).Select(x => new AboutViewModel
                {
                    Title = x.TitleVn,
                    Slug = _common.StringToSlug(x.TitleVn)
                }).ToList();

                return model;
            }
            catch
            {
                return new List<AboutViewModel>();
            }
        }
        public List<AboutViewModel> GetPolicyList()
        {
            try
            {
                var model = _db.BzLists.Where(x => x.Enabled == 1 && x.Level == 4).OrderByDescending(x => x.Order).Select(x => new AboutViewModel
                {
                    Title = x.TitleVn,
                    Slug = _common.StringToSlug(x.TitleVn)
                }).ToList();
                return model;
            }
            catch
            {
                return new List<AboutViewModel>();
            }
        }
        public AboutViewModel GetAbout(string slug)
        {
            try
            {
                long aboutId = 0;
                var aboutList = _db.BzAboutLists.Where(x => x.Enabled == 1).ToList();
                foreach (var item in aboutList)
                {
                    if (slug == _common.StringToSlug(item.TitleVn))
                    {
                        aboutId = item.AboutId;
                    }
                }

                var model = _db.BzAboutLists.Where(x => x.Enabled == 1 && x.AboutId == aboutId).Select(x => new AboutViewModel
                {
                    Title = x.TitleVn,
                    Slug = _common.StringToSlug(x.TitleVn),
                    Content = System.Net.WebUtility.HtmlDecode(x.ContentVn),
                }).FirstOrDefault();

                return model;
            }
            catch
            {
                return null;
            }
        }
        public AboutViewModel GetPolicy(string slug)
        {
            try
            {
                long policyId = 0;
                var policyList = _db.BzLists.Where(x => x.Enabled == 1 && x.Level == 4).ToList();
                foreach (var item in policyList)
                {
                    if (slug == _common.StringToSlug(item.TitleVn))
                    {
                        policyId = item.ListId;
                    }
                }

                var model = _db.BzLists.Where(x => x.Enabled == 1 && x.ListId == policyId).Select(x => new AboutViewModel
                {
                    Title = x.TitleVn,
                    Slug = _common.StringToSlug(x.TitleVn),
                    Content = System.Net.WebUtility.HtmlDecode(x.ContentVn),
                }).FirstOrDefault();

                return model;
            }
            catch
            {
                return null;
            }
        }
    }
}
