using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppInsights.Core.Entities;
using AppInsights.Web;
using Newtonsoft.Json;
using Xunit;

namespace AppInsights.FunctionalTests.Api
{
    public class ApiToDoItemsControllerList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ApiToDoItemsControllerList(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsTwoItems()
        {
            var response = await _client.GetAsync("/api/appinsights");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ActivityLog>>(stringResponse).ToList();

            Assert.Equal(3, result.Count());
            Assert.Contains(result, i => i.ServerName == SeedData.item1.ServerName);
            Assert.Contains(result, i => i.ServerName == SeedData.item2.ServerName);
            Assert.Contains(result, i => i.ServerName == SeedData.item3.ServerName);
        }
    }
}
