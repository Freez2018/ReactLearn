using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace Client.Service.Products.Managers
{
    public partial interface IProductsManager : IDisposable
    {

     //   Task<bool> SendRecoverPasswordEmail(ApplicationUser applicationUser, string callbackUrl);
    }

    public partial class ProductsManager : IProductsManager
    {
        private readonly IMatchService MatchService;

        public ProductsManager(   IMatchService matchService)
        {
            MatchService = matchService ?? throw new ArgumentNullException(nameof(matchService));          
        }

        public void Dispose()
        {
            MatchService?.Dispose();
        }
               
    }
}
