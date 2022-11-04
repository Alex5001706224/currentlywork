using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Build.ObjectModelRemoting;

namespace OnlineShoppingWeb.Filters
{
    public class SampleExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment hostEnvironment;
        public SampleExceptionFilter(IHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
        public void OnException(ExceptionContext context)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return;
            }
            context.Result = new ContentResult
            {
                Content = context.Exception.Message
            };
        }
    }
}
