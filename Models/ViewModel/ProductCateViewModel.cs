namespace VinaOfficeWebsite.Models.ViewModel
{
    public class ProductCateViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string PicThumb { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public long ? Price { get; set; }
        public string PriceString { get; set; }
    }
}
