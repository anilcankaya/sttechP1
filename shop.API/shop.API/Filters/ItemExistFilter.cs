using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using shop.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Filters
{
    public class ItemExistFilter : IAsyncActionFilter //ActionFilterAttribute: Eğer dependency injection OLMASAYDI bu Attribute'ü kullanabilirdiniz.
    {
        private IProductService productService;

        public ItemExistFilter(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Amaç: Id'si verilen ürün var mı yok mu?
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new NotFoundResult();
                return;
            }

            if (!(context.ActionArguments["id"] is int id))
            {
                context.Result = new NotFoundResult();
                return;
            }

            var isExist = productService.IsProductExist(id);
            if (!isExist)
            {
                context.Result = new NotFoundObjectResult(new { message = $"{id} id'li bir ürün yok." });
                return;
            }

            await next();
        }
    }

    public class ExFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
