using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels
{
    public class AgentViewModel
    {
        public int AgentID { get; set; }
        public string FirstName { get; set; }
        public string UserAvatar { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public string Mobile { get; set; }

        public string UserName { get; set; }

        public string CityName { get; set; }
        public string ProvinceName { get; set; }
        public bool IsActive { get; set; }
        public string ContractNo { get; set; }
        public string Description { get; set; }

        public float AgentPercent { get; set; }

        public string AgentName { get; set; }
        public DateTime CreateDate { get; set; }
        public string ActivityName { get; set; }

    }
}
