namespace VinaOfficeWebsite.Models.Common
{
    public class MetaModel
    {
        public string PageTitle { get; set; } /*= WebsiteName;*/
        public string Description { get; set; } /*= MetaDescription;*/
        public string Keywords { get; set; } /*= MetaKeywords;*/
        public string PageUrl { get; set; }
        public string OgType { get; set; }
        public string ImageUrl { get; set; }
        public string HomepageUrl { get; set; } /*= RootDomain;*/
        public string SiteName { get; set; }/* = WebsiteName;*/
        public string SiteTitle { get; set; } /*= WebsiteName;*/
        public bool Is404Page { get; set; } = false;

    }
}
