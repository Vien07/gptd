using VinaOfficeWebsite.Models.ViewModel;
using VinaOfficeWebsite.Database;
using Microsoft.Extensions.Configuration;
using VinaOfficeWebsite.Models.Common;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Org.BouncyCastle.Crypto.Generators;
using System.Diagnostics.Metrics;
using VinaOfficeWebsite.Dto;
using VinaOfficeWebsite.Models;
using VinaOfficeWebsite.Constants;

namespace VinaOfficeWebsite.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly BzVinaofficeContext _db;
        private readonly ICommonRepository _common;
        private readonly SystemConfig _config;

        public ContactRepository(BzVinaofficeContext db, ICommonRepository common, IOptions<SystemConfig> options)
        {
            _db = db;
            _common = common;
            _config = options.Value;
        }

        public Response Send(ContactDto data)
        {
            Response rs = new Response();
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var newContact = new BzContact();
                    newContact.Subject = _common.RemoveHtmlTag(data.Subject);
                    newContact.Content = _common.RemoveHtmlTag(data.Content);
                    newContact.NameFull = _common.RemoveHtmlTag(data.FullName);
                    newContact.Phone = _common.RemoveHtmlTag(data.PhoneNumber);
                    newContact.Email = _common.RemoveHtmlTag(data.Email);
                    newContact.Address = "";
                    newContact.Company = "";
                    newContact.Fax = "";
                    newContact.PostedDate = DateTime.Now;
                    newContact.Enabled = 1;
                    _db.BzContacts.Add(newContact);
                    _db.SaveChanges();
                    transaction.Commit();

                    //send mail đến khách hàng
                    _common.SendMail(data.Email, "Email liên hệ từ website vinaoffice.com", "Nội dung liên hệ của bạn đã gửi tới ban quản trị website. Chúng tôi sẽ liên hệ trong thời gian sớm nhất.");

                    //send mail đến admin
                    string sMessAdmin = data.Subject + "<br/>Email: " + data.Email + "<br/>Số điện thoại: " + data.PhoneNumber + "<br/>" + data.Content;
                    _common.SendMail(WebConstants.EmailAdmin, "Email liên hệ từ website vinaoffice.com", sMessAdmin);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    rs.isError = true;
                    rs.Message = "Có lỗi xảy ra trong quá trình đăng ký! Vui lòng liên hệ với vinaoffice.com.";
                }
            }
            return rs;
        }
    }
}
