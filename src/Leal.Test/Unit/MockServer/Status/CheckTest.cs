using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Status;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CheckTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "api_version": "api_version",
              "authentication": "authentication",
              "developer_portal_url": "developer_portal_url",
              "documentation_url": "documentation_url",
              "openapi_url": "openapi_url",
              "rate_limit": {
                "limit": 1,
                "scope": "scope",
                "window_seconds": 1
              },
              "status": "status"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/api/v1/status").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Status.CheckAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
