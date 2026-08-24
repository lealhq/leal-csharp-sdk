namespace Leal;

public partial interface ICustomerCardsClient
{
    /// <summary>
    /// Returns all loyalty cards enrolled for a specific customer, including stamp progress,
    /// status, wallet pass installation state, and wallet pass URLs (`apple_wallet_url` and
    /// `google_wallet_url`) that you can use to let customers add their loyalty card to
    /// Apple Wallet or Google Wallet from your own app or website.
    /// </summary>
    WithRawResponseTask<IEnumerable<ListCustomerCardsResponseItem>> ListAsync(
        ListCustomerCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns detailed information about a specific customer card, including stamp progress,
    /// a list of rewards the customer has earned enough stamps to redeem, and wallet pass URLs
    /// (`apple_wallet_url` and `google_wallet_url`) for adding the card to Apple Wallet or
    /// Google Wallet.
    /// </summary>
    WithRawResponseTask<GetCustomerCardsResponse> GetAsync(
        GetCustomerCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Redeems a reward for a customer, deducting the required stamps from their card.
    /// The customer must have enough stamps on this card to cover the reward's cost.
    /// Triggers wallet pass updates and push notifications.
    /// </summary>
    WithRawResponseTask<RedeemCustomerCardsResponse> RedeemAsync(
        RedeemCustomerCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds stamps to a customer's loyalty card. Triggers ledger entries, wallet pass updates,
    /// and push notifications. Pass `skip_notifications` to stamp silently.
    /// </summary>
    WithRawResponseTask<StampCustomerCardsResponse> StampAsync(
        StampCustomerCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
