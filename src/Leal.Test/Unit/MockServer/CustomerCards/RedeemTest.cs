using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.CustomerCards;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RedeemTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "reward_id": 1
            }
            """;

        const string mockResponse = """
            {
              "redemption": {
                "id": 1,
                "redeemed_at": "redeemed_at",
                "reward_id": 1,
                "reward_name": "reward_name",
                "stamps_remaining": 1,
                "stamps_spent": 1
              },
              "success": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/customers/1/customer_cards/1/redeem")
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

        var response = await Client.CustomerCards.RedeemAsync(
            new RedeemCustomerCardsRequest
            {
                AccountId = 1,
                CustomerId = 1,
                Id = 1,
                RewardId = 1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
