using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClientSide.Models;
using Newtonsoft.Json;
using System.Data.Common;

namespace ClientSide.Controllers
{
    public class CustomerController : Controller
    {
        
        public async Task<ActionResult> CustomerLogin()
        {
            // if(HttpContext.Session.GetString("uname")!=null || HttpContext.Session.GetInt32("cid")!=0)
                // return RedirectToAction("Index","Home");
            // else
            return View("CustomerLogin");


        }
        [HttpPost]
        public async  Task<ActionResult<KrinaCustomer>> CustomerLogin(KrinaCustomer u){
           HttpClient httpClient = new HttpClient();
    
         StringContent content = new StringContent(JsonConvert.SerializeObject(u), 
              Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("http://localhost:5108/api/Customer/Login",content);
        
        if(response.IsSuccessStatusCode){
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var dataObject = JsonConvert.DeserializeObject<KrinaCustomer>(jsonResponse);
            HttpContext.Session.SetString("uname",dataObject.Fname);
            HttpContext.Session.SetInt32("cid",dataObject.Cid);



            return RedirectToAction("Index","Home");
        }
        return View("CustomerLogin");
        }

        public async Task<ActionResult> CustomerRegister(){
            return View();
        }
        [HttpPost]
     public async  Task<ActionResult<KrinaCustomer>> CustomerRegister(KrinaCustomer u){
           HttpClient httpClient = new HttpClient();
    
         StringContent content = new StringContent(JsonConvert.SerializeObject(u), 
              Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("http://localhost:5108/api/Customer/Register",content);
        
        if(response.IsSuccessStatusCode){
             

            return RedirectToAction("CustomerLogin");
        }
        return View("CustomerRegister");
        }

          public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("CustomerLogin");
        }
        
        [HttpGet]
        public async Task<IActionResult> EditProfile(){
            int id = (int)HttpContext.Session.GetInt32("cid");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"http://localhost:5108/api/Customer/{id}");
              if(response.IsSuccessStatusCode){
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var dataObject = JsonConvert.DeserializeObject<KrinaCustomer>(jsonResponse);
            return View(dataObject);
              }
              return RedirectToAction("Index","Home");

        }

        [HttpPost]

        public async Task<IActionResult> EditProfile(KrinaCustomer k){
           System.Console.WriteLine(k.Lname);
            HttpClient httpClient = new HttpClient();
              StringContent content = new StringContent(JsonConvert.SerializeObject(k), 
              Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync($"http://localhost:5108/api/Customer/{k.Cid}",content);
            System.Console.WriteLine(response);
           
                return RedirectToAction("Index","Home");
            
            
        }
   
       
    }
}
