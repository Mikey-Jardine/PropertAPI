using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAPI.Requests
{
    public class PropertyRequest : BaseRequest
    {
        public int Id { get; set; }
        public string GroupLogoUrl { get; set; }
        public string BedsString { get; set; }
        public int Price { get; set; }
        public double SizeStringMeters { get; set; }
        public string DisplayAddress { get; set; }
        public string PropertyType { get; set; }
        public string BerRating { get; set; }
        public string MainPhoto { get; set; }
        public List<string> Photos { get; set; }
    }
}
