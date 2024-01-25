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
    public class CustomerController : ControllerBase{
       
       private readonly ILoginServ<KrinaCustomer> loginserv;

    

        public CustomerController(ILoginServ<KrinaCustomer> _loginserv){
            loginserv = _loginserv;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<KrinaCustomer>> CustomerLogin(KrinaCustomer u){
          var res=loginserv.CustomerLogin(u);
          if(res==null){
            return NotFound();
          }
          return res;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CustomerRegister(KrinaCustomer k){
            try{
            loginserv.CustomerRegister(k);

            }
            catch(DbUpdateException e){
                if(CustomerExists(k.Cid)){
                    return Conflict();
                }
                else{
                    throw e;
                }
            }
            return CreatedAtAction("CustomerLogin", new {id=k.Cid},k);
        }

        [HttpPut("{id}")]
           public async Task<IActionResult> Edit(int id,KrinaCustomer k){
            if (id !=k.Cid)
            {
                return BadRequest();
            }

           
        try
        {
         loginserv.EditCustomer(id,k);
        }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KrinaCustomer>> Details(int id){
             var k = loginserv.ViewCustomer(id);

            if (k == null)
            {
                return NotFound();
            }

            return k;
        }
      private bool CustomerExists(int id)
        {
           KrinaCustomer f= loginserv.ViewCustomer(id);
            if(f!=null)
            return true;
            else
            return false;
        }
     

    }
}