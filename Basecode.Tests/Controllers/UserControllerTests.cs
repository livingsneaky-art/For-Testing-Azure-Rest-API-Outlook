using Basecode.Services.Interfaces;
using Basecode.WebApp.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basecode.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _fakeUserService;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _fakeUserService = new Mock<IUserService>();
            _controller = new UserController(_fakeUserService.Object);
        }

        [Fact]
        public void Index_HasUsers_ReturnsUsers()
        {
            // Arrange

        }
    }
}
