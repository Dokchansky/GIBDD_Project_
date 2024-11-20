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
                RoleName = entity.Role.Name,





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

            };
            return entity;
        }

        public static List<UserEntity> Map(List<UserViewModel> viewModels)
        {
            var entities = viewModels.Select(vm => Map(vm)).ToList();
            return entities;
        }
        public static List<UserViewModel> Map(List<UserEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
    }
}
