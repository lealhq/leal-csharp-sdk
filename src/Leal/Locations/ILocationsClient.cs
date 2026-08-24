namespace Leal;

public partial interface ILocationsClient
{
    /// <summary>
    /// Returns every physical location belonging to the specified store.
    /// </summary>
    WithRawResponseTask<IEnumerable<ListLocationsResponseItem>> ListAsync(
        ListLocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new physical location for the store. The provided address is
    /// automatically geocoded to latitude and longitude coordinates in the background.
    /// </summary>
    WithRawResponseTask<CreateLocationsResponse> CreateAsync(
        CreateLocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single location by ID.
    /// </summary>
    WithRawResponseTask<GetLocationsResponse> GetAsync(
        GetLocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently deletes a location. This action cannot be undone.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        DeleteLocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing location. If the address is changed, it will be re-geocoded automatically.
    /// </summary>
    WithRawResponseTask<UpdateLocationsResponse> UpdateAsync(
        UpdateLocationsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
