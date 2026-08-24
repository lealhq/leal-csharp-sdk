using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Rewards;

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
                "account_id": 1,
                "active": true,
                "card_id": 1,
                "created_at": "created_at",
                "description": "description",
                "id": 1,
                "name": "name",
                "position": 1,
                "stamps_required": 1,
                "updated_at": "updated_at"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/rewards")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Rewards.ListAsync(new ListRewardsRequest { AccountId = 1 });
        JsonAssert.AreEqual(response, mockResponse);
    }
}
