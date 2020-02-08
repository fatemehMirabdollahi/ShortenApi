using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SecondTask.Model;
namespace SecondTask.controllers {

    [Route ("get_shorturl")]
    [ApiController]

    public class ShortenUrl : Controller {
        private readonly AppDbContext dbContext;
        public ShortenUrl (AppDbContext db) {
            dbContext = db;
        }

        [HttpPost]
        public ActionResult<string> PostURl ([FromBody] Url url) {

            if (Uri.IsWellFormedUriString (url.Long, UriKind.Absolute) == false)
                return BadRequest ();
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
            Response response = new Response (url.Short);
            return Ok (response);
        }

    }

    class Response {
        public string shortUrl { get; set; }

        public Response (string response) {

            this.shortUrl = response;
        }
        public override string ToString () {
            return shortUrl;
        }
    }
}