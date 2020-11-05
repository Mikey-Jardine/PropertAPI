using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PropertyAPI.Entities
{
    [Table("Property")]
    public class PropertyEntitiy : BaseEntity
    {
        public PropertyEntitiy()
        {
            Photos = new List<string>();
            PhotosCollection = new List<PhotoEntity>();
        }

        [JsonConstructor]
        public PropertyEntitiy(IList<string> photos)
        {
            Photos = photos;
            PhotosCollection = new List<PhotoEntity>();
        }

        [Key]
        public int Id { get; set; }
        public string GroupLogoUrl { get; set; }
        public string BedsString { get; set; }
        public int Price { get; set; }
        public double SizeStringMeters { get; set; }
        public string DisplayAddress { get; set; }
        public string PropertyType { get; set; }
        public string BerRating { get; set; }
        public string MainPhoto { get; set; }
        [NotMapped]
        public IList<string> Photos { get; set; }
        [JsonIgnore]
        [NotMapped]
        public ICollection<PhotoEntity> PhotosCollection { get; set; }
    }
}