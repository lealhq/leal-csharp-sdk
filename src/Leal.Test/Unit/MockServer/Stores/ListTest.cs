using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Stores;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
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
            ]
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/accounts").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Stores.ListAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
