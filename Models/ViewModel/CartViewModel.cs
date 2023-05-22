namespace VinaOfficeWebsite.Models.ViewModel
{
    public class CartViewModel
    {
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string TotalPriceString { get; set; }
        public List<Items> Items { get; set; }
    }

    public class Items
    {
        public long ProductId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public long? Price { get; set; }
        public string PriceString { get; set; }
        public long? TotalPrice { get; set; }
        public string TotalPriceString { get; set; }
    }
}
