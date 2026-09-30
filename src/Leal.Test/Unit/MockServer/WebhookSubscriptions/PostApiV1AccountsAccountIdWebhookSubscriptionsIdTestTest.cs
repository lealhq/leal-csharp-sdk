using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.WebhookSubscriptions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "delivered": true,
              "error": "error",
              "event_id": "event_id",
              "status": 1.1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/webhook_subscriptions/1/test")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response =
            await Client.WebhookSubscriptions.PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestAsync(
                new PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestRequest
                {
                    AccountId = 1,
                    Id = 1,
                }
            );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
