using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using secondTask.model;
namespace secondTask.Controllers {
    
    [Route ("/get_url/salam")]
    [ApiController]

    public class testpost : Controller {
        private readonly AppDbContext dbContext;
        public testpost (AppDbContext db) {
            dbContext = db;
        }

        [HttpGet]
        public ActionResult<string> Get() {
            
          

            return Ok();

        }

    }

}