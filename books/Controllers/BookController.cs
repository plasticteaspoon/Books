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
                books.Select(b => b.toJObject()));

            File.WriteAllText(
                HostingEnvironment.MapPath("/App_Data/books.json"), 
                result.ToString(Newtonsoft.Json.Formatting.Indented));

            return result;
        }

        [HttpGet]
        [Route("api/book/{id:int}")]
        public JObject Get(int id)
        {
            Database db = new Database("books");

            Book book = db.Single<Book>(id);

            return book.toJObject();
        }

        [HttpPost]
        [Route("api/book")]
        public JObject Post(Book book)
        {
            Database db = new Database("books");
            db.Insert(book);

            return book.toJObject();
        }

        [HttpPut]
        [Route("api/book/{id:int}")]
        public JObject Put(int id, Book book)
        {
            Database db = new Database("books");
            db.Update(book);

            return book.toJObject();
        }

        [HttpDelete]
        [Route("api/book/{id:int}")]
        public JObject Delete(int id)
        {
            Database db = new Database("books");

            Book book = new Book();
            book.id = id;

            db.Delete(book);

            return new JObject();
        }
    }
}
