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
        private PropertyController _controller;
        private AppDBContext context;
        private ServiceCollection services;
        private DbContextOptions<AppDBContext> _options;
        private ServiceProvider serviceProvider;
        private IPropertyService propertyService { get; set; }
        private IPropertyRepository propertyRepository { get; set; }

        private void InitializeDbContextServices()
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
                var connectionString = _configuration.GetConnectionString("AppDBContext");
                builder.UseSqlServer(connectionString, opt =>
                {
                    opt.EnableRetryOnFailure();
                    opt.CommandTimeout(15);
                });
            });

            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<SearchResultsModel>();
            services.AddTransient<PropertyModel>();
            services.AddTransient<PropertyController>();
        }

        [SetUp]
        public void Setup()
        {
            InitializeDbContextServices();

            serviceProvider = services.BuildServiceProvider();
            context = serviceProvider.GetRequiredService<AppDBContext>();
            propertyService = serviceProvider.GetRequiredService<IPropertyService>();
            propertyRepository = serviceProvider.GetRequiredService<IPropertyRepository>();

            _controller = serviceProvider.GetRequiredService<PropertyController>();
        }


        [Test]
        public void GetPropertyTest()
        {
            var result =  _controller.GetAllProperties();
            var count = context.Properties.Count();

            Assert.NotNull(result);
            Assert.AreEqual(count, result.Count());
        }

        [Test]
        public void GetPropertyWithIdTest()
        {
            var result = _controller.GetProperty(4292232);

            Assert.NotNull(result);
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
        }

        [Test]
        public void DeletePropertyTest()
        {
            var result = _controller.DeleteProperty(4229499);

            Assert.NotNull(result);
        }

        [Test]
        public void DeletePropertyNotExistTest()
        {
            var result = _controller.DeleteProperty(1);

            Assert.NotNull(result);

        }
    }
}
