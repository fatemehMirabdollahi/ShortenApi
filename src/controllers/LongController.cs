using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using secondTask;
using secondTask.model;
namespace secondTask.Controllers {
    [ApiController]
    [Route ("/Redirect/{*shortUrl}")]
    public class LongUrl : ControllerBase {
        private readonly AppDbContext dbContext;
        public LongUrl (AppDbContext db) {
            dbContext = db;
        }

        [HttpGet]
        public ActionResult<string> Get (string shortUrl) {
            try {
                Url found = dbContext.urls.Find (shortUrl);
                Console.WriteLine (found.Long);
                return Redirect (found.Long);
            } catch (Exception) {
                return NotFound ();
            }

        }
    }

}