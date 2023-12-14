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
    public partial class UserRepository
    {
        public UserEntity Login(string login, string password)
        {
            using (var context = new Context())
            {
                var item = context.Users

                    .FirstOrDefault(x => x.Login == login && x.Password == password);
                return item;
            }

        }
        public List<UserViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Users.ToList();
                return UserMapper.Map(items);
            }
        }
        public UserViewModel Delete(long id)
        {
            using (var context = new Context())
            {
                var clientToRemove = context.Users.FirstOrDefault(c => c.ID == id);
                if (clientToRemove != null)
                {
                    context.Users.Remove(clientToRemove);
                    context.SaveChanges();
                }
                return UserMapper.Map(clientToRemove);
            }
        }
        public List<UserViewModel> Search(string search)// Метод для поиска клиентов по имени в базе данных.
        {
            search = search.Trim().ToLower();  // Обрезка строки поиска и приведение к нижнему регистру.

            using (var context = new Context())
            {
                var result = context.Users.Include(x => x.Transport)
    .Where(x =>
        (x.Name.ToLower().Contains(search) ||
        x.SurName.ToLower().Contains(search) ||
        x.Patronymic.ToLower().Contains(search)) &&
        (x.Name.Length == search.Length ||
        x.SurName.Length == search.Length ||
        x.Patronymic.Length == search.Length))
    .ToList();
                return UserMapper.Map(result);
            }

        }
        public UserViewModel Update(UserEntity entity) // Метод для обновления данных клиента в базе данных.
        {// Обрезка строковых полей от лишних пробелов.
            entity.SurName = entity.SurName.Trim();
            entity.Name = entity.Name.Trim();
            entity.Patronymic = entity.Patronymic.Trim();
            entity.Gender = entity.Gender.Trim();
            // Проверка наличия заполненных полей.
            if (string.IsNullOrEmpty(entity.SurName) || string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.Patronymic) || string.IsNullOrEmpty(entity.Gender))
            {
                throw new Exception("Не все поля заполнены");
            }

            using (var context = new Context())
            {
                var existingClient = context.Users.Find(entity.ID);

                if (existingClient != null)
                {// Обновление данных существующего клиента.
                    context.Entry(existingClient).CurrentValues.SetValues(entity);
                    context.SaveChanges();
                }
            }
            return UserMapper.Map(entity);// Преобразование сущности в ViewModel.
        }
        public UserViewModel Add(UserEntity entity) // Метод для добавления нового клиента в базу данных.
        {// Обрезка строковых полей от лишних пробелов.

            entity.SurName = entity.SurName.Trim();
            entity.Name = entity.Name.Trim();
            entity.Patronymic = entity.Patronymic.Trim();
            entity.Gender = entity.Gender.Trim();
            
            // Проверка наличия заполненных полей.
            if (string.IsNullOrEmpty(entity.SurName) || string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.Patronymic)  || string.IsNullOrEmpty(entity.Gender.ToString()))
            {
                throw new Exception("Не все поля заполнены");
            }
            using (var context = new Context())
            {
                context.Users.Add(entity);// Добавление нового клиента в базу данных.
                context.SaveChanges();
            }
            return UserMapper.Map(entity);
        }
    }
}
