using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Dac
{
    internal class ProductDac : Dac<UsersManagementContext, Product>
    {
        internal ProductDac(UsersManagementContext repository) : base(repository)
        {
        }

        public IQueryable<Product> ListActive()
        {
            return List(p => p.DateDisabled == null);
        }

        public IQueryable<Product> ListInactive()
        {
            return List(p => p.DateDisabled != null);
        }

        //public IQueryable<Product> GetSubstitutes()
        //{
        ////    return List(p => p.DateDisabled == null);
        //}
    }
}
