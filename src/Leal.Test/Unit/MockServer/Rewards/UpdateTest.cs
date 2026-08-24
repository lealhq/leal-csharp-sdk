using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Rewards;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "reward": {}
            }
            """;

        const string mockResponse = """
            {
              "account_id": 1,
              "active": true,
              "card_id": 1,
              "created_at": "created_at",
              "description": "description",
              "id": 1,
              "name": "name",
              "position": 1,
              "stamps_required": 1,
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/rewards/1")
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

        var response = await Client.Rewards.UpdateAsync(
            new UpdateRewardsRequest
            {
                AccountId = 1,
                Id = 1,
                Reward = new UpdateRewardsRequestReward(),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
