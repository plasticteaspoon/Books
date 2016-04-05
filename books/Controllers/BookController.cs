using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using PetaPoco;
using books.Models;
using System.IO;
using System.Web.Hosting;

namespace books.Controllers 
{
    public class BookController : ApiController
    {
        [HttpGet]
        [Route("api/book")]
        public JArray Get()
        {
            Database db = new Database("books");

            List<Book> books = db.Fetch<Book>("");

            JArray result = new JArray(
                books.Select(b => new JObject(
                    new JProperty("id", b.id),
                    new JProperty("title", b.title),
                    new JProperty("author", b.author))));

            File.WriteAllText(
                HostingEnvironment.MapPath("/App_Data/books.json"), 
                result.ToString(Newtonsoft.Json.Formatting.Indented));

            return result;

            //return new JArray(
            //    new JObject(
            //        new JProperty("title", "Baddy wins"),
            //        new JProperty("author", "Daddy Drury")
            //        ),
                    
            //    new JObject(
            //        new JProperty("title", "Gooddy wins"),
            //        new JProperty("author", "Daddy Drury")
            //        )
            //    );
        }
    }
}
