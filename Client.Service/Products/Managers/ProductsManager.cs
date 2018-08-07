using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Service.Products.Managers
{
    public partial interface IProductsManager : IDisposable
    {

     //   Task<bool> SendRecoverPasswordEmail(ApplicationUser applicationUser, string callbackUrl);
    }

    public partial class ProductsManager : IProductsManager
    {
   //     private readonly IHostingEnvironment _env;
      

        public ProductsManager(
            //  IAccountsService accountsService
           )
        {
          //  AccountsService = accountsService ?? throw new ArgumentNullException(nameof(accountsService));
          
        }

        public void Dispose()
        {
         //   AccountsService?.Dispose();
        }
               
    }
}
