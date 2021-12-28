using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Project product = new Project() { Id = 300, Name = "NewName", Category = "NewCategory", Price = 5.7M };
            
            Console.WriteLine("Get");

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(@"https://localhost:44318/project").Result;
                var res = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(res);
            }

            Console.WriteLine("Post");

            using (var client = new HttpClient())
            {
                Project project = new Project() { Title="ConsoleProject"};
                var response = client.DeleteAsync(@"https://localhost:44318/project/AddProject").Result;
                var statusCode = response.StatusCode.ToString();
                Console.WriteLine(statusCode.ToString());
            }
            Console.WriteLine("Delete");

            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(@"https://localhost:44318/project/6").Result;
                var statusCode = response.StatusCode.ToString();
                Console.WriteLine(statusCode.ToString());
            }



            Console.ReadLine();





















            //using (var client = new HttpClient())
            //{
            //    //Console.WriteLine(path + "api/products"); 
            //    var response = client.GetAsync(@"https://localhost:44303/api/products").Result;
            //    var res = response.Content.ReadAsStringAsync().Result;
            //    var rez2 = response.Content.ReadAsAsync<List<Project>>().Result;
            //    foreach (Project p in rez2)
            //        Console.WriteLine();
            //}

            //Console.WriteLine("Post");

            //using (var client = new HttpClient())
            //{
            //    var response = client.PostAsJsonAsync(@"https://localhost:44303/api/products", product).Result;
            //    var statusCode = response.StatusCode.ToString();
            //    Console.WriteLine(statusCode.ToString());
            //}

        }
    }
}
