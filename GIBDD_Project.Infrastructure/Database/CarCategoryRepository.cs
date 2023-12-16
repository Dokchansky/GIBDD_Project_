using GIBDD_Project.Infrastructure.Mappers;
using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Database
{
    public class CarCategoryRepository
    {
        public List<CarCategoryViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.CarCategories.ToList();
                return CarCategoryMapper.Map(items);
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

    }
}
