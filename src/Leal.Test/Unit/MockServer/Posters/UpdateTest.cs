using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Posters;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "poster": {}
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/posters/1")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Posters.UpdateAsync(
            new UpdatePostersRequest
            {
                AccountId = 1,
                Id = 1,
                Poster = new UpdatePostersRequestPoster(),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
