using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json;

namespace DefaultJsonTypeInfoResolverPOC
{
    public class CustomJsonOutputFormatter : SystemTextJsonOutputFormatter
    {
        public CustomJsonOutputFormatter()
        : base(new JsonSerializerOptions()
        {
            TypeInfoResolver = new CustomJsonTypeInfoResolver()
            // Other settings go here
        })
        { }

        public override bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            context.ContentType = "application/json";
            //var myHeader = context.HttpContext.Request.Headers["MyHeader"].ToString();
            //return !string.IsNullOrEmpty(myHeader);
            return true;
        }
    }
}
