using AutoMapper;
using CustomerProject.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CustomerProject.Tests
{
    [Trait("Category", "Unit")]
    public class MapperTests
    {
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            Mapper.Initialize(m => m.AddProfile<MappingProfile>());
            Mapper.AssertConfigurationIsValid();
        }
    }
}
