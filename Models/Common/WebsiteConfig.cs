namespace VinaOfficeWebsite.Models.Common
{
    public class WebsiteConfig
    {
        public string WebsiteName { get; set; }
        public string RootDomain { get; set; }
        public string RootDomainAdmin { get; set; }
        public string Robots { get; set; }
        public string Recaptcha { get; set; }
        public string ReCAPTCHASite { get; set; }
        public string ReCAPTCHASecret { get; set; }

        public string SmtpSender { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPassword { get; set; }
        public string SmtpPort { get; set; }
        public string EmailAdmin { get; set; }
        public string EmailHeader { get; set; }
        public string EmailFooter { get; set; }

        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Tiktok { get; set; }
        public string Zalo { get; set; }
        public string PhoneNumber { get; set; }
    }
}
