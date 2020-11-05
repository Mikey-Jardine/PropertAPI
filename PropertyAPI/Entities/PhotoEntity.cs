using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PropertyAPI.Entities
{
    [Table("Photo")]
    public class PhotoEntity : BaseEntity
    {
        [Key]
        public int PhotoId { get; set; }
        //[ForeignKey("PropertyId")]
        public int PropertyId { get; set; }
        public PropertyEntitiy Property { get; set; }
        public string Url { get; set; }
        
    }
}