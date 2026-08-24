using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Cards;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "card": {
                "name": "name"
              }
            }
            """;

        const string mockResponse = """
            {
              "archived_at": "archived_at",
              "card_color": "card_color",
              "created_at": "created_at",
              "customer_cards_count": 1,
              "header_text": "header_text",
              "id": 1,
              "initial_stamps": 1,
              "name": "name",
              "rewards_count": 1,
              "stamp_background_color": "stamp_background_color",
              "stamp_color": "stamp_color",
              "stamp_icon": "stamp_icon",
              "stamps_required": 1,
              "strip_color": "strip_color",
              "strip_preset": "strip_preset",
              "strip_type": "strip_type",
              "text_color": "text_color",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/cards")
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

        var response = await Client.Cards.CreateAsync(
            new CreateCardsRequest
            {
                AccountId = 1,
                Card = new CreateCardsRequestCard { Name = "name" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
