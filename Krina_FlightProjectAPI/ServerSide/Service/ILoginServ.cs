using ServerSide.Models;
namespace ServerSide.Service
{

    public interface ILoginServ<KrinaCustomer>
    {
        void CustomerRegister(KrinaCustomer k);
      KrinaCustomer CustomerLogin(KrinaCustomer K);

      void EditCustomer(int id,KrinaCustomer K);
      KrinaCustomer ViewCustomer(int id);
    }
}