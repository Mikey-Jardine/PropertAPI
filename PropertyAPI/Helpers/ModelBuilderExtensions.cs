using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyAPI.Models;

namespace PropertyAPI.Helpers
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var photo = new Photo()
            {
                Id = 1,
                PropertyId = 4292232,
                Url =
                    "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"
            };

            var photo2 = new Photo()
            {
                Id = 2,
                PropertyId = 4292232,
                Url =
                    "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"
            };

            modelBuilder.Entity<Property>().HasData(photo);
            modelBuilder.Entity<Property>().HasData(photo2);

            modelBuilder.Entity<Property>().HasData(
                new Property()
                {
                    Id = 4292232,
                    GroupLogoUrl = "https://photosa.propertyimages.ie/groups/9/0/4/6409/logo.jpg",
                    BedsString = "2 beds",
                    Price = 395000,
                    SizeStringMeters = 52.95,
                    DisplayAddress = "Apt. 16 The Northumberlands, Off Lower Mount Street Dublin 2",
                    PropertyType = "Apartment",
                    BerRating = "D2",
                    MainPhoto =
                        "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"
                    
                }
            );
        }

    }
}
