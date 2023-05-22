
using VinaOfficeWebsite.Dto;
using VinaOfficeWebsite.Models;
using VinaOfficeWebsite.Models.Common;
using VinaOfficeWebsite.Models.ViewModel;
using X.PagedList;

namespace VinaOfficeWebsite.Repository
{
    public interface IProductRepository
    {
        List<ProductViewModel> GetLatestProductList(int limit);
        List<ProductMenuViewModel> GetProductMenu();
        List<ProductMenuViewModel> GetProductCate();
        Dictionary<ProductCateViewModel, List<ProductViewModel>> GetProductCateAndProductList();
        List<WareImageViewModel> GetWareImageList();
        List<SupportViewModel> GeSupportList();
        List<ProductViewModel> GetProductList();
        List<ProductViewModel> GetProductListBySlug(string slug, ref ProductCateViewModel cateViewModel);
        List<ProductCateViewModel> GetProductCateList();
        ProductViewModel GetProduct(string slug);
        List<ProductViewModel> GetRelatedList(long cateId, string slug);
        List<ProductViewModel> GetProductListByKey(string key);

        Response<CartViewModel> LoadCart(string data);
        Response<CartViewModel> SaveOrder(OrderDto order);

    }
}