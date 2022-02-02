using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Json.Net;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace BCFM.Controllers {
    [Route("")]
    [ApiController]
    public class BCFMController : ControllerBase {

        private IConfiguration _configuration;
        public BCFMController(IConfiguration configuration) {
            _configuration = configuration;
        }

        public BCFMController() {

        }

        [HttpGet("")]
        public IActionResult GetName() {
            Person person1 = new Person { Name = "Furkan", Surname = "Ekici" };
            return Ok(person1);
        }
       
        
        [HttpPost]
        [Route("")]
        [Route("temperature")]
        public IActionResult ReturnErrorMessage() {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("message", "The method is not allowed for the requested URL.");

            return BadRequest(dict);
        }



        [HttpGet("temperature")]
        public IActionResult GetTemperature(string city) {
           
            var apiKey = _configuration.GetSection("APIKey").Value;
            var url = "http://api.weatherapi.com/v1/current.json?q=" + city + "&key=" + apiKey;
            var request = WebRequest.Create(url);
            request.Method = "GET";


            WebResponse webResponse;

            try {
                webResponse = request.GetResponse();
            }
            catch {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("message", "Internal Server Error");

                return BadRequest(dict);

            }
            
           
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            dynamic innerData = JObject.Parse(data);
            int temperature = innerData.current.temp_c;
            City city1 = new City { CityName = city.ToLower(), Temperature = temperature };

            return Ok(city1);
            }
    }

    class City {
        public string CityName { get; set; }
        public double Temperature { get; set; }
    }

    class Person {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
