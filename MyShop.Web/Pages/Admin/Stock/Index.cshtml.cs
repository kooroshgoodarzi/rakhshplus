using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;
using MyShop.Core.ViewModels;

namespace MyShop.Web.Pages.Admin.Stock
{
    public class IndexModel : PageModel
    {
        private IStockService _stockService;

        public IndexModel(IStockService stockService)
        {
            _stockService = stockService;
        }

        public List<StoreViewModels> StoreViewModels { get; set; }
        public void OnGet()
        {
            StoreViewModels = _stockService.GetAllStore();
        }
    }
}
