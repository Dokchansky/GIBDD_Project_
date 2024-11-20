using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Mappers
{
    public class CarCategoryMapper
    {
        public static CarCategoryViewModel Map(CarCategoryEntity entity)
        {
            if (entity == null) 
                return null;
            var viewModel = new CarCategoryViewModel
            {
                ID = entity.ID,
                Name = entity.Name,


            };
            return viewModel;
        }
        public static CarCategoryEntity Map(CarCategoryViewModel viewModel)
        {
            if (viewModel == null)
                return null;
            var entity = new CarCategoryEntity
            {
                ID = viewModel.ID,
                Name = viewModel.Name,
            };

            return entity;
        }
        public static List<CarCategoryViewModel> Map(List<CarCategoryEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }

    }
}
