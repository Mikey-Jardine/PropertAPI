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
            modelBuilder.Entity<PhotoEntity>(p =>
            {
                p.HasOne(p => p.Property)
                 .WithMany(pr => pr.PhotosCollection)
                 .HasForeignKey(p => p.PropertyId);
            });

            var data = File.ReadAllText(@"housedata.json");
            var properties = JsonConvert.DeserializeObject<List<PropertyEntitiy>>(data);
            var photoId = 1;

            foreach (var property in properties)
            {
                property.InitialiseJson();
                var photoList = new List<PhotoEntity>();
                foreach (var photo in property.PhotosCollection)
                {
                    photo.PhotoId = photoId;
                    photo.PropertyId = property.Id;
                    photoId++;
                    photoList.Add(photo);
                    modelBuilder.Entity<PhotoEntity>().HasData(new 
                    { 
                        PhotoId = photo.PhotoId, 
                        PropertyId = photo.PropertyId,
                        Url = photo.Url 
                    });
                }
                modelBuilder.Entity<PropertyEntitiy>().HasData(new
                {
                    Id = property.Id,
                    GroupLogoUrl = property.GroupLogoUrl,
                    BedsString = property.BedsString,
                    Price = property.Price,
                    SizeStringMeters = property.SizeStringMeters,
                    DisplayAddress= property.DisplayAddress,
                    PropertyType = property.PropertyType,
                    BerRating = property.BerRating,
                    MainPhoto = property.MainPhoto
                });
            }
            
        }
    }
}
