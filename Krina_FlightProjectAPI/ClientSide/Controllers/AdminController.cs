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
    public class AdminController : Controller
    {
        
        public async Task<ActionResult> AdminLogin()
        {
            return View();


        }
        [HttpPost]
        public async  Task<ActionResult<KrinaAdmin>> AdminLogin(KrinaAdmin u){
           HttpClient httpClient = new HttpClient();
    
         StringContent content = new StringContent(JsonConvert.SerializeObject(u), 
              Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("http://localhost:5108/api/Admin/Login",content);
        
        if(response.IsSuccessStatusCode){
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var dataObject = JsonConvert.DeserializeObject<KrinaAdmin>(jsonResponse);
            HttpContext.Session.SetString("uname",dataObject.Fname);
            HttpContext.Session.SetInt32("Aid",dataObject.Aid);



            return RedirectToAction("GetFlightList","Flight");
        }
        return View("AdminLogin");
        }

     

          public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }

       
    }
}