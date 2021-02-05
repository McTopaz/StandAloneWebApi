using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Microsoft.Owin.Hosting;

// https://anthonychu.ca/post/web-api-owin-self-host-docker-windows-containers/
// http://localhost:9000/api/values/

namespace WebApiSelfHost
{
    class Program
    {
        static void Main()
        {
            Console.Title = nameof(WebApiSelfHost);
            GlobalData.Load();
            
            var baseAddress = "http://localhost:9000/";
            WebApp.Start<StartUp>(url: baseAddress);

            Console.WriteLine("WebAPI service running");
            Console.Write("Press any key to exit");
            
            Console.ReadLine();

            //using (WebApp.Start<StartUp>(url: baseAddress))
            //{
            //    var client = new HttpClient();
                
            //    // This work!
            //    var response = client.GetAsync(baseAddress + "api/values").Result;
            //    Console.WriteLine(response);
            //    Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            //    // This don't work!
            //    var r = client.GetAsync(baseAddress + "api/people").Result;
            //    Console.WriteLine(r);
            //    Console.WriteLine(r.Content.ReadAsStringAsync().Result);

            //    Console.ReadLine();
            //}
        }
    }
}
