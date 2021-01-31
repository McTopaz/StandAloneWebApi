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
            var baseAddress = "http://localhost:9000/";
            GlobalData.Load();

            using (WebApp.Start<StartUp>(url: baseAddress))
            {
                var client = new HttpClient();
                
                var response = client.GetAsync(baseAddress + "api/values").Result;
                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                var r = client.GetAsync(baseAddress + "api/people").Result;
                Console.WriteLine(r);
                Console.WriteLine(r.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        }
    }
}
