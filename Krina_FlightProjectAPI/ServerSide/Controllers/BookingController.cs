using System.Data.Common;
using ServerSide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http.HttpResults;
using ServerSide.Service;

namespace ServerSide.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController:ControllerBase{
        public static Ace52024Context db;

        public BookingController(Ace52024Context _db){
            db = _db;
        }
        // [HttpPost]

        [HttpGet("Customer/{id}")]

        public async Task<ActionResult<IEnumerable<KrinaBooking>>> GetBookingbyCustomerid(int id){
                       
            
           
            
            var result = db.KrinaBookings.Where(x=>x.Cid==id).ToList();
                                                                                                  
            
            return result;
           

        }

        [HttpGet("{id}")]
          public async Task<ActionResult<KrinaBooking>> GetBookingbyid(int id){ 
                                   
                     
            var s = db.KrinaBookings.Where(x=>x.Bid==id).SingleOrDefault();
            return s;
          
         

        } 

        [HttpDelete("{id}")]
         public async Task<ActionResult> Delete(int id){
          
                     
                KrinaBooking b = db.KrinaBookings.Find(id);
                  if (b == null)
            {
                return NotFound();
            }
               db.KrinaBookings.Remove(b);
               await db.SaveChangesAsync();
             
            return NoContent();
                
        }

        [HttpPost]
        public async Task<ActionResult> BookFlight(KrinaBooking k){
            try{
            

           
             db.KrinaBookings.Add(k);
             db.SaveChangesAsync();
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
            return NoContent();
        
          
        }
       
    }
}