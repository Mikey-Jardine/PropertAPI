using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PropertyAPI.Models
{
    [Table("Photo")]
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PropertyId")]
        public int PropertyId { get; set; }
        public string Url { get; set; }
        
    }
}