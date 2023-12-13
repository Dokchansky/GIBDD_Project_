using GIBDD_Project.Infrastructure.Mappers;
using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Database
{
    public class GIBDDRepository
    {
        public List<GIBDDViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.GIBDDs.ToList();
                return GIBDDMapper.Map(items);
            }
        }
        public GIBDDViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.GIBDDs.FirstOrDefault(x => x.ID == id);
                return GIBDDMapper.Map(item);
            }
        }
    }
}
