using Leal;
using Leal.Test.Unit.MockServer;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Locations;

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
                    .WithPath("/api/v1/accounts/1/locations/1")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Locations.DeleteAsync(new DeleteLocationsRequest { AccountId = 1, Id = 1 })
        );
    }
}
