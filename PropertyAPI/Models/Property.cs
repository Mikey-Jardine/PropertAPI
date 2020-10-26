using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PropertyAPI.Entities;

namespace PropertyAPI.Models
{
    [Table("Property")]
    public class Property 
    {
        public Property()
        {
            Photos = new List<string>();
        }

        public void Initialise()
        {
            
        }


        [Key]
        public int Id { get; set; }
        public string GroupLogoUrl { get; set; }
        public string BedsString { get; set; }
        public int Price { get; set; }
        public double SizeStringMeters { get; set; }
        public string DisplayAddress { get; set; }
        public string PropertyType { get; set; }
        //public string BathString { get; set; }
        public string BerRating { get; set; }
        public string MainPhoto { get; set; }
        [NotMapped]
        public ICollection<string> Photos { get; set; }
    }
}