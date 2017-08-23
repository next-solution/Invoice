using System.Threading.Tasks;
using FluentAssertions;
using Invoice.Infrastructure.Services;
using Xunit;
using Moq;
using Invoice.Core.Repositories;
using AutoMapper;
using Invoice.Core.Domain;

namespace Invoice.Tests.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async Task register_user_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();
            var userService = new UserService(userRepositoryMock.Object, encrypterMock.Object, mapperMock.Object);
            await userService.RegisterAsync("usermock", "password", "Testowy Tester");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
        [Fact]
        public async Task add_customer_async_should_invoke_add_async_on_repository()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mapperMock = new Mock<IMapper>();
            var customerService = new CustomerService(customerRepositoryMock.Object, mapperMock.Object);
            await customerService.AddAsync(1234567891, "customermock", "address");

            customerRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Customer>()), Times.Once);

        }
    }
}