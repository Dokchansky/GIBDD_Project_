using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Mappers
{
    public static class BrandMapper
    {
        public static BrandViewModel Map(BrandEntity entity)
        {
            var viewModel = new BrandViewModel
            {
                ID = entity.ID,
                Name = entity.Name,

            };
            return viewModel;
        }

        public static List<BrandViewModel> Map(List<BrandEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }

    }
}
