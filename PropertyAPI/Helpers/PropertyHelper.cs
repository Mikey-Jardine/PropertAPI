using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using PropertyAPI.Entities;

namespace PropertyAPI.Helpers
{
    public static class PropertyHelper
    {
        public static void InitialiseJson(this Property property)
        {
            if (property.Photos != null)
            {
                foreach (var photo in property.Photos)
                {
                    property.PhotosCollection.Add(new Photo { Url = photo });
                }
            }

        }

        public static void PopulatePhotostring(this Property property)
        {
            if (property.PhotosCollection != null)
            {
                foreach (var photo in property.PhotosCollection)
                {
                    property.Photos.Add(photo.Url);
                }
            }

        }
    }
}
