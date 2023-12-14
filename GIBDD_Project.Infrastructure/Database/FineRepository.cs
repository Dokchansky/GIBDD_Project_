using GIBDD_Project.Infrastructure.Mappers;
using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GIBDD_Project.Infrastructure.Database
{
    public partial class FineRepository
    {
        public List<FineViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Fines.ToList();
                return FineMapper.Map(items);
            }
        }
        public List<FineViewModel> GetByFineId(long id)
        {
            using (var context = new Context())
            {
                var item = context.Fines.Where(x => x.TransportID == id).ToList();
                return FineMapper.Map(item);
            }
        }
        public FineViewModel Add(FineViewModel viewModel)
        {
            using (var context = new Context())
            {
                var entity = FineMapper.Map(viewModel);

                context.Fines.Add(entity);
                context.SaveChanges();

                return FineMapper.Map(entity);
            }
        }
        public List<FineViewModel> Search(string search)// Метод для поиска клиентов по имени в базе данных.
        {
            search = search.Trim().ToLower();  // Обрезка строки поиска и приведение к нижнему регистру.

            using (var context = new Context())
            {
                var result = context.Fines.Include(x => x.Transport).Where(x => x.Name.ToLower().Contains(search) && x.Name.Length == search.Length).ToList();
                return FineMapper.Map(result);
            }

        }
    }
}
