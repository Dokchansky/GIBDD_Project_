using GIBDD_Project.Infrastructure.Mappers;
using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
