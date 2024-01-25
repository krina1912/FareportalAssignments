using ServerSide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using ServerSide.Service;


namespace ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase{
       
       private readonly IFlightServ<KrinaFlight> flightserv;

    

        public FlightController(IFlightServ<KrinaFlight> _flightserv){
            flightserv = _flightserv;
        }

     

        [HttpPost("FlightSearch")]

        public async Task<ActionResult<IEnumerable<KrinaFlight>>> FlightSearch(string DepartId, string ArrivalId , DateTime DepartTime){
            
            var result =  flightserv.GetFlightsbySearch(DepartId, ArrivalId, DepartTime);

           
            if (result != null && result.Any())
            {
                return result; 
            }
            else
            {
                return NotFound(); // Return 404 Not Found if no flights are found
            }

        //    return flightserv.GetFlightsbySearch(DepartId, ArrivalId, DepartTime);
            
        }

        [HttpGet]
         public async Task<ActionResult<IEnumerable<KrinaFlight>>> GetFlights(){
          
            return   flightserv.GetAllKrinaFlights();
          
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KrinaFlight>> ViewFlightbyid(int id)
        {
            var krinaflight = flightserv.GetFlightById(id);

            if (krinaflight == null)
            {
                return NotFound();
            }

            return krinaflight;
        }


        
        [HttpPost]
        public async Task<ActionResult> AddFlight(KrinaFlight f){
                     try
            {
             flightserv.AddKrinaFlight(f);
            }
            catch (DbUpdateException)
            {
                if (KrinaFlightExists(f.Fid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("ViewFlightbyid", new { id =f.Fid }, f);



        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = flightserv.GetFlightById(id);
            if (flight == null)
            {
                return NotFound();
            }

            flightserv.DeleteKrinaFlight(id);
            return NoContent();
        }
              
                
        

       [HttpPut("{id}")]
        public async Task<IActionResult> EditFlight(int id, KrinaFlight krinaFlight)
        {

         
        try
        {
          flightserv.UpdateKrinaFlight(id,krinaFlight);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KrinaFlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
     

            
 private bool KrinaFlightExists(int id)
        {
           KrinaFlight f= flightserv.GetFlightById(id);
            if(f!=null)
            return true;
            else
            return false;
        }
      



      
    }
}