using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShop.Core.Convertors;
using MyShop.Core.Generators;
using MyShop.Core.Security;
using MyShop.Core.Services.Interfaces;
using MyShop.Core.ViewModels;
using MyShop.DataLayer.Context;
using MyShop.DataLayer.Entities;

namespace MyShop.Core.Services
{
    public class StockService : IStockService
    {
        private MyShopContext _context;

        public StockService(MyShopContext context)
        {
            _context = context;
        }
      public int AddStore(Store model)
        {
            _context.Stores.Add(model);
            return _context.SaveChanges();
        }

        public Store GetStoreById(int storId)
        {
            return _context.Stores.Find(storId);
        }
       
        public List<StoreViewModels> GetAllStore()
        {

            var agentStore = from a in _context.Agents
                             join s in _context.Stores
                             on a.AgentId equals s.Agent.AgentId
                             select (new StoreViewModels
                             {
                                 Agentname=a.Name,
                                 CreateDate=DateConvertor.ToShamsi(s.CreateDate),
                                 ShenaseAnbar = s.ShenaseAnbar,
                                 StoreName = s.StoreName,
                                 StoreId=s.StoreId,
                                 AgentType="نماینده"
                             }
                             );
            var operateStore = from a in _context.Operatives
                             join s in _context.Stores
                             on a.OperativeId equals s.Operative.OperativeId
                             select (new StoreViewModels
                             {
                                 Agentname = a.Name,
                                 CreateDate = DateConvertor.ToShamsi(s.CreateDate),
                                 ShenaseAnbar = s.ShenaseAnbar,
                                 StoreName = s.StoreName,
                                 StoreId = s.StoreId,
                                 AgentType = "پذیرنده"
                             }
                             );
            var res1 = agentStore.ToList();
            var res2 = operateStore.ToList();
            return  res1.Union(res2).ToList();
        }
       
    }
}
