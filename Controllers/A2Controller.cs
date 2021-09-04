//Created by Rehan - 081295955149
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using A2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace A2.Controllers
{
    [Route("api/[controller]")]
    public class A2Controller : Controller
    {
        [HttpGet]
        public async Task<List<a2data>> GetAll(string desc = "", string tit = "", string tag = "")
        {
            var apiResponse = "";
            List<a2data> a2List, a2List2, a2List3 = new List<a2data>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://screening.moduit.id/backend/question/two"))
                {
                    //Console.WriteLine(response);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Cannot retrieve BE Question Two");
                    }
                    apiResponse = await response.Content.ReadAsStringAsync(); 
                                    
                    a2List = JsonConvert.DeserializeObject<List<a2data>>(apiResponse); 
                    //Console.WriteLine(desc);
                    //filter 1
                    if (desc != "" || tit != "")
                    {          
                                      
                        if (desc is not null && tit is not null)
                        {
                            a2List2 = a2List.Where(x => x.description.Contains(desc) || x.title.Contains(tit)).ToList();
                        }
                        else if (desc is not null && tit is null) 
                        {
                            a2List2 = a2List.Where(x => x.description.Contains(desc)).ToList();
                        }
                        else if (desc is null && tit is not null) 
                        {
                            a2List2 = a2List.Where(x => x.title.Contains(tit)).ToList();
                        }
                        else
                        {
                             
                            a2List2 = a2List;
                        }
                    
                    }
                    else
                    {
                        
                         a2List2 = a2List;
                    }
                    
                    //filter 2
                    if (tag != "")
                    {
                    //     //Console.WriteLine(tag);
                        if (tag is not null)
                        {
                            a2List3 = a2List2.Where(y => y.tags != null && y.tags.Contains(tag)).ToList();
                        }
                        else
                        {                            
                            a2List3 = a2List2;
                        }                        
                    }
                    else
                    {
                        a2List3 = a2List2;
                    }

                }
            }
            return a2List3.OrderByDescending(x => x.id).Take(3).ToList();
        }
    }
}