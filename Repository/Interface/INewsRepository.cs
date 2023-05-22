
using VinaOfficeWebsite.Models;
using VinaOfficeWebsite.Models.Common;
using VinaOfficeWebsite.Models.ViewModel;
using X.PagedList;

namespace VinaOfficeWebsite.Repository
{
    public interface INewsRepository
    {
        List<NewsViewModel> GetNewsListHome(int limit);
        List<NewsViewModel> GetRelatedNewsList();
        List<NewsViewModel> GetNewsList();
        NewsViewModel GetNews(string slug);
    }
}