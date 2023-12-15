using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Mappers
{
    public class RoleMapper
    {
        public static RoleViewModel Map(RoleEntity entity)// Метод для отображения сущности PositionEntity на представление PositionViewModel.
        {
            if (entity == null) // Проверка наличия сущности.
                return null;
            var viewModel = new RoleViewModel// Создание объекта представления и копирование данных из сущности.
            {
                ID = entity.ID,
                Name = entity.Name,

            };
            return viewModel;
        }
        public static RoleEntity Map(RoleViewModel viewModel) // Метод для отображения представления PositionViewModel на сущность PositionEntity.
        {
            if (viewModel == null)// Проверка наличия сущности.
                return null;
            var entity = new RoleEntity// Создание объекта сущности и копирование данных из представления.
            {
                ID = viewModel.ID,
                Name = viewModel.Name,
            };

            return entity;
        }
        public static List<RoleViewModel> Map(List<RoleEntity> entities)// Метод для отображения списка сущностей PositionEntity на список представлений PositionViewModel.
        {
            var viewModels = entities.Select(x => Map(x)).ToList();// Преобразование каждой сущности в соответствующее представление и создание списка представлений
            return viewModels;
        }
    }
}
