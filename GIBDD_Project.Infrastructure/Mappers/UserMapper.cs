using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Mappers
{
    public class UserMapper
    {
        public static UserViewModel Map(UserEntity entity)
        {
            var viewModel = new UserViewModel
            {
                ID = entity.ID,
                Name = entity.Name,
                SurName = entity.SurName,
                Patronymic = entity.Patronymic,
                Birthday = entity.Birthday,
                Gender = entity.Gender,
                Login = entity.Login,
                Password = entity.Password,
                RoleID = entity.RoleID,
                Role = RoleMapper.Map(entity.Role),





            };
            return viewModel;
        }
        public static UserEntity Map(UserViewModel viewModel)
        {
            var entity = new UserEntity
            {
                ID = viewModel.ID,
                Name = viewModel.Name,
                SurName = viewModel.SurName,
                Patronymic = viewModel.Patronymic,
                Birthday = viewModel.Birthday,
                Gender = viewModel.Gender,
                Login = viewModel.Login,
                Password = viewModel.Password,
                RoleID = viewModel.RoleID,
                Role = RoleMapper.Map(viewModel.Role),

            };
            return entity;
        }

        public static List<UserViewModel> Map(List<UserEntity> entities)// Метод для отображения списка сущностей EmployeeEntity на список представлений EmployeeViewModel.
        {
            var viewModels = entities.Select(x => Map(x)).ToList();// Преобразование каждой сущности в соответствующее представление и создание списка представлений
            return viewModels;
        }
    }
}
