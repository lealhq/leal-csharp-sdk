namespace Leal;

public partial interface IRewardsClient
{
    /// <summary>
    /// Returns all rewards for the store. Optionally filter by card or active status.
    /// </summary>
    WithRawResponseTask<IEnumerable<ListRewardsResponseItem>> ListAsync(
        ListRewardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new reward for a loyalty card. The card must belong to the same store.
    /// The `card_id` is required on create but cannot be changed afterwards.
    /// </summary>
    WithRawResponseTask<CreateRewardsResponse> CreateAsync(
        CreateRewardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single reward by ID.
    /// </summary>
    WithRawResponseTask<GetRewardsResponse> GetAsync(
        GetRewardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently deletes a reward. This cannot be undone.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        DeleteRewardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing reward. The `card_id` cannot be changed after creation.
    /// </summary>
    WithRawResponseTask<UpdateRewardsResponse> UpdateAsync(
        UpdateRewardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
