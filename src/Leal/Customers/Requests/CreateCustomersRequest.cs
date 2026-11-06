using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record CreateCustomersRequest
{
    /// <summary>
    /// Store (account) ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    /// <summary>
    /// Loyalty card ID to auto-enroll the customer in
    /// </summary>
    [JsonPropertyName("card_id")]
    public int? CardId { get; set; }

    [JsonPropertyName("customer")]
    public required CreateCustomersRequestCustomer Customer { get; set; }

    /// <summary>
    /// Records the new customer as invited by another customer: the code is the last part of that customer's `referral_url`. Needs `card_id`, for the same card, with referrals on. Nothing is given now; both customers get their stamps when the new customer's card is first stamped for a visit
    /// </summary>
    [JsonPropertyName("referral_code")]
    public string? ReferralCode { get; set; }

    /// <summary>
    /// When true, sends the card links to the customer via email/SMS after enrollment. Note: even without this flag, the response includes `apple_wallet_url` and `google_wallet_url` in each customer card object so you can deliver them yourself.
    /// </summary>
    [JsonPropertyName("send_card_links")]
    public bool? SendCardLinks { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
