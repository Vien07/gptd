
using VinaOfficeWebsite.Dto;
using VinaOfficeWebsite.Models;
using VinaOfficeWebsite.Models.Common;
using VinaOfficeWebsite.Models.ViewModel;
using X.PagedList;

namespace VinaOfficeWebsite.Repository
{
    public interface IContactRepository
    {
        Response Send(ContactDto data);
    }
}