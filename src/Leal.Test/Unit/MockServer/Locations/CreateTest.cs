using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Locations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "location": {
                "address": "address",
                "name": "name"
              }
            }
            """;

        const string mockResponse = """
            {
              "account_id": 1,
              "address": "address",
              "created_at": "created_at",
              "id": 1,
              "latitude": 1.1,
              "longitude": 1.1,
              "name": "name",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/locations")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Locations.CreateAsync(
            new CreateLocationsRequest
            {
                AccountId = 1,
                Location = new CreateLocationsRequestLocation
                {
                    Address = "address",
                    Name = "name",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
