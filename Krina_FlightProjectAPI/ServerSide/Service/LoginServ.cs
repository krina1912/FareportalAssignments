using ServerSide.Models;
using ServerSide.Repository;

namespace ServerSide.Service
{

    public class LoginServ : ILoginServ<KrinaCustomer>
    {

        private readonly ILogin<KrinaCustomer> loginrepo;
        public LoginServ(){}

        public LoginServ( ILogin<KrinaCustomer> _loginrepo)
        {
            loginrepo=_loginrepo;
        }

        public KrinaCustomer CustomerLogin(KrinaCustomer K)
        {
            return loginrepo.CustomerLogin(K);
        }

        public void CustomerRegister(KrinaCustomer k)
        {
            loginrepo.CustomerRegister(k);
        }

        public void EditCustomer(int id, KrinaCustomer K)
        {
            loginrepo.EditCustomer(id, K);
        }

        public KrinaCustomer ViewCustomer(int id)
        {
            return loginrepo.ViewCustomer(id);
        }
    }
}