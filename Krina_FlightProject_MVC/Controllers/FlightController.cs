using Krina_FlightProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Krina_FlightProject.Controllers{
    public class FlightController : Controller{
       public static Ace52024Context db;

        public FlightController(Ace52024Context _db){
            db = _db;
        }

        public ActionResult FlightSearch(){
                         ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){

            ViewBag.flightids = new SelectList(db.KrinaAirports,"Airportcode","City","Airportcode");
            return View();
        }
             else{
                return RedirectToAction("CustomerLogin","Login");
            }
        }

        [HttpPost]

        public ActionResult FlightSearch(string DepartId, string ArrivalId , DateOnly DepartTime){
   ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){

            DateTime d = DepartTime.ToDateTime(new TimeOnly(0,0));

            List<KrinaFlight> temp = db.KrinaFlights.Where(x=>x.DepartId==DepartId && x.ArrivalId==ArrivalId && x.DepartTime.Value.Date ==d.Date).ToList();
            return View("SearchResult",temp);
              }
             else{
                return RedirectToAction("CustomerLogin","Login");
            }

        }

        public ActionResult SearchResult(List<KrinaFlight> l){
               ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){

            return View(l);
                }
             else{
                return RedirectToAction("CustomerLogin","Login");
            }
        }
        [HttpGet]
        public ActionResult AddFlight(){
          
            ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){
            ViewBag.flightids = new SelectList(db.KrinaAirports,"Airportcode","City","Airportcode");

            return View();
            }  
              else{
                return RedirectToAction("AdminLogin","Login");
            }

        }
        [HttpPost]
        public ActionResult AddFlight(KrinaFlight f){
             ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){
            db.KrinaFlights.Add(f);
            db.SaveChanges();
            return RedirectToAction("ViewFlight");
             }  
              else{
                return RedirectToAction("AdminLogin","Login");
            }
        }

        public ActionResult ViewFlight(){
             ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){
            return View(db.KrinaFlights);
            }else{
                return RedirectToAction("AdminLogin","Login");
            }
        }
        
           public ActionResult Delete(int id){
                  ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){
                 var s = db.KrinaFlights.Where(x=>x.Fid==id).SingleOrDefault();
                TempData["Bid"]=id;
            
            return View(s);
             }else{
                return RedirectToAction("AdminLogin","Login");
            }
             }
              
                
        

        [HttpPost]
        [ActionName("Delete")]
         public ActionResult Delete(KrinaFlight s){
                           ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){    
               s.Fid = Convert.ToInt32(TempData["Bid"]);
                db.KrinaFlights.Remove(s);
                db.SaveChanges();
                return RedirectToAction("ViewFlight");
                   }else{
                return RedirectToAction("AdminLogin","Login");
            }
            }
            
  public ActionResult Edit(int id){
              ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){    
           KrinaFlight s = db.KrinaFlights.Where(x=>x.Fid==id).SingleOrDefault();
        //    TempData["ID"]=id;
        ViewBag.fid = id;
            return View(s);
           }else{
                return RedirectToAction("AdminLogin","Login");
            }

        }
        [HttpPost]

        public ActionResult Edit(KrinaFlight s){
            // using (var db1=new Ace52024Context()){
                ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){  
                db.KrinaFlights.Update(s);
                db.SaveChanges();
                return RedirectToAction("ViewFlight");
            // }
                    }else{
                return RedirectToAction("AdminLogin","Login");
            }   

        }
      


         public ActionResult BookFlight(int flightid){
                ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){
           
            TempData["fid"]=flightid;
            KrinaFlight kf = db.KrinaFlights.Where(x=>x.Fid==flightid).SingleOrDefault();
            ViewBag.cost = kf.TotalCost;

           
            return View();
            }
            else{
            return RedirectToAction("CustomerLogin","Login");
            }
        }
        [HttpPost]
        public ActionResult BookFlight(KrinaBooking k){
                  ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){             
          
            int id = Convert.ToInt32(TempData["fid"]);
            // System.Console.WriteLine(flightid);
            KrinaFlight kf = db.KrinaFlights.Where(x=>x.Fid==id).SingleOrDefault();
             int CustomerID= (int)HttpContext.Session.GetInt32("Cid");
            k.Cid= CustomerID;
            k.Flightid= id;
            k.Bookdate=DateTime.Now;
            k.TotalCost=kf.TotalCost*k.NofPasseng;

           
             db.KrinaBookings.Add(k);
             db.SaveChanges();
             return RedirectToAction("CustomerBooking","Booking");
            }
            else{
                return RedirectToAction("CustomerLogin","Login");
            }

        }
    }
}