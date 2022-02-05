using BCFM.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Xunit;

namespace Test2 {
    public class BCFMControllerTest {
        [Fact]
        public void DefaultEndPointShouldReturnOk() {
            string url = "http://localhost:44320";
            var request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }
    }
}
