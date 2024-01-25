using Microsoft.EntityFrameworkCore.Storage;
using  ServerSide.Models;
namespace ServerSide.Repository
{
     public interface ILogin<KrinaCustomer>
    {
      void CustomerRegister(KrinaCustomer k);
      KrinaCustomer CustomerLogin(KrinaCustomer K);

      void EditCustomer(int id,KrinaCustomer K);
      KrinaCustomer ViewCustomer(int id);
    //   void Logout();
      

    }
    
}