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
        public BrandViewModel Add(TransportEntity entity, BrandEntity entity1, CarCategoryEntity entity2)// Метод для добавления новой марки в базу данных.
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
                context.Brands.Add(entity1);// Добавление новой марки в базу данных.
                context.SaveChanges();
            }
            return BrandMapper.Map(entity1);
        }

        public BrandViewModel Update(TransportEntity entity, BrandEntity entity1, CarCategoryEntity entity2)// Метод для обновления данных марки в базе данных.
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
                var existingClient = context.Brands.Find(entity.ID);

                if (existingClient != null)
                {// Обновление данных существующей марки.
                    context.Entry(existingClient).CurrentValues.SetValues(entity);
                    context.SaveChanges();
                }
                var existingClient2 = context.Brands.Find(entity1.ID);
                if (existingClient2 != null)
                {
                    context.Entry(existingClient2).CurrentValues.SetValues(entity1);
                    context.SaveChanges();
                }
            }
            return BrandMapper.Map(entity1);// Преобразование сущности в ViewModel.
        }
    }
}
