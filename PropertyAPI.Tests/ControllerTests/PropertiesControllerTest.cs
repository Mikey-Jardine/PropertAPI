using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PropertyAPI.Controllers;
using PropertyAPI.Interfaces;
using PropertyAPI.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using PropertyAPI.Repositories;
using PropertyAPI.Services;

namespace PropertyAPI.Tests.ControllerTests
{
    public class PropertiesControllerTest : BaseControllerTests
    {

        private PropertiesController _controller;
        private Mock<AppDBContext> _context;
        private AppDBContext context;
        private ServiceCollection services;
        private DbContextOptions<AppDBContext> _options;
        public Mock<IConfiguration> Configuration { get; }

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
            Photos = new List<string>()
            {
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"
            }
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
            Photos = new List<string>()
            {
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"
            }
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
            Photos = new List<string>()
            {
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"
            }
        };

        private List<Property> properties = new List<Property>() { _property1, _property2, _property3 };
        private ServiceProvider serviceProvider;

        public void InitializeDbContextServices()
        {
            services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<AppDBContext>()
                .UseSqlServer(_configuration.GetConnectionString("AppDBContext"))
                .Options;

            using (context = new AppDBContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.SaveChanges();
            }

            services.AddDbContext<AppDBContext>(builder =>
            {
                var connStr = _configuration.GetConnectionString("AppDBContext");
                builder.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                    opt.CommandTimeout(15);
                });
            });
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IPropertyService, PropertyService>();
        }

        [SetUp]
        public void Setup()
        {
            InitializeDbContextServices();

            serviceProvider = services.BuildServiceProvider();
            context = serviceProvider.GetRequiredService<AppDBContext>();
            var propertyService = serviceProvider.GetRequiredService<IPropertyService>();
            var propertyRepository = serviceProvider.GetRequiredService<IPropertyRepository>();

            _controller = new PropertiesController(context, propertyService, propertyRepository);
        }


        [Test]
        public void GetPropertyTest()
        {
            var result =  _controller.GetAllProperty();

            Assert.NotNull(result);
            Assert.AreEqual(10, result.Count());
        }

        [Test]
        public void GetPropertyWithIdTest()
        {
            var result = _controller.GetProperty(4292232);

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
                Photos = new List<string>()
            {
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"
            }
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
                Id = 4292232,
                GroupLogoUrl = "https://photosa.propertyimages.ie/groups/9/0/4/6409/logo.jpg",
                BedsString = "2 beds",
                Price = 395000,
                SizeStringMeters = 52.95,
                DisplayAddress = "Apt.	16	The	Northumberlands,	Off	Lower	Mount	Street Dublin  2",
                PropertyType = "Apartment",
                BerRating = "D2",
                MainPhoto =
                    "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                Photos = new List<string>()
                {
                    "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                    "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg",
                    "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg"
                }
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
