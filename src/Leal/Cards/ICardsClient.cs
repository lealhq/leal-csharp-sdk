namespace Leal;

public partial interface ICardsClient
{
    /// <summary>
    /// Returns loyalty card templates for the specified store. By default, only
    /// active (unarchived) cards are returned. Use the `scope` parameter to include
    /// archived cards.
    /// </summary>
    WithRawResponseTask<IEnumerable<ListCardsResponseItem>> ListAsync(
        ListCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new loyalty stamp card template for the store. The card defines the
    /// visual design (colours, icon, strip) and program rules (stamps required,
    /// initial stamps).
    /// </summary>
    WithRawResponseTask<CreateCardsResponse> CreateAsync(
        CreateCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single loyalty card template by ID, including reward and customer card counts.
    /// </summary>
    WithRawResponseTask<GetCardsResponse> GetAsync(
        GetCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing loyalty card template. Only the provided attributes are changed.
    /// </summary>
    WithRawResponseTask<UpdateCardsResponse> UpdateAsync(
        UpdateCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
