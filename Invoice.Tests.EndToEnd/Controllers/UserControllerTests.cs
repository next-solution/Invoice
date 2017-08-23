using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using FluentAssertions;
using Invoice.Api;
using Invoice.Infrastructure.DTO;
using Invoice.Infrastructure.Commands.Users;

namespace Tests.EndToEnd
{
    public class UserControllerTests
    {
		private readonly TestServer _server;
		private readonly HttpClient _client;

		public UserControllerTests()
		{
			_server = new TestServer(new WebHostBuilder()
						.UseStartup<Startup>());
			_client = _server.CreateClient();
		}

		[Fact]
		public async Task given_valid_user_should_exist()
		{
			var user = "user1";
			var response = await _client.GetAsync($"users/{user}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
		}

		[Fact]
		public async Task given_invalid_user_should_not_exist()
		{
			var user = "user111";
			var response = await _client.GetAsync($"users/{user}");
			response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
		}

		[Fact]
		public async Task given_unique_user_should_be_created()
		{
			var request = new CreateUser
			{
				Username = "user1100",
				Password = "secret"
			};
			var payload = GetPayload(request);
			var response = await _client.PostAsync("users", payload);
			response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
			response.Headers.Location.ToString().ShouldBeEquivalentTo($"users/{request.Username}");

			var userDes = await GetUserAsync(request.Username);
			userDes.Username.ShouldBeEquivalentTo(request.Username);
		}

		private async Task<UserDto> GetUserAsync(string user)
		{
			var response = await _client.GetAsync($"users/{user}");
			var responseString = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<UserDto>(responseString);

		}
		private static StringContent GetPayload(object data)
		{
			var json = JsonConvert.SerializeObject(data);
			return new StringContent(json, Encoding.UTF8, "application/json");
		}
	}
}
