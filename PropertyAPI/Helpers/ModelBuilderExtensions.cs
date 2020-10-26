using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using PropertyAPI.Models;

namespace PropertyAPI.Helpers
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            if (File.Exists(@"housedata.json"))
            {
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
                    modelBuilder.Entity<Photo>().HasData( photoList );

                }


            }

            //var property = new Property()
            //{
            //    Id = 4292232,
            //    GroupLogoUrl = "https://photosa.propertyimages.ie/groups/9/0/4/6409/logo.jpg",
            //    BedsString = "2 beds",
            //    Price = 395000,
            //    SizeStringMeters = "52.95",
            //    DisplayAddress = "Apt. 16 The Northumberlands, Off Lower Mount Street Dublin 2",
            //    PropertyType = "Apartment",
            //    BerRating = "D2",
            //    MainPhoto =
            //            "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
            //    Photos = new List<string>() 
            //    {
            //        "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
            //        "https://photosa.propertyimages.ie/media/2/3/2/4292232/e0c4c2c8-6a61-4fda-b5a8-59edc32060b6_l.jpg",
            //        "https://photosa.propertyimages.ie/media/2/3/2/4292232/b5ce3372-d71c-4897-91dc7c5b4ce21c17_l.jpg"
            //    }
            //};

            //var photo3 = new Photo()
            //{
            //    Id = 3,
            //    PropertyId = 4229499,
            //    Url = "https://photosa.propertyimages.ie/media/9/9/4/4229499/aae25e08-31b0-465b-ba35-498d78f6b5c9_l.jpg"
            //};

            //var photo4 = new Photo()
            //{
            //    Id = 4,
            //    PropertyId = 4229499,
            //    Url = "https://photosa.propertyimages.ie/media/9/9/4/4229499/7f983103-2529-425a-905b617b23bfa0f7_l.jpg"
            //};

            //var photo5 = new Photo()
            //{
            //    Id = 5,
            //    PropertyId = 4229499,
            //    Url = "https://photosa.propertyimages.ie/media/9/9/4/4229499/4470fb1c-c301-4b1c-8bfae1c85a5d8fbc_l.jpg"
            //};

            //var property2 = new Property()
            //{
            //    Id = 4229499,
            //    GroupLogoUrl = "https://photosa.propertyimages.ie/groups/9/0/4/6409/logo.jpg",
            //    BedsString = "2 beds",
            //    Price = 395000,
            //    SizeStringMeters = "52.95",
            //    DisplayAddress = "Apt. 16 The Northumberlands, Off Lower Mount Street Dublin 2",
            //    PropertyType = "Apartment",
            //    BerRating = "D2",
            //    MainPhoto =
            //            "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
            //    Photos = new List<string>() 
            //    { 
            //        "https://photosa.propertyimages.ie/media/9/9/4/4229499/aae25e08-31b0-465b-ba35-498d78f6b5c9_l.jpg",
            //        "https://photosa.propertyimages.ie/media/9/9/4/4229499/7f983103-2529-425a-905b617b23bfa0f7_l.jpg",
            //        "https://photosa.propertyimages.ie/media/9/9/4/4229499/4470fb1c-c301-4b1c-8bfae1c85a5d8fbc_l.jpg" 
            //    }
            //};

            //var photo6 = new Photo()
            //{
            //    Id = 6,
            //    PropertyId = 4301249,
            //    Url = "https://photosa.propertyimages.ie/media/9/4/2/4301249/0e9bc081-ab16-4885-bddbf33678432a17_l.jpg"
            //};

            //var photo7 = new Photo()
            //{
            //    Id = 7,
            //    PropertyId = 4301249,
            //    Url = "https://photosa.propertyimages.ie/media/9/4/2/4301249/2e03ba2b-471d-4f93-a8ad6bfecd2fd35b_l.jpg"
            //};

            //var property3 = new Property()
            //{
            //    Id = 4301249,
            //    GroupLogoUrl = "https://photosa.propertyimages.ie/groups/9/0/4/6409/logo.jpg",
            //    BedsString = "2 beds",
            //    Price = 395000,
            //    SizeStringMeters = "52.95",
            //    DisplayAddress = "Apt. 16 The Northumberlands, Off Lower Mount Street Dublin 2",
            //    PropertyType = "Apartment",
            //    BerRating = "D2",
            //    MainPhoto =
            //            "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
            //    Photos = new List<string>() 
            //    { 
            //        "https://photosa.propertyimages.ie/media/9/4/2/4301249/0e9bc081-ab16-4885-bddbf33678432a17_l.jpg",
            //        "https://photosa.propertyimages.ie/media/9/4/2/4301249/2e03ba2b-471d-4f93-a8ad6bfecd2fd35b_l.jpg" 
            //    }
            //};

            //var photo8 = new Photo()
            //{
            //    Id = 8,
            //    PropertyId = 4301247,
            //    Url = "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"
            //};

            //var photo9 = new Photo()
            //{
            //    Id = 9,
            //    PropertyId = 4301247,
            //    Url = "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"
            //};

            //var photo10 = new Photo()
            //{
            //    Id = 10,
            //    PropertyId = 4301247,
            //    Url = "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"
            //};

            //var property4 = new Property()
            //{
            //    Id = 4301247,
            //    GroupLogoUrl = "https://photosa.propertyimages.ie/groups/9/0/4/6409/logo.jpg",
            //    BedsString = "2 beds",
            //    Price = 395000,
            //    SizeStringMeters = "52.95",
            //    DisplayAddress = "Apt. 16 The Northumberlands, Off Lower Mount Street Dublin 2",
            //    PropertyType = "Apartment",
            //    BerRating = "D2",
            //    MainPhoto =
            //            "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
            //    Photos = new List<string>() 
            //    {   "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
            //        "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
            //        "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg" 
            //    }
            //};

            //modelBuilder.Entity<Property>().HasData(property);
            //modelBuilder.Entity<Property>().HasData(property2);
            //modelBuilder.Entity<Property>().HasData(property3);
            //modelBuilder.Entity<Property>().HasData(property4);
        }
          
    }
}
