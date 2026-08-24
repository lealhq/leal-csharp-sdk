using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.CustomerCards;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class StampTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "stamps": 1
            }
            """;

        const string mockResponse = """
            {
              "account_id": 1,
              "apple_wallet_url": "apple_wallet_url",
              "available_rewards": [
                "available_rewards"
              ],
              "card_id": 1,
              "card_name": "card_name",
              "created_at": "created_at",
              "customer_id": 1,
              "google_wallet_url": "google_wallet_url",
              "id": 1,
              "issued_at": "issued_at",
              "pass_installed": true,
              "progress_percentage": 1.1,
              "stamps_count": 1,
              "stamps_remaining": 1,
              "status": "status",
              "updated_at": "updated_at",
              "uuid": "uuid"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/customers/1/customer_cards/1/stamp")
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

        var response = await Client.CustomerCards.StampAsync(
            new StampCustomerCardsRequest
            {
                AccountId = 1,
                CustomerId = 1,
                Id = 1,
                Stamps = 1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
