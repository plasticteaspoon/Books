using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace books.Controllers 
{
    public class BookController : ApiController
    {
        [HttpGet]
        [Route("api/book")]
        public JArray Get()
        {
            return new JArray(
                new JObject(
                    new JProperty("title", "Baddy wins"),
                    new JProperty("author", "Daddy Drury")
                    ),
                    
                new JObject(
                    new JProperty("title", "Gooddy wins"),
                    new JProperty("author", "Daddy Drury")
                    )
                );
        }
    }
}
