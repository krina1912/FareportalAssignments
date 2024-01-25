using ServerSide.Models;
using ServerSide.Repository;

namespace ServerSide.Service
{

    public class FlightServ : IFlightServ<KrinaFlight>
    {

        private readonly IFlight<KrinaFlight> flightrepo;
        public FlightServ(){}

        public FlightServ(IFlight<KrinaFlight> _flightrepo)
        {
            flightrepo=_flightrepo;
        }
        public void AddKrinaFlight(KrinaFlight e)
        {
           flightrepo.AddKrinaFlight(e);
        }

        public void DeleteKrinaFlight(int id)
        {
            flightrepo.DeleteKrinaFlight(id);
        }

        public List<KrinaFlight> GetAllKrinaFlights()
        {
            return flightrepo.GetAllKrinaFlights();
        }

        public KrinaFlight GetFlightById(int id)
        {
            return flightrepo.GetFlightById(id);
        }

        public void UpdateKrinaFlight(int id, KrinaFlight e)
        {
            flightrepo.UpdateKrinaFlight(id,e);
        }

        public List<KrinaFlight> GetFlightsbySearch(string DepartId, string ArrivalId , DateTime DepartTime){
            return flightrepo.GetFlightsbySearch(DepartId, ArrivalId, DepartTime);
        }

    }
}