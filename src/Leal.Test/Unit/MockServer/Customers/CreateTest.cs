using Leal;
using Leal.Test.Unit.MockServer;
using Leal.Test.Utils;
using NUnit.Framework;

namespace Leal.Test.Unit.MockServer.Customers;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "customer": {
                "first_name": "first_name"
              }
            }
            """;

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
                    .WithPath("/api/v1/accounts/1/customers")
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

        var response = await Client.Customers.CreateAsync(
            new CreateCustomersRequest
            {
                AccountId = 1,
                Customer = new CreateCustomersRequestCustomer { FirstName = "first_name" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
