using Microsoft.AspNetCore.Mvc;
using Krina_FlightProject.Models;

namespace Krina_FlightProject.Controllers{
    public class LoginController:Controller{
        private readonly Ace52024Context db;
        // public LoginController(Ace52024Context _db){
        //     db=_db;
        // }

        private readonly ISession session;
        public LoginController(Ace52024Context _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult CustomerLogin(){
            return View();
        }
        [HttpPost]
        public IActionResult CustomerLogin(KrinaCustomer u){
            var result = (from i in db.KrinaCustomers
                            where i.Email==u.Email && i.Pwd==u.Pwd
                            select i).SingleOrDefault();
            if(result!=null){
                HttpContext.Session.SetString("uname",result.Fname);
                HttpContext.Session.SetInt32("Cid",result.Cid);
                return RedirectToAction("FlightSearch","Flight");
            }
            else{
                return View();
            }
        }

          public IActionResult AdminLogin(){
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(KrinaAdmin u){
            var result = (from i in db.KrinaAdmins
                            where i.Email==u.Email && i.Pwd==u.Pwd
                            select i).SingleOrDefault();
            if(result!=null){
            HttpContext.Session.SetString("uname",result.Fname);
                return RedirectToAction("ViewFlight","Flight");
            }
            else{
                return View();
            }
        }
 
 


        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("CustomerLogin");
        }

      
 
        public IActionResult CustomerRegister(){
            return View();
        }
[HttpPost]
        public IActionResult CustomerRegister(KrinaCustomer k){
            
            db.KrinaCustomers.Add(k);
            db.SaveChanges();
            return RedirectToAction("CustomerLogin");
        }

           public ActionResult Edit(int id){
               ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){
           KrinaCustomer s = db.KrinaCustomers.Where(x=>x.Cid==id).SingleOrDefault();
        //    TempData["ID"]=id;
        ViewBag.id = id;
            return View(s);
            }
            else{
                return RedirectToAction("CustomerLogin");
            }

        }
        [HttpPost]

        public ActionResult Edit(KrinaCustomer s){
            // using (var db1=new Ace52024Context()){
                  ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){
                db.KrinaCustomers.Update(s);
                db.SaveChanges();
                return RedirectToAction("FlightSearch","Flight");
            // }
                        }
            else{
                return RedirectToAction("CustomerLogin");
            }

        }

        
        
        public IActionResult ViewCustomer(){
                  ViewBag.Username=HttpContext.Session.GetString("uname");
            if(ViewBag.Username!=null){
             int CustomerID= (int)HttpContext.Session.GetInt32("Cid");
            var result = db.KrinaCustomers.Where(x=>x.Cid==CustomerID).SingleOrDefault();
            return View(result);
               }
            else{
                return RedirectToAction("CustomerLogin");
            }
        }
    }
}