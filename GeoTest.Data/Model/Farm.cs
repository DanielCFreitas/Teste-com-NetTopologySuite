using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoTest.Data.Model
{
    public class Farm
    {
        public Guid id { get; set; }
        public string description { get; set; }
        public Geometry geometry { get; set; }
    }
}
