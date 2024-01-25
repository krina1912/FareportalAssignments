using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.OpenApi.Any;
using ServerSide.Models;

namespace ServerSide.Controllers{
     [Route("api/[controller]")]
    [ApiController]
    public class AirportController:ControllerBase{
          public static Ace52024Context db;

        public AirportController(Ace52024Context _db){
            db = _db;
        }
        [HttpGet]
        public  List<KrinaAirport> GetDropDownItems(){
            return db.KrinaAirports.ToList();
         
        }

    }
}