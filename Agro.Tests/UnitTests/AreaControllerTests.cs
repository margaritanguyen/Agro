using Agro.Controllers;
using Moq;
using Agro.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agro.Services.Interfaces;
using AutoMapper;
using Agro.AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Tests.UnitTests
{
    public class AreaControllerTests
    {
        [Fact]
        public void Index_Areas_RerurnsView()
        {
            //Arrange
            var mock = new Mock<IAreaService>();
            mock.Setup(repo => repo.GetAllAreas()).Returns(GetAreasList);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AppMappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var sut = new AreaController(mock.Object, mapper);

            //Act
            var result = sut.Index(null, string.Empty, string.Empty);

            //Assert
            Assert.IsType<ViewResult>(result.Result);
        }

        private Task<IList<Area>> GetAreasList()
        {
            var areasList = new List<Area> {
                new Area() { Id = 1, Code = 1, Name = "One"},
                new Area() { Id = 2, Code = 2, Name = "Two"},
                new Area() { Id = 3, Code = 3, Name = "Three"}
                };

            var result = (IList<Area>)areasList;

            return Task.FromResult(result);
        }

    }
}
