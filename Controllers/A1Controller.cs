//Created by Rehan - 081295955149
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using A1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace A1.Controllers
{
    [Route("api/[controller]")]
    public class A1Controller : Controller
    {
        [HttpGet]
        public async Task<a1data> GetAll()
        {
            a1data a1List = new a1data();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://screening.moduit.id/backend/question/one"))
                {
                    //Console.WriteLine(response);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Cannot retrieve BE Question One");
                    }
                    var apiResponse = await response.Content.ReadAsStringAsync(); 
                                    
                    a1List = JsonConvert.DeserializeObject<a1data>(apiResponse);   
                }
            }
            return a1List;
        }
    }
}