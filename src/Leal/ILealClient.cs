namespace Leal;

public partial interface ILealClient
{
    public IStoresClient Stores { get; }
    public ICardsClient Cards { get; }
    public ICustomersClient Customers { get; }
    public ICustomerCardsClient CustomerCards { get; }
    public ILocationsClient Locations { get; }
    public IPostersClient Posters { get; }
    public IRewardsClient Rewards { get; }
    public IStatusClient Status { get; }
}
