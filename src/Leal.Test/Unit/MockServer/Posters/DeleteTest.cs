using Leal;
using Leal.Test.Unit.MockServer;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Posters;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/posters/1")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Posters.DeleteAsync(new DeletePostersRequest { AccountId = 1, Id = 1 })
        );
    }
}
