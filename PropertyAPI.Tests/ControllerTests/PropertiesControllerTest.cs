using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using NUnit.Framework;
using PropertyAPI.Controllers;
using PropertyAPI.Interfaces;
using PropertyAPI.Models;
using PropertyAPI.Tests.Mocks;

namespace PropertyAPI.Tests.ControllerTests
{
    public class PropertiesControllerTest : BaseControllerTests
    {

        private PropertiesController _controller;
        private AppDBContext _context;
        private DbContextOptions<AppDBContext> _options;

        private static List<Photo> _photoList1 = new List<Photo>()
        {
            new Photo() { Id = 1, PropertyId = 1, Url = "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"},
            new Photo() { Id = 2, PropertyId = 1, Url = "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"},
            new Photo() { Id = 3, PropertyId = 1, Url = "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"}
        };

        private static List<Photo> _photoList2 = new List<Photo>()
        {
            new Photo() { Id = 4, PropertyId = 2, Url = "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"},
            new Photo() { Id = 5, PropertyId = 2, Url = "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"},
            new Photo() { Id = 6, PropertyId = 2, Url = "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"}
        };

        private static List<Photo> _photoList3 = new List<Photo>()
        {
            new Photo() { Id = 7, PropertyId = 3, Url = "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"},
            new Photo() { Id = 8, PropertyId = 3, Url = "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"},
            new Photo() { Id = 9, PropertyId = 3, Url = "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"}
        };


        private static Property _property1 = new Property()
        {
            Id = 1,
            GroupLogoUrl = "https://photosa.propertyimages.ie/groups/9/0/4/6409/logo.jpg",
            BedsString = "2 beds",
            Price = 395000,
            SizeStringMeters = 52.95,
            DisplayAddress = "Apt.	16	The	Northumberlands,	Off	Lower	Mount	Street Dublin  2",
            PropertyType = "Apartment",
            BerRating = "D2",
            MainPhoto =
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
            Photos = _photoList1
        };

        private static Property _property2 = new Property()
        {
            Id = 1,
            GroupLogoUrl = "https://photosa.propertyimages.ie/groups/9/0/4/6409/logo.jpg",
            BedsString = "2 beds",
            Price = 395000,
            SizeStringMeters = 52.95,
            DisplayAddress = "Apt.	16	The	Northumberlands,	Off	Lower	Mount	Street Dublin  2",
            PropertyType = "Apartment",
            BerRating = "D2",
            MainPhoto =
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
            Photos = _photoList2
        };

        private static Property _property3 = new Property()
        {
            Id = 1,
            GroupLogoUrl = "https://photosa.propertyimages.ie/groups/9/0/4/6409/logo.jpg",
            BedsString = "2 beds",
            Price = 395000,
            SizeStringMeters = 52.95,
            DisplayAddress = "Apt.	16	The	Northumberlands,	Off	Lower	Mount	Street Dublin  2",
            PropertyType = "Apartment",
            BerRating = "D2",
            MainPhoto =
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
            Photos = _photoList3
        };

        private List<Property> properties = new List<Property>() { _property1, _property2, _property3 };

        public void InitializeDatabaseWithDataTest()
        {
            using (var context = new AppDBContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Property.AddRange(properties);
                context.SaveChanges();
            }
        }

        [SetUp]
        public void Setup()
        {
            IQueryable<Property> properties = new List<Property>
            {
                _property1

            }.AsQueryable();

            var _photoasQueryable = _photoList1.AsQueryable();

            var mockSetProperty = new Mock<DbSet<Property>>();
            mockSetProperty.As<IQueryable<Property>>().Setup(m => m.Provider).Returns(properties.Provider);
            mockSetProperty.As<IQueryable<Property>>().Setup(m => m.Expression).Returns(properties.Expression);
            mockSetProperty.As<IQueryable<Property>>().Setup(m => m.ElementType).Returns(properties.ElementType);
            mockSetProperty.As<IQueryable<Property>>().Setup(m => m.GetEnumerator()).Returns(properties.GetEnumerator());

            var mockSetPhoto = new Mock<DbSet<Photo>>();
            mockSetPhoto.As<IQueryable<Photo>>().Setup(m => m.Provider).Returns(_photoasQueryable.Provider);
            mockSetPhoto.As<IQueryable<Photo>>().Setup(m => m.Expression).Returns(_photoasQueryable.Expression);
            mockSetPhoto.As<IQueryable<Photo>>().Setup(m => m.ElementType).Returns(_photoasQueryable.ElementType);
            mockSetPhoto.As<IQueryable<Photo>>().Setup(m => m.GetEnumerator()).Returns(_photoasQueryable.GetEnumerator());

            var mockRepository = new Mock<IPropertyRepository>();
            mockRepository.Setup(x => x.CreateProperty(It.IsAny<Property>()));
            mockRepository.Setup(x => x.GetProperty(It.IsAny<int>())).Returns(_property1);
            mockRepository.Setup(x => x.DeleteProperty(It.IsAny<int>())).Returns(_property1);
            mockRepository.Setup(x => x.UpdateProperty(It.IsAny<Property>()));
            mockRepository.Setup(x => x.GetAllProperty()).Returns(properties);

            _controller = new PropertiesController(_context, mockRepository.Object);
        }


        [Test]
        public void GetPropertyTest()
        {
            var result =  _controller.GetProperty();

            Assert.NotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void GetPropertyWithIdTest()
        {
            var result = _controller.GetProperty(1);

            Assert.NotNull(result);
            Assert.AreEqual(TaskStatus.RanToCompletion, result.Status);
        }

        [Test]
        public void CreatePropertyTest()
        {
            var property = new Property()
            {
                Id = 6,
                GroupLogoUrl = "https://photosa.propertyimages.ie/groups/9/0/4/6409/logo.jpg",
                BedsString = "2 beds",
                Price = 395000,
                SizeStringMeters = 52.95,
                DisplayAddress = "Apt.	16	The	Northumberlands,	Off	Lower	Mount	Street Dublin  2",
                PropertyType = "Apartment",
                BerRating = "D2",
                MainPhoto =
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                Photos = _photoList1
            };

            var result = _controller.CreateProperty(property);

            Assert.NotNull(result);
            Assert.AreEqual(TaskStatus.RanToCompletion, result.Status);
        }

        [Test]
        public void UpdatePropertyTest()
        {
            var property = new Property()
            {
                Id = 6,
                GroupLogoUrl = "https://photosa.propertyimages.ie/groups/9/0/4/6409/logo.jpg",
                BedsString = "2 beds",
                Price = 395000,
                SizeStringMeters = 52.95,
                DisplayAddress = "Apt.	16	The	Northumberlands,	Off	Lower	Mount	Street Dublin  2",
                PropertyType = "Apartment",
                BerRating = "D2",
                MainPhoto =
                    "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                Photos = _photoList1
            };

            var result = _controller.UpdateProperty(property);

            Assert.NotNull(result);
            Assert.AreEqual(TaskStatus.RanToCompletion, result.Status);
        }

        [Test]
        public void DeletePropertyTest()
        {
            var result = _controller.GetProperty(1);

            Assert.NotNull(result);
            Assert.AreEqual(TaskStatus.RanToCompletion, result.Status);
        }


    }
}
