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
        public FineViewModel Add(FineEntity entity)// Метод для добавления новой программы занятий в базу данных.
        {// Обрезка строковых полей от лишних пробелов.
            entity.Name = entity.Name.Trim();
            entity.Value = entity.Value.Trim();
            entity.Status = entity.Status.Trim();

            // Проверка наличия заполненных полей.
            if (string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.Value) || string.IsNullOrEmpty(entity.Status.ToString()))
            {
                throw new Exception("Не все поля заполнены");
            }
            using (var context = new Context())
            {
                context.Fines.Add(entity);// Добавление новой программы занятий в базу данных.
                context.SaveChanges();
            }
            return FineMapper.Map(entity);
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
        public FineViewModel Update(FineEntity entity)// Метод для обновления данных программы занятий в базе данных.
        {// Обрезка строковых полей от лишних пробелов.

            entity.Name = entity.Name.Trim();
            entity.Value = entity.Value.Trim();
            entity.Status = entity.Status.Trim();

            // Проверка наличия заполненных полей.
            if (string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.Value) || string.IsNullOrEmpty(entity.Status.ToString()))
            {
                throw new Exception("Не все поля заполнены");
            }
            using (var context = new Context())
            {
                var existingClient = context.Fines.Find(entity.ID);

                if (existingClient != null)
                {// Обновление данных существующей программы занятий.
                    context.Entry(existingClient).CurrentValues.SetValues(entity);
                    context.SaveChanges();
                }
            }
            return FineMapper.Map(entity);// Преобразование сущности в ViewModel.
        }
        public FineViewModel Delete(long id)// Метод для удаления сотрудника из базы данных по идентификатору.
        {
            using (var context = new Context())
            {
                var clientToRemove = context.Fines.FirstOrDefault(c => c.ID == id);
                if (clientToRemove != null)
                {
                    context.Fines.Remove(clientToRemove);// Удаление сотрудника из базы данных.
                    context.SaveChanges();
                }
                return FineMapper.Map(clientToRemove);
            }
        }
    }
}
