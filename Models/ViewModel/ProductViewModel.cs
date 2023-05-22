namespace VinaOfficeWebsite.Models.ViewModel
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string PicThumb { get; set; }
        public string PicFull { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public long ? Price { get; set; }
        public long? CateId { get; set; }
        public string  CateName { get; set; }
        public string CateSlug { get; set; }
        public string PriceString { get; set; }
        public string Content { get; set; }
    }
}
