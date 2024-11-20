using GIBDD_Project.Infrastructure.Mappers;
using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Globalization;

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
        public UserViewModel Update(UserEntity entity)// Метод для обновления данных пользователя в базе данных.
        {// Обрезка строковых полей от лишних пробелов.
            entity.Name = entity.Name.Trim();
            entity.SurName = entity.SurName.Trim();
            entity.Patronymic = entity.Patronymic.Trim();
            entity.Birthday = entity.Birthday.Trim();
            entity.Gender = entity.Gender.Trim();
            entity.Login = entity.Login.Trim();
            entity.Password = entity.Password.Trim();
            // Проверка наличия заполненных полей.
            if (string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.SurName) || string.IsNullOrEmpty(entity.Patronymic) || string.IsNullOrEmpty(entity.Gender) || string.IsNullOrEmpty(entity.Login) || string.IsNullOrEmpty(entity.Password))
            {
                throw new Exception("Не все поля заполнены");
            }
            using (var context = new Context())
            {
                var existingClient = context.Users.Find(entity.ID);

                if (existingClient != null)
                {// Обновление данных существующего пользователя.
                    context.Entry(existingClient).CurrentValues.SetValues(entity);
                    context.SaveChanges();
                }
            }
            return UserMapper.Map(entity);
        }
        public UserViewModel Delete(long id)// Метод для удаления пользователя из базы данных по идентификатору.
        {
            using (var context = new Context())
            {
                var clientToRemove = context.Users.FirstOrDefault(c => c.ID == id);
                if (clientToRemove != null)
                {
                    context.Users.Remove(clientToRemove);// Удаление пользователя из базы данных.
                    context.SaveChanges();
                }
                return UserMapper.Map(clientToRemove);
            }
        }
        public UserViewModel Add(UserEntity entity)// Метод для добавления нового пользователя в базу данных.
        {// Обрезка строковых полей от лишних пробелов.
            entity.Name = entity.Name.Trim();
            entity.SurName = entity.SurName.Trim();
            entity.Patronymic = entity.Patronymic.Trim();
            entity.Birthday = entity.Birthday.Trim();
            entity.Gender = entity.Gender.Trim();
            entity.Login = entity.Login.Trim();
            entity.Password = entity.Password.Trim();
            // Проверка наличия заполненных полей.
            if (string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.SurName) || string.IsNullOrEmpty(entity.Patronymic) || string.IsNullOrEmpty(entity.Gender) || string.IsNullOrEmpty(entity.Login) || string.IsNullOrEmpty(entity.Password))
            {
                throw new Exception("Не все поля заполнены");
            }
            using (var context = new Context())
            {
                context.Users.Add(entity);// Добавление нового пользователя в базу данных.
                context.SaveChanges();
            }
            return UserMapper.Map(entity);
        }
        public List<UserViewModel> GetList()// Метод для получения списка пользователей из базы данных.
        {
            using (var context = new Context())
            {
                var items = context.Users.Include(x => x.Role).ToList();// Извлечение пользователей из базы данных, включая связанные сущности, такие как роль.
                return UserMapper.Map(items);// Преобразование сущностей в ViewModel.
            }
        }
        public UserViewModel GetById(long id)// Метод для получения пользователя по идентификатору из базы данных.
        {
            using (var context = new Context())
            {
                var item = context.Users.FirstOrDefault(x => x.ID == id);
                return UserMapper.Map(item);// Преобразование сущности в ViewModel.
            }
        }
        public List<UserViewModel> Search(string search)// Метод для поиска пользователей по имени в базе данных.
        {
            search = search.Trim().ToLower(); // Обрезка строки поиска и приведение к нижнему регистру.

            using (var context = new Context())
            {
                var result = context.Users
                    .Where(x =>
                        x.Name.ToLower().Contains(search) && x.Name.Length == search.Length ||
                        x.SurName.ToLower().Contains(search) && x.SurName.Length == search.Length)
                        .ToList();

                return UserMapper.Map(result);
            }

        }
    }
}
