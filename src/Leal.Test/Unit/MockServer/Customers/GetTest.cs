using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Customers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "account_id": 1,
              "birthday": "birthday",
              "created_at": "created_at",
              "customer_cards": [
                "customer_cards"
              ],
              "email": "email",
              "external_references": [
                "external_references"
              ],
              "first_name": "first_name",
              "id": 1,
              "last_name": "last_name",
              "metadata": {
                "key": "value"
              },
              "phone": "phone",
              "stamp_count": 1,
              "updated_at": "updated_at"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/v1/accounts/1/customers/1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Customers.GetAsync(
            new GetCustomersRequest { AccountId = 1, Id = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
