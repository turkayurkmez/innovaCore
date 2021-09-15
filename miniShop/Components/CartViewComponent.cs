using Microsoft.AspNetCore.Mvc;
using miniShop.Extensions;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ShoppingCard card)
        {
            //var card = HttpContext.Session.GetJson<ShoppingCard>("card");

            var totalItemsInCard = card?.Card.Count;

            return View(totalItemsInCard);
        }
    }
}
