using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PropertyAPI.Models
{
    [Table("Photo")]
    public class Photo
    {
        public int Id { get; set; }
        [ForeignKey("PropertyModel")]
        public int PropertyId { get; set; }
        public string Url { get; set; }
        
    }
}