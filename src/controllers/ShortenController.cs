using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using secondTask.model;
namespace secondTask.Controllers {

    [Route ("/get_shorturl")]
    [ApiController]

    public class ShortenUrl : Controller {
        private readonly AppDbContext dbContext;
        public ShortenUrl (AppDbContext db) {
            dbContext = db;
        }

        [HttpPost]
        public ActionResult<string> Post ([FromBody] Url url) {

            StringBuilder shortUrl = new StringBuilder ();
            Random random = new Random ();
            
            for (int i = 0; i < 8; i++) {

                ch = Convert.ToInt32 (Math.Floor (26 * random.NextDouble () + 65));
                
                shortUrl.Append (Convert.ToChar(ch));
            }
            //todo add short for url
            url.Short = url.Long + "short";
            dbContext.urls.Add (url);
            dbContext.SaveChanges ();

            return url.Short;

        }

    }

}