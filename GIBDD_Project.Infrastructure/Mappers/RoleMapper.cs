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
        public static RoleViewModel Map(RoleEntity entity)
        {
            if (entity == null) 
                return null;
            var viewModel = new RoleViewModel
            {
                ID = entity.ID,
                Name = entity.Name,

            };
            return viewModel;
        }
        public static RoleEntity Map(RoleViewModel viewModel) 
        {
            if (viewModel == null)
                return null;
            var entity = new RoleEntity
            {
                ID = viewModel.ID,
                Name = viewModel.Name,
            };

            return entity;
        }
        public static List<RoleViewModel> Map(List<RoleEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
    }
}
