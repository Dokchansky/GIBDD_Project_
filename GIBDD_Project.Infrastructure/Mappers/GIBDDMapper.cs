using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Mappers
{
    public class GIBDDMapper
    {
        public static GIBDDViewModel Map(GIBDDEntity entity)
        {
            var viewModel = new GIBDDViewModel
            {
                ID = entity.ID,
                Name = entity.Name,
                Address = entity.Address,
                StartWork = entity.StartWork,
                StopWork = entity.StopWork,


            };
            return viewModel;
        }
        public static GIBDDEntity Map(GIBDDViewModel viewModel)
        {
            var entity = new GIBDDEntity
            {
                ID = viewModel.ID,
                Name = viewModel.Name,
                Address = viewModel.Address,
                StartWork = viewModel.StartWork,
                StopWork = viewModel.StopWork,

            };
            return entity;
        }

        public static List<GIBDDEntity> Map(List<GIBDDViewModel> viewModels)
        {
            var entities = viewModels.Select(vm => Map(vm)).ToList();
            return entities;
        }
        public static List<GIBDDViewModel> Map(List<GIBDDEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
    }
}
