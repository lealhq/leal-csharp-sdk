namespace Leal;

public partial interface IPostersClient
{
    /// <summary>
    /// Returns all posters for the store. Optionally filter by card or active status.
    /// </summary>
    WithRawResponseTask<IEnumerable<ListPostersResponseItem>> ListAsync(
        ListPostersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new printable QR code poster for customer signup. The poster will automatically
    /// generate a unique public signup URL and QR code. The `card_id` is required on create to
    /// associate the poster with a loyalty card.
    /// </summary>
    WithRawResponseTask<CreatePostersResponse> CreateAsync(
        CreatePostersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single poster by ID, including generated signup and display URLs.
    /// </summary>
    WithRawResponseTask<GetPostersResponse> GetAsync(
        GetPostersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently deletes a poster. The public signup URL will stop working.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        DeletePostersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing poster. The `card_id` cannot be changed after creation.
    /// </summary>
    WithRawResponseTask<UpdatePostersResponse> UpdateAsync(
        UpdatePostersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
