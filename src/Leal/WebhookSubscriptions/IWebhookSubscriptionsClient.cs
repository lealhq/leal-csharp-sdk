namespace Leal;

public partial interface IWebhookSubscriptionsClient
{
    /// <summary>
    /// Returns every webhook subscription for the store, oldest first. Signing secrets are not included; fetch a single subscription to read its secret.
    /// </summary>
    WithRawResponseTask<
        IEnumerable<GetApiV1AccountsAccountIdWebhookSubscriptionsResponseItem>
    > GetApiV1AccountsAccountIdWebhookSubscriptionsAsync(
        GetApiV1AccountsAccountIdWebhookSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Subscribes a URL to one or more events. The response includes the signing `secret`; store it to
    /// verify deliveries. The URL must be publicly reachable over https.
    ///
    /// Events: `customer.created`, `customer.updated`, `customer_card.created`, `stamp.earned`, `stamp.removed`, `reward.unlocked`, `reward.redeemed`, `referral.created`, `referral.rewarded`, or `*` for all of them.
    /// </summary>
    WithRawResponseTask<PostApiV1AccountsAccountIdWebhookSubscriptionsResponse> PostApiV1AccountsAccountIdWebhookSubscriptionsAsync(
        PostApiV1AccountsAccountIdWebhookSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single subscription, including its signing secret and the result of the most recent delivery.
    /// </summary>
    WithRawResponseTask<GetApiV1AccountsAccountIdWebhookSubscriptionsIdResponse> GetApiV1AccountsAccountIdWebhookSubscriptionsIdAsync(
        GetApiV1AccountsAccountIdWebhookSubscriptionsIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stops deliveries and deletes the subscription. This cannot be undone.
    /// </summary>
    WithRawResponseTask DeleteApiV1AccountsAccountIdWebhookSubscriptionsIdAsync(
        DeleteApiV1AccountsAccountIdWebhookSubscriptionsIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Changes the URL, events, label or payload format, or turns the subscription off and on. Re-enabling a subscription that was disabled for failing clears its failure state.
    /// </summary>
    WithRawResponseTask<PatchApiV1AccountsAccountIdWebhookSubscriptionsIdResponse> PatchApiV1AccountsAccountIdWebhookSubscriptionsIdAsync(
        PatchApiV1AccountsAccountIdWebhookSubscriptionsIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replaces the subscription's signing secret. Deliveries are signed with the new secret straight away, so update your receiver at the same time.
    /// </summary>
    WithRawResponseTask<PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretResponse> PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretAsync(
        PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Immediately sends a signed `webhook.test` event to the subscription's URL and reports what
    /// happened, so you can check your endpoint and signature verification without waiting for real
    /// activity. Test events are not retried and do not count towards disabling the subscription.
    /// </summary>
    WithRawResponseTask<PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestResponse> PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestAsync(
        PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
