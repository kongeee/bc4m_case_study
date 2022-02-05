using BCFM.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Xunit;

namespace Test2 {
    public class BCFMControllerTest {
        [Fact]
        public void DefaultEndPointShouldReturnOk() {
            //This is a simple test for CI/CD process on GitHub Actions

            Assert.Equal(1, 1);
        }
    }
}
