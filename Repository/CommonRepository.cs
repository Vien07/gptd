using VinaOfficeWebsite.Models;
using VinaOfficeWebsite.Models.Common;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using NLog;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using MailKit.Net.Smtp;
using MailKit.Security;

using System.Reflection;
using System.Security.Claims;
using System.Text;
using static VinaOfficeWebsite.Services.StaticMethod;
using System.Text.RegularExpressions;
using VinaOfficeWebsite.Dto;
using VinaOfficeWebsite.Database;
using Microsoft.Extensions.Options;
using static VinaOfficeWebsite.Constants.WebConstants;


namespace VinaOfficeWebsite.Repository
{
    public class CommonRepository : ICommonRepository
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly BzVinaofficeContext _db;
        private readonly SystemConfig _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommonRepository(BzVinaofficeContext db, IOptions<SystemConfig> options, IHttpContextAccessor httpContextAccessor)
        {
            var absolutepath = Directory.GetCurrentDirectory();//to get current absolute path
            var filePath = Path.Combine(absolutepath + "\\wwwroot\\logger-manager");

            NLog.GlobalDiagnosticsContext.Set("AppDirectory", filePath);
            NLog.Common.InternalLogger.LogFile = Path.Combine(filePath, "nlog-internal.log");
            _db = db;
            _config = options.Value;
            _httpContextAccessor = httpContextAccessor;
        }
        public void LogError(string nameSpace, string method, string errorMess, string data)
        {
            var message = string.Format("{0}.{1}()|ErrorMess:{2}|Data:{3}", nameSpace, method, errorMess, data);
            logger.Error(message);
        }
        public void SendMail(string mail, string subject, string htmlBody)
        {
            try
            {
                var config = _db.BzSiteOptions.Select(t => new { t.Name, t.ValueSelect }).ToDictionary(t => t.Name, t => t.ValueSelect);
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("vinaoffice.com", config["AdminEmail"]));
                message.To.Add(new MailboxAddress(mail, mail));
                message.Subject = subject;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = htmlBody;
                message.Body = bodyBuilder.ToMessageBody();

                ThreadPool.QueueUserWorkItem(t =>
                {
                    using (var client = new SmtpClient())
                    {
                        client.ServerCertificateValidationCallback = (l, j, c, m) => true;
                        client.Connect(config["smtphost"], Convert.ToInt32(config["smtpport"]), SecureSocketOptions.StartTls);
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        client.Authenticate(config["username"], config["emailpwd"]);
                        client.Send(message);
                        client.Disconnect(true);
                        client.Dispose();
                    }
                });
            }
            catch (Exception ex)
            {

            }
        }
        public string ConvertFormatMoney(long? money)
        {
            try
            {
                if (money.HasValue)
                {
                    return money.Value.ToString("#,##0");
                }
                return "0";
            }
            catch (Exception)
            {
                return "0";
            }
        }
        public string StringToSlug(string s)
        {
            try
            {
                Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
                string temp = s.Normalize(NormalizationForm.FormD);
                string tempString = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
                string rs = tempString.ToLower().Trim().Replace(" ", "-");
                char[] chars = @"$%#@ø–!*?;:~`+=()[]{}|\'<>,“”/^&"".&‘’‚“”„†‡‰‹›♠♣♥♦←↑→↓™!#$%'()*+,-./:;<=>?@[\]^_`{|}~-–—-¡¢£¤¥¦§¨©ª«¬®¯°±²³´µ¶·¸¹º»¼½¾¿þÿΑαΒβΓγΔδΕεΖζΗηΘθΙιΚκΛλΜμΝνΞξΟοΠπΡρΣσΤτΥυΦφΧχΨψΩω●•".ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    string strChar = chars.GetValue(i).ToString();
                    if (rs.Contains(strChar))
                    {
                        rs = rs.Replace(strChar, "-");
                    }
                }
                rs = rs.Replace(" ", "-");
                var arr = rs.ToCharArray();
                int kt = 0;
                int tempPos = 2;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (kt > 1)
                    {
                        rs = rs.Remove(i - tempPos, 1);
                        tempPos++;
                    }

                    if (arr[i].ToString() == "-")
                    {
                        kt++;
                    }
                    else
                    {
                        kt = 0;
                    }
                }
                while (rs.ToCharArray()[rs.ToCharArray().Length - 1].ToString() == "-")
                {
                    var rsArr = rs.ToCharArray();
                    if (rsArr[rsArr.Length - 1].ToString() == "-")
                    {
                        rs = rs.Remove(rsArr.Length - 1, 1);
                    }
                    if (rsArr[0].ToString() == "-")
                    {
                        rs = rs.Remove(0, 1);
                    }
                }
                return rs;
            }
            catch (Exception)
            {

                return "";
            }

        }
        public string RemoveHtmlTag(string input)
        {
            try
            {
                return Regex.Replace(input, "<.*?>", String.Empty);
            }
            catch
            {
                return "";
            }
        }
        public string GetMeta(MetaDto data)
        {
            //var website
            string urlImage = _config.AdminUrl;
            string _host = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host;

            string _websiteName = GetConfigValue(WebsiteName);
            string _des = GetConfigValue(MetaDescription);
            string _keyw = GetConfigValue(MetaKeyword);

            if (data.Description == "" || data.Description == null)
            {
                data.Description = _des;
            }

            if (data.Keywords == "" || data.Keywords == null)
            {
                data.Keywords = _keyw;

            }
            data.SiteName = _websiteName; // WebsiteName;
            data.SiteTitle = _websiteName; // WebsiteName;
            data.HomepageUrl = _host;
            var absolutepath = Directory.GetCurrentDirectory();
            var metaTag = "";
            var keywords = "";
            if (data.Keywords != null && data.Keywords != "")
            {
                keywords = "\n<meta name=\"keywords\" content=\"" + data.Keywords.Trim() + "\" />";
            }
            if (data.Keywords != null && data.Keywords != "")
            {
                var tagkeyArr = data.Keywords.Split(',');


                foreach (var item in tagkeyArr)
                {
                    metaTag += "\n<meta property=\"article:tag\" content=\"" + item.Trim() + "\"/>";
                }
            }
            var template = Path.Combine(absolutepath + "\\wwwroot\\meta\\" + "meta.html");
            if (File.Exists(template))
            {
                StreamReader sr = new StreamReader(template);
                string content = sr.ReadToEnd(); sr.Close();
                content = content.Replace("{{pageTitle}}", data.PageTitle);
                content = content.Replace("{{description}}", data.Description);
                //content = content.Replace("{{keywords}}", data.Keywords);
                if (String.IsNullOrEmpty(data.PageUrl))
                {
                    content = content.Replace("{{pageUrl}}", _host);
                }
                else
                {
                    content = content.Replace("{{pageUrl}}", _host + data.PageUrl);

                }
                if (String.IsNullOrEmpty(data.ImageUrl))
                {
                    content = content.Replace("{{imageUrl}}", urlImage + "/logo.png");
                }
                else
                {
                    content = content.Replace("{{imageUrl}}", data.ImageUrl);
                }
                content = content.Replace("{{homepageUrl}}", data.HomepageUrl);
                content = content.Replace("{{siteName}}", data.SiteName);
                content = content.Replace("{{siteTitle}}", data.SiteTitle);
                content = content.Replace("{{meta-tag}}", metaTag);
                content = content.Replace("{{meta-keywords}}", keywords);
                content = content.Replace("{{ogType}}", data.OgType);
                content += "\t<meta name=\"author\" content=\"BizMaC\" />";
                content += "\n\t<meta name=\"generator\" content=\"BizMaC(https://www.bizmac.com)\" />";
                content += "\n\t<meta name=\"copyright\" content=\"BizMaC, Thiết kế website chuyên nghiệp\" />";

                if (!data.Is404Page)
                {
                    content += "\n\t<meta name=\"search\" content=\"always\" />";
                    content += "\n\t<meta name=\"distribution\" content=\"BizMaC, Thiết kế website chuyên nghiệp\" />";
                    content += "\n\t<meta name=\"revisit-after\" content=\"1 day\" />";
                    content += "\n\t<meta name=\"robots\" content=\"index,follow\" />";
                }
                else
                {
                    content += "\n\t<meta name=\"search\" content=\"always\" />";
                    content += "\n\t<meta name=\"distribution\" content=\"BizMaC, Thiết kế website chuyên nghiệp\" />";
                    content += "\n\t<meta name=\"revisit-after\" content=\"1 day\" />";
                    content += "\n\t<meta name=\"robots\" content=\"noindex,nofollow\" />";
                    content += "\n\t<meta name=\"googlebot\" content=\"noindex\" />";
                }


                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = content;
                return bodyBuilder.HtmlBody;
            }
            return "";
        }
        public string GetConfigValue(string key)
        {
            try
            {
                return _db.BzSiteOptions.FirstOrDefault(x => x.Name == key).ValueSelect;
            }
            catch
            {
                return "";
            }
        }
        public string GetFacebookAppId()
        {
            return _config.FacebookAppId;
        }
    }
}
