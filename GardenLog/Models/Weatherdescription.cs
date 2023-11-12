using System.Runtime.InteropServices;
using System;

namespace GardenLog.Models
{
    public class Weatherdescription
    {
        public Descriptions description { get; set; }
    }
    public class Descriptions
    {
        public int[]? wmocode { get; set; }
        public string[]? descriptions { get; set; }

    }
}
