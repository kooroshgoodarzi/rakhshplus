using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.ViewModels;
using MyShop.DataLayer.Entities;

namespace MyShop.Core.Services.Interfaces
{
    public interface IStockService
    {
        List<StoreViewModels> GetAllStore();
        int AddStore(Store model);
        Store GetStoreById(int storId);
    }
}
