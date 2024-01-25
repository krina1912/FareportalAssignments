using Microsoft.AspNetCore.Http.HttpResults;
using ServerSide.Models;

namespace ServerSide.Repository
{

    public class LoginRepo : ILogin<KrinaCustomer>
    {
        private readonly Ace52024Context db;
        public LoginRepo(){}

        public LoginRepo(Ace52024Context _db)
        {
            db=_db;
        }
        public void CustomerRegister(KrinaCustomer e)
        {
            db.KrinaCustomers.Add(e);
            db.SaveChanges();
        }

      
        public KrinaCustomer CustomerLogin(KrinaCustomer u){
            
            var result = (from i in db.KrinaCustomers
                            where i.Email==u.Email && i.Pwd==u.Pwd
                            select i).SingleOrDefault();
            if(result!=null){
               return result;
            }
          
                return null;
            
        }
      

        public KrinaCustomer ViewCustomer(int id)
        {
            return  db.KrinaCustomers.Find(id);
        }

        public void EditCustomer(int id, KrinaCustomer e)
        {
            db.KrinaCustomers.Update(e);
            db.SaveChanges();

        }

       
        // public void Logout()
        // {
        //     throw new NotImplementedException();
        // }
    }

    
}