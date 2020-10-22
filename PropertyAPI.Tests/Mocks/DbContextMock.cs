using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using PropertyAPI.Helpers;
using PropertyAPI.Models;

namespace PropertyAPI.Tests.Mocks
{
    public class CarServiceContextInitTests
    {        
        // to have the same Configuration object as in Startup
        private IConfigurationRoot _configuration;	

        // represents database's configuration
        private DbContextOptions<AppDBContext> _options;
        
        public CarServiceContextInitTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build(); 
            _options = new DbContextOptionsBuilder<AppDBContext>()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options;
        }
    }
}
