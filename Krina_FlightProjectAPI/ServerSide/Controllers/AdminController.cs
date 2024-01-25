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
    public class AdminController : ControllerBase{
        public static Ace52024Context db;

        public AdminController(Ace52024Context _db){
            db = _db;
        }
     
        [HttpPost("Login")]
        public async Task<ActionResult<KrinaAdmin>> AdminLogin(KrinaAdmin u){
             
            var result = (from i in db.KrinaAdmins
                            where i.Email==u.Email && i.Pwd==u.Pwd
                            select i).SingleOrDefault();
            if(result!=null){
               return result;
            }
          
                return null;
        }

       

    }
}