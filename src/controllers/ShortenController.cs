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
            if (Uri.IsWellFormedUriString(url.Long, UriKind.Absolute)==false)
                return BadRequest();
            StringBuilder shortUrl = new StringBuilder ();
            Random random = new Random ();
            int ch;

            while (true) {

                for (int i = 0; i < 8; i++) {

                    ch = Convert.ToInt32 (Math.Floor (58 * random.NextDouble () + 65));
                    if (90 < ch && ch < 100) {
                        i--;
                        continue;
                    }
                    shortUrl.Append (Convert.ToChar (ch));

                }

                url.Short = shortUrl.ToString ();
                if (dbContext.Find (url.GetType (), url.Short) == null) {
                    break;

                }
                shortUrl = new StringBuilder ();
            }

            dbContext.urls.Add (url);
            dbContext.SaveChanges ();
            return url.Short;
        }

    }

}