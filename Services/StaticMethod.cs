namespace VinaOfficeWebsite.Services
{
    public static class StaticMethod
    {
        public static T ToObject<T>(this IDictionary<string, string> source) where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                try
                {
                    var obj = someObjectType
                    .GetProperty(item.Key);
                    if (obj != null)
                    {
                        obj.SetValue(someObject, item.Value, null);
                    }
                }
                catch
                {

                }
            }

            return someObject;
        }
    }
}
