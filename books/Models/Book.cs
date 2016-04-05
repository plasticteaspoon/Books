﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace books.Models
{
    [PetaPoco.TableName("book")]
    public class Book
    {
        public int id { get; set; }
        public string title { get; set;}
        public string author { get; set; }
    }
}