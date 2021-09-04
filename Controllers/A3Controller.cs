//Created by Rehan - 081295955149
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using A3.Models;
using A3flat.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace A3.Controllers
{
    [Route("api/[controller]")]
    public class A3Controller : Controller
    {
        [HttpGet]
        public async Task<List<a3dataflat>> GetAll()
        {
            var apiResponse = "";
            List<a3data> a3List = new List<a3data>();
            List<a3dataflat> a3ListFlat = new List<a3dataflat>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://screening.moduit.id/backend/question/three"))
                {
                    //Console.WriteLine(response);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Cannot retrieve BE Question Three");
                    }
                    apiResponse = await response.Content.ReadAsStringAsync(); 
                    //Console.WriteLine(apiResponse);    
                    a3List = JsonConvert.DeserializeObject<List<a3data>>(apiResponse); 

                    foreach(var list in a3List)
                    {                        
                        if (list.Items != null)
                        {
                            foreach(var sublist in list.Items)
                            {
                                a3ListFlat.Add(new a3dataflat { id = list.id, category = list.category, title = sublist.title, description = sublist.description, footer = sublist.footer, createdAt = list.createdAt });
                                
                            }
                        }
                        
                    }
                   
                }
            }
            return a3ListFlat;
        }

        
    }
}