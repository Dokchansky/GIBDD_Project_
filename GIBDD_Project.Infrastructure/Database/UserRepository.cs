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
        private DateTime date;
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
        public List<UserViewModel> GetRoles()
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
        public UserViewModel Update(UserViewModel viewModel)
        {
            using (var context = new Context())
            {
                var entity = context.Users.FirstOrDefault(x => x.ID == viewModel.ID);
                if (entity == null)
                    return null;

                entity.Name = viewModel.Name;
                if (entity.Name == "Имя")
                {
                    throw new Exception("Имя не может быть пустым");
                }
                entity.SurName = viewModel.SurName;
                if (entity.SurName == "Фамилия")
                {
                    throw new Exception("Фамилия не может быть пустой");
                }

                entity.Patronymic = viewModel.Patronymic;
                if (entity.Patronymic == "Отчество")
                {
                    entity.Patronymic = "";
                }
                
                entity.Gender = viewModel.Gender;
                if (entity.Gender == "Пол")
                {
                    throw new Exception("Пол не может быть пустым");
                }
                entity.Birthday = viewModel.Birthday;

                if (!DateTime.TryParseExact(entity.Birthday, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    throw new Exception("Дата должна быть в формате даты (например, 25.11.2023)");
                }
                entity.RoleID = viewModel.RoleID;

                context.SaveChanges();

                return UserMapper.Map(entity);
            }
        }
        public UserViewModel Add(UserViewModel viewModel)
        {
            using (var context = new Context())
            {
                var entity = UserMapper.Map(viewModel);


                if (entity.Name == "Имя")
                {
                    throw new Exception("Имя не может быть пустым");
                }
                if (entity.SurName == "Фамилия")
                {
                    throw new Exception("Фамилия не может быть пустой");
                }

                if (entity.Patronymic == "Отчество")
                {
                    entity.Patronymic = "";
                }
                if (entity.Gender == "Пол")
                {
                    throw new Exception("Пол не может быть пустым");
                }

                if (!DateTime.TryParseExact(entity.Birthday, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    throw new Exception("Дата должна быть в формате даты (например, 25.11.2023)");
                }


                context.Users.Add(entity);

                context.SaveChanges();

                return UserMapper.Map(entity);
            }
        }
    }
}
