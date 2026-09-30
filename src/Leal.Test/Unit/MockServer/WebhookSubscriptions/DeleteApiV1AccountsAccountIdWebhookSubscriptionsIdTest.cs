using Leal;
using Leal.Test.Unit.MockServer;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.WebhookSubscriptions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteApiV1AccountsAccountIdWebhookSubscriptionsIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/webhook_subscriptions/1")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.WebhookSubscriptions.DeleteApiV1AccountsAccountIdWebhookSubscriptionsIdAsync(
                new DeleteApiV1AccountsAccountIdWebhookSubscriptionsIdRequest
                {
                    AccountId = 1,
                    Id = 1,
                }
            )
        );
    }
}
