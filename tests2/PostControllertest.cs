using System;
using Newtonsoft.Json;
using RA;
using secondTask;
using Xunit;
namespace secondTask {
    public class LongControllerTest {

        [Fact]
        public void longUrlLenght () {
            var body = new {
                Long = "https://www.google.com",
                Short = "da"
            };
            new RestAssured ()
                .Given ()
                .Name ("lenghtShort")
                .Header ("Content-Type", "application/json")
                .Body (body)
                .When ()
                .Post ("http://localhost:5000/get_shorturl")
                .Then ()
                .TestStatus ("test status", re => re == 200)
                .TestBody ("test body", b => ((String) b.shortUrl).Length == 8)
                .Assert ("test body")
                .Assert ("test status");

        }

        [Fact]
        public void notValidTest () {
            var body = new {
                Long = "https:\\//www.google.com",
                Short = "da"
            };
            new RestAssured ()
                .Given ()
                    .Name ("backSlash")
                    .Header ("Content-Type", "application/json")
                    .Body (body)
                .When ()
                    .Post ("http://localhost:5000/get_shorturl")
                .Then ()
                    .TestStatus ("test status", re => re == 400)
                    .Assert ("test status");

        }
         [Fact]
        public void notValidTest2 () {
            var body = new {
                Long = "salam",
                Short = "da"
            };
            new RestAssured ()
                .Given ()
                    .Name ("with_nothing")
                    .Header ("Content-Type", "application/json")
                    .Body (body)
                .When ()
                    .Post ("http://localhost:5000/get_shorturl")
                .Then ()
                    .TestStatus ("test status", re => re == 400)
                    .Assert ("test status");

        }
         [Fact]
        public void notValidTest3 () {
            var body = new {
                Long = "https:/w.google.com",
                Short = "da"
            };
            new RestAssured ()
                .Given ()
                    .Name ("one_slash")
                    .Header ("Content-Type", "application/json")
                    .Body (body)
                .When ()
                    .Post ("http://localhost:5000/get_shorturl")
                .Then ()
                    .TestStatus ("test status", re => re == 400)
                    .Assert ("test status");

        }
         [Fact]
        public void persianUrlTest () {
            var body = new {
                Long = "https://www.گوگل.com",
                Short = "da"
            };
            new RestAssured ()
                .Given ()
                .Name ("persion_test")
                .Header ("Content-Type", "application/json")
                .Body (body)
                .When ()
                .Post ("http://localhost:5000/get_shorturl")
                .Then ()
                .TestStatus ("test status", re => re == 200)
                .Assert ("test status");

        }
        [Fact]
            public void hashTest () {
            var body = new {
                Long = "https://www.گوگل.com",
                Short = "da"
            };
            new RestAssured ()
                .Given ()
                .Name ("hash_test")
                .Header ("Content-Type", "application/json")
                .Body (body)
                .When ()
                .Post ("http://localhost:5000/get_shorturl")
                .Then ()
                .TestStatus ("test status", re => re == 200)
                .Assert ("test status");

        }
        
    }
}