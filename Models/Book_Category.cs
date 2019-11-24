﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW2.Models
{

    public class Book_Category
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public int num_results { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string list_name { get; set; }
        public string display_name { get; set; }
        public string list_name_encoded { get; set; }
        public string oldest_published_date { get; set; }
        public string newest_published_date { get; set; }
        public string updated { get; set; }
    }

}
