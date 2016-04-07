using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
using Newtonsoft.Json.Linq;

namespace books.Models
{
    [PetaPoco.TableName("book")]
    public class Book
    {
        public int id { get; set; }
        public string title { get; set;}
        public string author { get; set; }

        public JObject toJObject() {

            return new JObject(
                    new JProperty("id", id),
                    new JProperty("title", title),
                    new JProperty("author", author));
        }
    }
}