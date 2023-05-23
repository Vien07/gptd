
using VinaOfficeWebsite.Dto;
using VinaOfficeWebsite.Models;
using VinaOfficeWebsite.Models.Common;
using VinaOfficeWebsite.Models.ViewModel;
using X.PagedList;

namespace VinaOfficeWebsite.Repository

{
    public interface ICommonRepository
    {
        void LogError(string nameSpace, string method, string errorMess, string data);
        void SendMail(string mail, string subject, string htmlBody);
        string ConvertFormatMoney(long? money);
        string StringToSlug(string s);
        string RemoveHtmlTag(string input);
        string GetMeta(MetaDto data);
        string GetConfigValue(string key);
        string GetFacebookAppId();
    }
}