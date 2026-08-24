using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Posters;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "account_id": 1,
                "active": true,
                "card_id": 1,
                "created_at": "created_at",
                "display_url": "display_url",
                "id": 1,
                "paper_size": "paper_size",
                "primary_color": "primary_color",
                "qr_code_url": "qr_code_url",
                "secondary_color": "secondary_color",
                "signup_url": "signup_url",
                "text_color": "text_color",
                "title": "title",
                "updated_at": "updated_at"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/posters")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Posters.ListAsync(new ListPostersRequest { AccountId = 1 });
        JsonAssert.AreEqual(response, mockResponse);
    }
}
