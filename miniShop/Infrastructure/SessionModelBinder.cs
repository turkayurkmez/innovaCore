using Microsoft.AspNetCore.Mvc.ModelBinding;
using miniShop.Extensions;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Infrastructure
{
   
    public class SessionModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException();
            }
            var card = bindingContext.HttpContext.Session.GetJson<ShoppingCard>("card");

            //bindingContext.ValueProvider.GetValue
            bindingContext.Result = ModelBindingResult.Success(card);

            return Task.CompletedTask;
        }
    }

    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(ShoppingCard))
            {
                return new SessionModelBinder();
            }
            else
            {
                return null;
            }
        }
    }
}
