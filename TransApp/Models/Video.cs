﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransApp.Models
{
    public class Video
    {
        public int ID { get; set; }
        public int catID { get; set; }
        public string videoName { get; set; }
        public DateTime videoTime { get; set; }

    }
}