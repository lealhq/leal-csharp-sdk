using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Cards;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "apple_pass_style": "apple_pass_style",
              "archived_at": "archived_at",
              "auxiliary_fields": [
                "auxiliary_fields"
              ],
              "card_color": "card_color",
              "created_at": "created_at",
              "customer_cards_count": 1,
              "expires_at": "expires_at",
              "featured_actions": [
                "featured_actions"
              ],
              "google_logo_style": "google_logo_style",
              "google_wallet": {
                "hero_image": "hero_image",
                "text_color": "text_color",
                "warnings": [
                  "warnings"
                ]
              },
              "header_text": "header_text",
              "id": 1,
              "initial_stamps": 1,
              "name": "name",
              "qr_style": "qr_style",
              "referee_stamps": 1.1,
              "referrals_enabled": true,
              "referrer_stamps": 1.1,
              "rewards_count": 1,
              "show_member_field": true,
              "show_stamps_to_reward_field": true,
              "stamp_background_color": "stamp_background_color",
              "stamp_color": "stamp_color",
              "stamp_icon": "stamp_icon",
              "stamps_required": 1,
              "strip_color": "strip_color",
              "strip_opacity": 1.1,
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
                    .WithPath("/api/v1/accounts/1/cards/1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Cards.GetAsync(new GetCardsRequest { AccountId = 1, Id = 1 });
        JsonAssert.AreEqual(response, mockResponse);
    }
}
