using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.ViewModels
{
    public class TransportViewModel
    {
        public long ID { get; set; }
        public string StateNumber { get; set; }
        public string Status { get; set; }
        public string Year { get; set; }
        public long UserID { get; set; }
        public long BrandID { get; set; }
        public string BrandName { get; set; }
        public string CarCategoryName { get; set; }
       

    }
}
