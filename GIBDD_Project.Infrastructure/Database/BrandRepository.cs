using GIBDD_Project.Infrastructure.Mappers;
using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Database
{
    public partial class BrandRepository
    {
        public List<BrandViewModel> GetList()
        {

            using (var context = new Context())
            {
                var items = context.Brands.ToList();
                return BrandMapper.Map(items);
            }
        }
        public BrandViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Brands.FirstOrDefault(x => x.ID == id);
                return BrandMapper.Map(item);
            }
        }
    }
}
