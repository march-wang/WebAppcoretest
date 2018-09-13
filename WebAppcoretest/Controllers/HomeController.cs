using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppcoretest.Models;

namespace WebAppcoretest.Controllers
{
    public class HomeController : Controller
    {

        [ProtoBuf.ProtoContract]
        public class Person
        {
            [ProtoBuf.ProtoMember(1)] public int Id { get; set; }
            [ProtoBuf.ProtoMember(2)] public string Name { get; set; }
            [ProtoBuf.ProtoMember(3)] public Address Address { get; set; }
        }

        [ProtoBuf.ProtoContract]
        public class Address
        {
            [ProtoBuf.ProtoMember(1)] public string Line1 { get; set; }
            [ProtoBuf.ProtoMember(2)] public string Line2 { get; set; }
        }


        public IActionResult Index()
        {
            var person = new Person
            {
                Id = 1,
                Name = "First",
                Address = new Address { Line1 = "Line1", Line2 = "Line2" }
            };

            using (var file = System.IO.File.Create("D://Person.prb"))
            {

                file.Seek(0, SeekOrigin.Begin);
                var pss =  ProtoBuf.Serializer.Deserialize<Person>(file);
            }



            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
