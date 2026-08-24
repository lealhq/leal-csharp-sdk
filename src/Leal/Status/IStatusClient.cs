namespace Leal;

public partial interface IStatusClient
{
    /// <summary>
    /// Returns the status of the API. No authentication required.
    ///
    /// Every response from this API, including this one, carries `RateLimit-Limit`,
    /// `RateLimit-Remaining`, `RateLimit-Reset` and `RateLimit-Policy`. Exceeding
    /// the limit returns 429 with `Retry-After` in seconds.
    /// </summary>
    WithRawResponseTask<CheckStatusResponse> CheckAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
