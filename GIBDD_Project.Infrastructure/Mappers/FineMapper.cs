using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Mappers
{
    public class FineMapper
    {
        public static FineViewModel Map(FineEntity entity)
        {
            var viewModel = new FineViewModel
            {
                ID = entity.ID,
                Name = entity.Name,
                Status = entity.Status,
                Value = entity.Value,
                TransportID = entity.TransportID,
                TransportStateNumber = entity.Transport?.StateNumber,




            };
            return viewModel;
        }
        public static FineEntity Map(FineViewModel viewModel)
        {
            var entity = new FineEntity
            {
                ID = viewModel.ID,
                Name = viewModel.Name,
                Status = viewModel.Status,
                Value = viewModel.Value,
                TransportID = viewModel.TransportID,

            };
            return entity;
        }

        public static List<FineEntity> Map(List<FineViewModel> viewModels)
        {
            var entities = viewModels.Select(vm => Map(vm)).ToList();
            return entities;
        }
        public static List<FineViewModel> Map(List<FineEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
    }
}
