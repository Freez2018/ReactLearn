using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Dac
{
    internal class ProductsMatchingDac : Dac<UsersManagementContext, ProductsMatching>
    {
        internal ProductsMatchingDac(UsersManagementContext repository) : base(repository)
        {
        }

        public IQueryable<ProductsMatching> ListEntries(string id)
        {
            return List(p => p.BaseProductId == id);
        }

       
    }
}
