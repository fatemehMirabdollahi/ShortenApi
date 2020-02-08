using System;
using Newtonsoft.Json;
using RA;
using secondTask;
using Xunit;
namespace secondTask {
    public class PesianUrlTest {

        [Fact]
        public void shortUrlMore () {

            new RestAssured ()
                .Given ()
                    .Name ("short more than 8")
                    .Header ("Content-Type", "application/json")
                .When ()
                    .Get ("http://localhost:5000/Redirect/aaaaaaaaa")
                .Then ()
                    .TestStatus ("test status", re => re == 400)
                    .Assert ("test status");

        }

        [Fact]
        public void shortUrlNumber () {

            new RestAssured ()
                .Given ()
                    .Name ("not found short with number")
                    .Header ("Content-Type", "application/json")
                .When ()
                    .Get ("http://localhost:5000/Redirect/a123fsd4")
                .Then ()
                    .TestStatus ("test status", re => re == 400)
                    .Assert ("test status");

        }

        [Fact]
        public void shortUrlLess () {

            new RestAssured ()
                .Given ()
                    .Name ("not_found_short")
                    .Header ("Content-Type", "application/json")
                .When ()
                    .Get ("http://localhost:5000/Redirect/aaaa")
                .Then ()
                    .TestStatus ("test status", re => re == 400)
                    .Assert ("test status");

        }

    }
}