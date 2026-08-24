using Leal.Core;

namespace Leal;

public partial class LealClient : ILealClient
{
    private readonly RawClient _client;

    public LealClient(string? token = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Leal" },
                { "X-Fern-SDK-Version", global::Leal.Version.Current },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>() { { "Authorization", $"Bearer {token ?? ""}" } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        Stores = new StoresClient(_client);
        Cards = new CardsClient(_client);
        Customers = new CustomersClient(_client);
        CustomerCards = new CustomerCardsClient(_client);
        Locations = new LocationsClient(_client);
        Posters = new PostersClient(_client);
        Rewards = new RewardsClient(_client);
        Status = new StatusClient(_client);
    }

    public IStoresClient Stores { get; }

    public ICardsClient Cards { get; }

    public ICustomersClient Customers { get; }

    public ICustomerCardsClient CustomerCards { get; }

    public ILocationsClient Locations { get; }

    public IPostersClient Posters { get; }

    public IRewardsClient Rewards { get; }

    public IStatusClient Status { get; }
}
