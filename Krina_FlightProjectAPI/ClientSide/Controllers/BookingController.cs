using System.Text;
using ClientSide.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClientSide.Controllers{
    public class BookingController:Controller{
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KrinaBooking>>> GetCustomerBooking(){
            if(HttpContext.Session.GetInt32("cid") !=null){
                HttpClient httpClient = new HttpClient();
                int cid = (int)HttpContext.Session.GetInt32("cid");
                HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5108/api/Booking/Customer/{cid}");
                if(response.IsSuccessStatusCode){
                      string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<KrinaBooking> l = JsonConvert.DeserializeObject<List<KrinaBooking>>(jsonResponse);
                   return View(l);
                }
            }
         
                return RedirectToAction("CustomerLogin","Customer");
            
        }
     [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["bid"] = id;
            KrinaBooking k = new KrinaBooking();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5108/api/Booking/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    k = JsonConvert.DeserializeObject<KrinaBooking>(apiResponse);
                }
            }
            return View(k);
        }
         [HttpPost]
       
        public async Task<ActionResult> Delete(KrinaBooking k)
        {
            int bid = Convert.ToInt32(TempData["bid"]);
            System.Console.WriteLine(bid);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5108/api/Booking/"+ bid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("GetCustomerBooking");
        }


    }
}