using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;
using MyShop.DataLayer.Entities;


namespace MyShop.Web.Pages.Admin.Stock

{
    public class AddStockForOperativeModel : PageModel
    {

        private IAgentService _agentService;
        private IStockService _stockService;
        public AddStockForOperativeModel(IAgentService agentService, IStockService stockService)
        {
            _agentService = agentService;
            _stockService = stockService;
        }


        public List<DataLayer.Entities.Operative> AgentForAdminViewModel { get; set; }
        public void OnGet(int id)
        {
            ViewData["Agents"] = _agentService.GetAllOperatives();
            ViewData["StoreId"]= id;

        }
        public IActionResult OnPost(int AgentId,string  ShenaseAnbar,string StoreName)
        {
            var operative = _agentService.GetOperativeById(AgentId);
            DataLayer.Entities.Store store = new Store
            {
               StoreName=StoreName,
               CreateDate=DateTime.Now,
               IsActive=true,
               IsDelete=false,
               ShenaseAnbar= ShenaseAnbar,
               Operative= operative

            };
            _stockService.AddStore(store);
            return RedirectToPage("Index");
        }
    }
}