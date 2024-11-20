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
    }
}
