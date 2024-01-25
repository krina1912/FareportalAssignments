using ServerSide.Models;

namespace ServerSide.Repository
{

    public class FlightRepo : IFlight<KrinaFlight>
    {
        private readonly Ace52024Context db;
        public FlightRepo(){}

        public FlightRepo(Ace52024Context _db)
        {
            db=_db;
        }
        public void AddKrinaFlight(KrinaFlight e)
        {
            db.KrinaFlights.Add(e);
            db.SaveChanges();
        }

        public void DeleteKrinaFlight(int id)
        {
            KrinaFlight e=db.KrinaFlights.Find(id);
            db.KrinaFlights.Remove(e);
            db.SaveChanges();
        }

        public List<KrinaFlight> GetAllKrinaFlights()
        {
            return db.KrinaFlights.ToList();
        }

        public KrinaFlight GetFlightById(int id)
        {
            return  db.KrinaFlights.Find(id);
        }

        public void UpdateKrinaFlight(int id, KrinaFlight e)
        {
            db.KrinaFlights.Update(e);
            db.SaveChanges();

        }
       public List<KrinaFlight> GetFlightsbySearch(string DepartId, string ArrivalId , DateTime DepartTime){
           

            return  db.KrinaFlights.Where(x=>x.DepartId==DepartId && x.ArrivalId==ArrivalId && x.DepartTime.Value.Date ==DepartTime.Date).ToList();
       }

    }

    
}