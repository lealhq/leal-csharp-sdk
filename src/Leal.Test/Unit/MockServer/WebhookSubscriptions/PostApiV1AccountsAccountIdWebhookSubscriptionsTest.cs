using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.WebhookSubscriptions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PostApiV1AccountsAccountIdWebhookSubscriptionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "target_url": "target_url"
            }
            """;

        const string mockResponse = """
            {
              "account_id": 1,
              "created_at": "created_at",
              "description": "description",
              "disabled_at": "disabled_at",
              "disabled_reason": "disabled_reason",
              "enabled": true,
              "event": "event",
              "events": [
                "events"
              ],
              "id": 1,
              "last_delivery_at": "last_delivery_at",
              "last_delivery_error": "last_delivery_error",
              "last_delivery_status": 1.1,
              "payload_format": "payload_format",
              "secret": "secret",
              "target_url": "target_url",
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/webhook_subscriptions")
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

        var response =
            await Client.WebhookSubscriptions.PostApiV1AccountsAccountIdWebhookSubscriptionsAsync(
                new PostApiV1AccountsAccountIdWebhookSubscriptionsRequest
                {
                    AccountId = 1,
                    TargetUrl = "target_url",
                }
            );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
