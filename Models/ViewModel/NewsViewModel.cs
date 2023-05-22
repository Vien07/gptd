namespace VinaOfficeWebsite.Models.ViewModel
{
    public class NewsViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string PicThumb { get; set; }
        public string PicFull { get; set; }
        public short? IsPic { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }
}
