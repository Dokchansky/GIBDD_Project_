using GIBDD_Project.Infrastructure.Mappers;
using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Database
{
    public class TransportRepository
    {
        public List<TransportViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Transports.ToList();
                return TransportMapper.Map(items);
            }
        }

        public object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
        public List<TransportViewModel> GetByTransportId(long id)
        {
            using (var context = new Context())
            {
                var item = context.Transports.Where(x => x.ID == id).ToList();
                return TransportMapper.Map(item);
            }
        }


    }
}
