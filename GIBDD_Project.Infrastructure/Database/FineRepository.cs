﻿using GIBDD_Project.Infrastructure.Mappers;
using GIBDD_Project.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.Database
{
    public partial class FineRepository
    {
        public List<FineViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Fines.ToList();
                return FineMapper.Map(items);
            }
        }
        public List<FineViewModel> GetByFineId(long id)
        {
            using (var context = new Context())
            {
                var item = context.Fines.Where(x => x.TransportID == id).ToList();
                return FineMapper.Map(item);
            }
        }
        public FineViewModel Add(FineViewModel viewModel)
        {
            using (var context = new Context())
            {
                var entity = FineMapper.Map(viewModel);

                context.Fines.Add(entity);
                context.SaveChanges();

                return FineMapper.Map(entity);
            }
        }
    }
}
