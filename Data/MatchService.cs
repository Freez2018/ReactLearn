using Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public partial interface IMatchService : IDisposable
    {
    }

    public partial class MatchService : IMatchService
    {
        private readonly UsersManagementContext _productsRepository;

        public MatchService(UsersManagementContext productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public void Dispose()
        {
            _productsRepository.SaveChanges();
        }
    }
}
