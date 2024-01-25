using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using ClientSide.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;

namespace ClientSide.Controllers
{
    public class FlightController: Controller{

        [HttpGet]
        public async Task<List<KrinaAirport>> GetAirports(){
            HttpClient httpClient= new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5108/api/Airport");
            if(response.IsSuccessStatusCode){
                string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<KrinaAirport> l = JsonConvert.DeserializeObject<List<KrinaAirport>>(jsonResponse);
                return l;
            } 
            return null;
        }
        
        public async Task<ActionResult> FlightSearch(){
            if(HttpContext.Session.GetInt32("cid")!=null){
                List<KrinaAirport> l = await GetAirports();
                 // Create a list of SelectListItem from the KrinaAirport list
        List<SelectListItem> items = l.Select(airport => new SelectListItem
        {
            Value = airport.Airportcode,
            Text = $"{airport.Airportcode} - {airport.City}" // You can customize this as per your requirement
        }).ToList();

        SelectList sl = new SelectList(items, "Value", "Text");

        ViewBag.flightids = sl;
        return View();
            }
            return RedirectToAction("CustomerLogin","Customer");
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<KrinaFlight>>> FlightSearch(string DepartId, string ArrivalId , DateTime DepartTime){
            if(HttpContext.Session.GetInt32("cid")!=null){
              HttpClient httpClient = new HttpClient();
              httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
             
                var uri = $"http://localhost:5108/api/Flight/FlightSearch?DepartId={DepartId}&ArrivalId={ArrivalId}&DepartTime={DepartTime.ToString()}";
                HttpResponseMessage response = await httpClient.PostAsync(uri,new StringContent(""));
                System.Console.WriteLine(response);
                if(response.IsSuccessStatusCode){
                    System.Console.WriteLine("ok");
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<KrinaFlight> l = JsonConvert.DeserializeObject<List<KrinaFlight>>(jsonResponse);
                    return View("SearchResult",l);
                }
                else{
                    return View();
                }
            }
            return RedirectToAction("CustomerLogin","Customer");
        }
        public ActionResult SearchResult(List<KrinaFlight>l){
             if(HttpContext.Session.GetInt32("cid")!=null){
                return View(l);
             }
            return View();

        }
          public async Task<ActionResult> BookFlight(int flightid){
           if(HttpContext.Session.GetInt32("cid")!=null){
            TempData["fid"]=flightid;
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5108/api/Flight/{flightid}");
            if(response.IsSuccessStatusCode){
                
                 string jsonResponse = await response.Content.ReadAsStringAsync(); 
                KrinaFlight kf = JsonConvert.DeserializeObject<KrinaFlight>(jsonResponse);
            ViewBag.cost = kf.TotalCost;
            // TempData["cost"]=kf.TotalCost;
            // System.Console.WriteLine(kf.Fid);
            // System.Console.WriteLine(jsonResponse);
           
            return View();
            }
           
           }
           
            return RedirectToAction("CustomerLogin","Login");
         
         }

        [HttpPost]
          public async Task<ActionResult> BookFlight(KrinaBooking k){
            int id = Convert.ToInt32(TempData["fid"]);
            System.Console.WriteLine(id);

            HttpClient httpClient = new HttpClient();
            
            HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5108/api/Flight/{id}");
            if(response.IsSuccessStatusCode){
                
                 string jsonResponse = await response.Content.ReadAsStringAsync(); 
                KrinaFlight kf = JsonConvert.DeserializeObject<KrinaFlight>(jsonResponse);
            System.Console.WriteLine(jsonResponse);
             int CustomerID= (int)HttpContext.Session.GetInt32("cid");
             System.Console.WriteLine(CustomerID);
            k.Cid= CustomerID;
            k.Flightid= id;
            k.Bookdate=DateTime.Now;
            
            k.TotalCost=kf.TotalCost*k.NofPasseng;


             StringContent content = new StringContent(JsonConvert.SerializeObject(k),Encoding.UTF8, "application/json");
            HttpResponseMessage _response = await httpClient.PostAsync("http://localhost:5108/api/Booking",content);
             if(_response.IsSuccessStatusCode){
               
             return RedirectToAction("GetCustomerBooking","Booking");
            }
            }
            return RedirectToAction("FlightSearch","Flight");
            

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KrinaFlight>>> GetFlightList(){
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5108/api/Flight");

            if(response.IsSuccessStatusCode){
                 
                string jsonResponse = await response.Content.ReadAsStringAsync(); 
                List <KrinaFlight> l = JsonConvert.DeserializeObject<List<KrinaFlight>>(jsonResponse);
                System.Console.WriteLine(jsonResponse);
                return View(l);
            }
            return RedirectToAction("Index","Home");
        }
    
         [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            KrinaFlight kf = new KrinaFlight();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5108/api/Flight/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    System.Console.WriteLine(apiResponse);
                    kf = JsonConvert.DeserializeObject<KrinaFlight>(apiResponse);
                }
            }
            return View(kf);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(KrinaFlight kf)
        {
            KrinaFlight receivedkf = new KrinaFlight();

            using (var httpClient = new HttpClient())
            {
               
                int id = kf.Fid;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(kf)
         , Encoding.UTF8, "application/json");
         System.Console.WriteLine(content1);
         System.Console.WriteLine(id);
                using (var response = await httpClient.PutAsync($"http://localhost:5108/api/Flight/{id}", content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    
                    
                    receivedkf = JsonConvert.DeserializeObject<KrinaFlight>(apiResponse);
                    if(receivedkf != null){
                        return RedirectToAction("GetFlightList");
                    }

                }
            }
            return RedirectToAction("GetFlightList");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["fid"] = id;
            KrinaFlight k = new KrinaFlight();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5108/api/Flight/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    k = JsonConvert.DeserializeObject<KrinaFlight>(apiResponse);
                }
            }
            return View(k);
        }
         [HttpPost]
       
        public async Task<ActionResult> Delete(KrinaBooking k)
        {
            int fid = Convert.ToInt32(TempData["fid"]);
            // System.Console.WriteLine(bid);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5108/api/Flight/"+ fid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("GetFlightList");
        }

        [HttpGet]
        public async Task<ActionResult> AddFlight(){
            return View();
        }
          [HttpPost]
        public async Task<ActionResult> AddFlight(KrinaFlight k)
        {
            KrinaFlight kf = new KrinaFlight();
           
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(k), 
              Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:5108/api/Flight", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    kf = JsonConvert.DeserializeObject<KrinaFlight>(apiResponse);
                }
            }
            return RedirectToAction("GetFlightList");
        }



    }

}