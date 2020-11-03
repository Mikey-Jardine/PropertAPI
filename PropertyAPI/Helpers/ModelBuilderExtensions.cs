using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using PropertyAPI.Entities;

namespace PropertyAPI.Helpers
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            if (!File.Exists(@"housedata.json"))
            {
                return;
            }
            var data = File.ReadAllText(@"housedata.json");
            var properties = JsonConvert.DeserializeObject<List<Property>>(data);
            var photoId = 1;

            modelBuilder.Entity<Property>().HasData(properties);

            foreach (var property in properties)
            {
                var photoList = new List<Photo>();
                foreach (var photo in property.Photos)
                {
                    photoList.Add(new Photo() { Id = photoId, PropertyId = property.Id, Url = photo });
                    photoId++;
                }
                modelBuilder.Entity<Photo>().HasData(photoList);
            }
        }
    }
}
