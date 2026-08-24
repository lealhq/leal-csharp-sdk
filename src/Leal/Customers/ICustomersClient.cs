namespace Leal;

public partial interface ICustomersClient
{
    /// <summary>
    /// Returns a paginated list of customers for the store. Use the `search` parameter to filter
    /// by name, email, phone, card code (barcode), or external reference ID. Alternatively, pass
    /// `source` AND `external_id` together to perform an exact lookup by an external reference -
    /// the response will contain at most one customer.
    /// </summary>
    WithRawResponseTask<ListCustomersResponse> ListAsync(
        ListCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new customer for the store. Requires `first_name` and at least one of `email` or `phone`.
    /// Optionally enroll the customer in a loyalty card by passing `card_id`, and trigger delivery of
    /// card links (email/SMS) by passing `send_card_links`. When a card with initial stamps is assigned,
    /// those stamps are automatically applied as a welcome bonus.
    ///
    /// Pass `metadata` to attach arbitrary key/value data, and `external_references` to link the
    /// customer to records in other systems (e.g. Square, Shopify). External references are upserted
    /// by `(source, external_id)` so this endpoint is safe to call with the same references twice.
    /// </summary>
    WithRawResponseTask<CreateCustomersResponse> CreateAsync(
        CreateCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns detailed information about a single customer, including all of their
    /// enrolled loyalty cards with stamp progress and wallet pass URLs (`apple_wallet_url`
    /// and `google_wallet_url`) for each card. Also includes `metadata` and
    /// `external_references` so you can sync state with external systems.
    /// </summary>
    WithRawResponseTask<GetCustomersResponse> GetAsync(
        GetCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing customer's details. To add stamps or redeem rewards, use the
    /// customer cards endpoints instead.
    ///
    /// `metadata` is shallow-merged into the existing metadata. `external_references` are upserted
    /// by `(source, external_id)` - to remove a reference, omit it from subsequent calls and use
    /// a separate `DELETE` workflow (not yet exposed via API; manage in dashboard for now).
    /// </summary>
    WithRawResponseTask<UpdateCustomersResponse> UpdateAsync(
        UpdateCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
