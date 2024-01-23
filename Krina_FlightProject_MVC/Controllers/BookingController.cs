using System.Data.Common;
using Krina_FlightProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Krina_FlightProject.Controllers{
    public class BookingController:Controller{
public static Ace52024Context db;

        public BookingController(Ace52024Context _db){
            db = _db;
        }
        // [HttpPost]


        public ActionResult CustomerBooking(){
                        ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){
             int CustomerID= (int)HttpContext.Session.GetInt32("Cid");
            // List<KrinaBooking> l = db.KrinaBookings.Where(x => x.Cid == CustomerID).ToList();
            //  ViewBag.flightids = new SelectList(db.KrinaAirports,"Airportcode","City","Airportcode");
            var result = db.KrinaBookings.Where(x=>x.Cid==CustomerID).Include(x=>x.CidNavigation).Include(a=>a.Flight)
                                                                                                    .ThenInclude(d=>d.Depart)
                                                                                                    .Include(a=>a.Flight)
                                                                                                    .ThenInclude(r=>r.Arrival).ToList();
                                                                                                  
            // System.Console.WriteLine(CustomerID);
            return View(result);
            }
            else{
                return RedirectToAction("CustomerLogin","Login");
            }

        }
          public ActionResult FlightDetails(int id){ 
                                    ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){
                     
            var s = db.KrinaBookings.Where(x=>x.Bid==id).Include(x=>x.CidNavigation).Include(a=>a.Flight)
                                                                                                    .ThenInclude(d=>d.Depart)
                                                                                                    .Include(a=>a.Flight)
                                                                                                    .ThenInclude(r=>r.Arrival).SingleOrDefault();
            return View(s);
            }
               else{
                return RedirectToAction("CustomerLogin","Login");
            }

         

        } 

         public ActionResult Delete(int id){
                ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){
                     
                 var s = db.KrinaBookings.Where(x=>x.Bid==id).Include(x=>x.CidNavigation).Include(a=>a.Flight)
                                                                                                    .ThenInclude(d=>d.Depart)
                                                                                                    .Include(a=>a.Flight)
                                                                                                    .ThenInclude(r=>r.Arrival).SingleOrDefault();
                TempData["Bid"]=id;
            
            return View(s);
             }
               else{
                return RedirectToAction("CustomerLogin","Login");
            }
                
        }

        [HttpPost]
        [ActionName("Delete")]
         public ActionResult Delete(KrinaBooking s){
                                    ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){
               s.Bid = Convert.ToInt32(TempData["Bid"]);
                db.KrinaBookings.Remove(s);
                db.SaveChanges();
                return RedirectToAction("CustomerBooking");
            }
             else{
                return RedirectToAction("CustomerLogin","Login");
            }
        }
      


    }
}