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
    public class AddStockForAgentModel : PageModel
    {

        private IAgentService _agentService;
        private IStockService _stockService;
        public AddStockForAgentModel(IAgentService agentService, IStockService stockService)
        {
            _agentService = agentService;
            _stockService = stockService;
        }


        public List<DataLayer.Entities.Agent> AgentForAdminViewModel { get; set; }
        public void OnGet(int id)
        {
            ViewData["Agents"] = _agentService.GetAllGent();
            ViewData["StoreId"]= id;

        }
        public IActionResult OnPost(int AgentId,string  ShenaseAnbar,string StoreName)
        {
            var agent = _agentService.GetAgentById(AgentId);
            DataLayer.Entities.Store store = new Store
            {
               StoreName=StoreName,
               CreateDate=DateTime.Now,
               IsActive=true,
               IsDelete=false,
               ShenaseAnbar= ShenaseAnbar,
               Agent= agent

            };
            _stockService.AddStore(store);
            return RedirectToPage("Index");
        }
    }
}