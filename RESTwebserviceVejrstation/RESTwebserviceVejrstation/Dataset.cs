﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTwebserviceVejrstation
{
    public class Dataset
    {
        public string Temperatur { get; set; }
        public string Dato { get; set; } 
        public string Luftfugtighed { get; set; }
        public int Id { get; set; }

        public double LuftfugtighedAvg { get; set; }
        public double TemperaturAvg { get; set; }



    }
}