
using VinaOfficeWebsite.Models;
using VinaOfficeWebsite.Models.Common;
using VinaOfficeWebsite.Models.ViewModel;
using X.PagedList;

namespace VinaOfficeWebsite.Repository
{
    public interface IAboutRepository
    {
        List<AboutViewModel> GetList();
        List<AboutViewModel> GetListTopMenu();
        List<AboutViewModel> GetPolicyList();
        AboutViewModel GetAbout(string slug);
        AboutViewModel GetPolicy(string slug);
    }
}