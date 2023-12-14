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
        public List<TransportViewModel> GetByUserId(long id)
        {
            using (var context = new Context())
            {
                var item = context.Transports.Where(x => x.UserID == id).ToList();
                return TransportMapper.Map(item);
            }
        }
        public List<TransportViewModel> GetByBrandId(long id)
        {
            using (var context = new Context())
            {
                var item = context.Transports.Where(x => x.BrandID == id).ToList();
                return TransportMapper.Map(item);
            }
        }
        public List<TransportViewModel> Search(string search)// Метод для поиска клиентов по имени в базе данных.
        {
            search = search.Trim().ToLower();  // Обрезка строки поиска и приведение к нижнему регистру.

            using (var context = new Context())
            {
                var result = context.Transports.Where(x => x.StateNumber.ToLower().Contains(search) && x.StateNumber.Length == search.Length).ToList();
                return TransportMapper.Map(result);
            }

        }
        public TransportViewModel Add(TransportEntity entity, BrandEntity entity1, CarCategoryEntity entity2 )// Метод для добавления новой программы занятий в базу данных.
        {// Обрезка строковых полей от лишних пробелов.
            entity1.Name = entity1.Name.Trim();
            entity2.Name = entity2.Name.Trim();
            entity.Year = entity.Year.Trim();
            entity.StateNumber = entity.StateNumber.Trim();
            entity.Status = entity.Status.Trim();

            // Проверка наличия заполненных полей.
            if (string.IsNullOrEmpty(entity1.Name) || string.IsNullOrEmpty(entity2.Name) || string.IsNullOrEmpty(entity.Year) || string.IsNullOrEmpty(entity.StateNumber) || string.IsNullOrEmpty(entity.Status.ToString()))
            {
                throw new Exception("Не все поля заполнены");
            }
            using (var context = new Context())
            {
                context.Transports.Add(entity);// Добавление новой программы занятий в базу данных.
                context.SaveChanges();
            }
            return TransportMapper.Map(entity);
        }
        
        public TransportViewModel Update(TransportEntity entity, BrandEntity entity1, CarCategoryEntity entity2)// Метод для обновления данных программы занятий в базе данных.
        {// Обрезка строковых полей от лишних пробелов.

            entity1.Name = entity1.Name.Trim();
            entity2.Name = entity2.Name.Trim();
            entity.Year = entity.Year.Trim();
            entity.StateNumber = entity.StateNumber.Trim();
            entity.Status = entity.Status.Trim();

            // Проверка наличия заполненных полей.
            if (string.IsNullOrEmpty(entity1.Name) || string.IsNullOrEmpty(entity2.Name) || string.IsNullOrEmpty(entity.Year) || string.IsNullOrEmpty(entity.StateNumber) || string.IsNullOrEmpty(entity.Status.ToString()))
            {
                throw new Exception("Не все поля заполнены");
            }
            using (var context = new Context())
            {
                var existingClient = context.Transports.Find(entity.ID);

                if (existingClient != null)
                {// Обновление данных существующей программы занятий.
                    context.Entry(existingClient).CurrentValues.SetValues(entity);
                    context.SaveChanges();
                }
                var existingClient2 = context.Brands.Find(entity.ID);
                if (existingClient2 != null)
                {

                    context.Entry(existingClient2).CurrentValues.SetValues(entity1);
                    context.SaveChanges();
                }
                
            }
            return TransportMapper.Map(entity);// Преобразование сущности в ViewModel.
        }


    }
}
