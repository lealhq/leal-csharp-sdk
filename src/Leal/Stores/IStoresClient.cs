namespace Leal;

public partial interface IStoresClient
{
    /// <summary>
    /// Returns every store the authenticated user has access to, including summary counts for locations, cards, customers, and posters.
    /// </summary>
    WithRawResponseTask<IEnumerable<ListStoresResponseItem>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns detailed information for a single store, including summary counts for its associated resources.
    /// </summary>
    WithRawResponseTask<GetStoresResponse> GetAsync(
        GetStoresRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates the store's name or store_name. Use `store_name` for the public-facing name displayed to customers.
    /// </summary>
    WithRawResponseTask<UpdateStoresResponse> UpdateAsync(
        UpdateStoresRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
