using AutoMapper;
using Microsoft.AspNetCore.Routing;
using ShopSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UnitTests
{
    public class MapperTests
    {
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ShopMappingProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}
