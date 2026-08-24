using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Stores;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "account": {}
            }
            """;

        const string mockResponse = """
            {
              "cards_count": 1,
              "created_at": "created_at",
              "customers_count": 1,
              "display_store_name": "display_store_name",
              "id": 1,
              "locations_count": 1,
              "name": "name",
              "personal": true,
              "posters_count": 1,
              "store_name": "store_name",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1")
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

        var response = await Client.Stores.UpdateAsync(
            new UpdateStoresRequest { Id = 1, Account = new UpdateStoresRequestAccount() }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
