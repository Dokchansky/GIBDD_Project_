using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Mappers
{
    public class TransportMapper
    {
        public static TransportViewModel Map(TransportEntity entity)
        {
            var viewModel = new TransportViewModel
            {
                ID = entity.ID,
                Status = entity.Status,
                StateNumber = entity.StateNumber,
                Year = entity.Year,
                UserID = entity.UserID,
                BrandID = entity.BrandID,
                CarCategoryID = entity.CarCategoryID,
                BrandName = entity.Brand?.Name,
                CarCategoryName = entity.CarCategory?.Name,


            };
            return viewModel;
        }
        public static TransportEntity Map(TransportViewModel viewModel)
        {
            var entity = new TransportEntity
            {
                ID = viewModel.ID,
                Status = viewModel.Status,
                StateNumber = viewModel.StateNumber,
                Year = viewModel.Year,
                UserID = viewModel.UserID,
                BrandID = viewModel.BrandID,
                CarCategoryID = viewModel.CarCategoryID,

            };
            return entity;
        }

        public static List<TransportEntity> Map(List<TransportViewModel> viewModels)
        {
            var entities = viewModels.Select(vm => Map(vm)).ToList();
            return entities;
        }
        public static List<TransportViewModel> Map(List<TransportEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
    }
}
