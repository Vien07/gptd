namespace VinaOfficeWebsite.Models
{
    public class Response<TModel>
    {
        public bool isError { get; set; } = false;
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public TModel Data { get; set; }
    }
    public class Response
    {
        public bool isError { get; set; } = false;
        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
}