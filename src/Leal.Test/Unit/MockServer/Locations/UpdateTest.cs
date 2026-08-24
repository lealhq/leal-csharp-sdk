using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Locations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "location": {}
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
                    .WithPath("/api/v1/accounts/1/locations/1")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Locations.UpdateAsync(
            new UpdateLocationsRequest
            {
                AccountId = 1,
                Id = 1,
                Location = new UpdateLocationsRequestLocation(),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
