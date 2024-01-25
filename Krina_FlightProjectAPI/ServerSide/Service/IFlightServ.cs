using ServerSide.Models;
namespace ServerSide.Service
{

    public interface IFlightServ<KrinaFlight>
    {
        List<KrinaFlight> GetAllKrinaFlights();
        List<KrinaFlight> GetFlightsbySearch(string DepartId, string ArrivalId , DateTime DepartTime);
        void AddKrinaFlight(KrinaFlight e);
        void UpdateKrinaFlight(int id, KrinaFlight e);
        KrinaFlight GetFlightById(int id);
        void DeleteKrinaFlight(int id);
    }
}