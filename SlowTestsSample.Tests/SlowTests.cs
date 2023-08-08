using Microsoft.AspNetCore.Mvc.Testing;
using PactNet;
using Xunit;

namespace SlowTestsSample.Tests
{
    public class SlowTests
    {
        [Fact]
        public async Task Test01() => await Test();

        [Fact]
        public async Task Test02() => await Test();

        [Fact]
        public async Task Test03() => await Test();

        [Fact]
        public async Task Test04() => await Test();

        [Fact]
        public async Task Test05() => await Test();

        [Fact]
        public async Task Test06() => await Test();

        [Fact]
        public async Task Test07() => await Test();

        [Fact]
        public async Task Test08() => await Test();

        [Fact]
        public async Task Test09() => await Test();

        [Fact]
        public async Task Test10() => await Test();

        [Fact]
        public async Task Test11() => await Test();

        [Fact]
        public async Task Test12() => await Test();

        [Fact]
        public async Task Test13() => await Test();

        [Fact]
        public async Task Test14() => await Test();

        [Fact]
        public async Task Test15() => await Test();

        [Fact]
        public async Task Test16() => await Test();

        [Fact]
        public async Task Test17() => await Test();

        [Fact]
        public async Task Test18() => await Test();

        [Fact]
        public async Task Test19() => await Test();

        [Fact]
        public async Task Test20() => await Test();

        private static async Task Test()
        {
            var api1PactBuilder = CreatePactBuilder("API-1", 9091);
            AddGetRequest(api1PactBuilder, "/api-1-endpoint-1");
            AddGetRequest(api1PactBuilder, "/api-1-endpoint-2");

            var api2PactBuilder = CreatePactBuilder("API-2", 9092);
            AddGetRequest(api2PactBuilder, "/api-2-endpoint-1");

            await api1PactBuilder.VerifyAsync(async _ =>
            {
                await api2PactBuilder.VerifyAsync(async _ =>
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, new Uri("/slow-tests", UriKind.RelativeOrAbsolute));
                    var httpClient = new WebApplicationFactory<Program>().CreateClient();
                    await httpClient.SendAsync(request);
                });
            });
        }

        private static void AddGetRequest(IPactBuilderV3 pactBuilder, string url)
        {
            pactBuilder
                .UponReceiving("Test")
                .Given("Test")
                    .WithRequest(HttpMethod.Get, url)
                .WillRespond();
        }

        private static IPactBuilderV3 CreatePactBuilder(string provider, int port)
        {
            var pact = Pact.V3("Test", provider);

            return pact.WithHttpInteractions(port);
        }
    }
}