using GIBDD_Project.Infrastructure.Mappers;
using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Database
{
    public class RoleRepository
    {
        public RoleViewModel Update(RoleEntity entity)// Метод для обновления данных должности в базе данных.
        {
            using (var context = new Context())
            {
                var existingClient = context.Roles.Find(entity.ID);

                if (existingClient != null)
                {// Обновление данных существующего должности.
                    context.Entry(existingClient).CurrentValues.SetValues(entity);
                    context.SaveChanges();
                }
            }
            return RoleMapper.Map(entity);// Преобразование сущности в ViewModel.
        }

        public RoleViewModel Add(RoleEntity entity)// Метод для добавления новой должности в базу данных.
        {
            using (var context = new Context())
            {
                context.Roles.Add(entity);// Добавление новой должности в базу данных.
                context.SaveChanges();
            }
            return RoleMapper.Map(entity);
        }
        public List<RoleViewModel> GetList()// Метод для получения списка должностей из базы данных.
        {
            using (var context = new Context())
            {
                var items = context.Roles.ToList();// Извлечение должностей из базы данных, включая связанные сущности, такие как скидки.
                return RoleMapper.Map(items);
            }
        }
        public RoleViewModel GetById(long id)// Метод для получения должности по идентификатору из базы данных.
        {
            using (var context = new Context())
            {
                var item = context.Roles.FirstOrDefault(x => x.ID == id);
                return RoleMapper.Map(item);
            }
        }
        public RoleViewModel Delete(long id)// Метод для удаления должности из базы данных по идентификатору.
        {
            using (var context = new Context())
            {
                var clientToRemove = context.Roles.FirstOrDefault(c => c.ID == id);
                if (clientToRemove != null)
                {
                    context.Roles.Remove(clientToRemove);// Удаление должности из базы данных.
                    context.SaveChanges();
                }
                return RoleMapper.Map(clientToRemove);
            }
        }
    }
}
