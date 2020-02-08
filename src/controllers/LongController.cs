using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecondTask;
using SecondTask.Model;
namespace SecondTask.controllers {

    [ApiController]
    [Route ("/Redirect/{*shortUrl}")]
    public class LongUrl : ControllerBase {
        private readonly AppDbContext dbContext;
        public LongUrl (AppDbContext db) {
            dbContext = db;
        }

        [HttpGet]
        public ActionResult Get (string shortUrl) {
            for (int i = 0; i < shortUrl.Length; i++) {
                if (shortUrl[i] > 122 || shortUrl[i] < 65 || (shortUrl[i] > 90 && shortUrl[i] < 97))
                    return BadRequest ();
            }
            if (shortUrl.Length < 8 || shortUrl.Length > 8) {
                Console.WriteLine ("Asd");
                return BadRequest ();
            }
            try {
                Url found = dbContext.urls.Find (shortUrl);
                return Redirect (found.Long);
            } catch (Exception) {

                return NotFound ();
            }

        }

        class ResponseExample {
            public string response { get; set; }
            public ResponseExample (string response) {
                this.response = response;
            }
        }
    }

}