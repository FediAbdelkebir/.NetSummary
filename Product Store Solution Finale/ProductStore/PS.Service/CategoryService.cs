using PS.Data.Infrastructure;
using PS.Domain;
using PS.ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork utwk) : base(utwk)
        {
        }

        



    }



}
