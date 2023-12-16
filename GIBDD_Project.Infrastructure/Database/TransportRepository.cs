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
        public List<TransportViewModel> GetByCarCategoryId(long id)
        {
            using (var context = new Context())
            {
                var item = context.Transports.Where(x => x.CarCategoryID == id).ToList();
                return TransportMapper.Map(item);
            }
        }
        public TransportViewModel Add(TransportEntity entity, BrandEntity entity1)// Метод для добавления нового транспорта в базу данных.
        {// Обрезка строковых полей от лишних пробелов.
            entity1.Name = entity1.Name.Trim();

            entity.Year = entity.Year.Trim();
            entity.StateNumber = entity.StateNumber.Trim();
            entity.Status = entity.Status.Trim();

            // Проверка наличия заполненных полей.
            if (string.IsNullOrEmpty(entity1.Name)  || string.IsNullOrEmpty(entity.Year) || string.IsNullOrEmpty(entity.StateNumber) || string.IsNullOrEmpty(entity.Status.ToString()))
            {
                throw new Exception("Не все поля заполнены");
            }
            using (var context = new Context())
            {
                context.Transports.Add(entity);
                context.Brands.Add(entity1); // Добавление нового транспорта в базу данных.
                context.SaveChanges();
            }
            return TransportMapper.Map(entity);
        }
        public List<TransportViewModel> Search(string search)// Метод для поиска транспорта по гос.номеру в базе данных.
        {
            search = search.Trim().ToLower();  // Обрезка строки поиска и приведение к нижнему регистру.

            using (var context = new Context())
            {
                var result = context.Transports.Where(x => x.StateNumber.ToLower().Contains(search) && x.StateNumber.Length == search.Length).ToList();
                return TransportMapper.Map(result);
            }

        }
        public TransportViewModel Update(TransportEntity entity, BrandEntity entity1)// Метод для обновления данных транспорта в базе данных.
        {// Обрезка строковых полей от лишних пробелов.

            entity1.Name = entity1.Name.Trim();

            entity.Year = entity.Year.Trim();
            entity.StateNumber = entity.StateNumber.Trim();
            entity.Status = entity.Status.Trim();


            // Проверка наличия заполненных полей.
            if (string.IsNullOrEmpty(entity1.Name) || string.IsNullOrEmpty(entity.Year) || string.IsNullOrEmpty(entity.StateNumber) || string.IsNullOrEmpty(entity.Status.ToString()))
            {
                throw new Exception("Не все поля заполнены");
            }
            using (var context = new Context())
            {
                var existingClient = context.Transports.Find(entity.ID);
                var existingClient1 = context.Brands.Find(entity1.ID);


                if (existingClient != null)
                {// Обновление данных существующего транспорта.
                    context.Entry(existingClient).CurrentValues.SetValues(entity);
                    context.Entry(existingClient1).CurrentValues.SetValues(entity1);

                    context.SaveChanges();
                }
            }
            return TransportMapper.Map(entity);// Преобразование сущности в ViewModel.
        }
        public TransportViewModel Delete(long id)// Метод для удаления транспорта из базы данных по идентификатору.
        {
            using (var context = new Context())
            {
                var clientToRemove = context.Transports.FirstOrDefault(c => c.ID == id);
                if (clientToRemove != null)
                {
                    context.Transports.Remove(clientToRemove);// Удаление транспорта из базы данных.
                    context.SaveChanges();
                }
                return TransportMapper.Map(clientToRemove);
            }
        }


    }
}
