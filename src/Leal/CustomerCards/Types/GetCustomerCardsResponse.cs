using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record GetCustomerCardsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Parent store ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public required int AccountId { get; set; }

    /// <summary>
    /// Link to add or view the pass in Apple Wallet
    /// </summary>
    [JsonPropertyName("apple_wallet_url")]
    public required string AppleWalletUrl { get; set; }

    /// <summary>
    /// Rewards this customer can redeem right now
    /// </summary>
    [JsonPropertyName("available_rewards")]
    public IEnumerable<string> AvailableRewards { get; set; } = new List<string>();

    /// <summary>
    /// Loyalty card template ID
    /// </summary>
    [JsonPropertyName("card_id")]
    public required int CardId { get; set; }

    /// <summary>
    /// Name of the loyalty card
    /// </summary>
    [JsonPropertyName("card_name")]
    public required string CardName { get; set; }

    /// <summary>
    /// ISO 8601 creation timestamp
    /// </summary>
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// Owning customer ID
    /// </summary>
    [JsonPropertyName("customer_id")]
    public required int CustomerId { get; set; }

    /// <summary>
    /// Link to add or view the pass in Google Wallet
    /// </summary>
    [JsonPropertyName("google_wallet_url")]
    public required string GoogleWalletUrl { get; set; }

    /// <summary>
    /// Customer card ID
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// ISO 8601 timestamp the card was issued
    /// </summary>
    [JsonPropertyName("issued_at")]
    public required string IssuedAt { get; set; }

    /// <summary>
    /// Whether the wallet pass has been installed
    /// </summary>
    [JsonPropertyName("pass_installed")]
    public required bool PassInstalled { get; set; }

    /// <summary>
    /// Completion towards the next reward, 0 to 100
    /// </summary>
    [JsonPropertyName("progress_percentage")]
    public required double ProgressPercentage { get; set; }

    /// <summary>
    /// Stamps collected so far
    /// </summary>
    [JsonPropertyName("stamps_count")]
    public required int StampsCount { get; set; }

    /// <summary>
    /// Stamps still needed to complete the card
    /// </summary>
    [JsonPropertyName("stamps_remaining")]
    public required int StampsRemaining { get; set; }

    /// <summary>
    /// Current state of the customer card
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    /// <summary>
    /// ISO 8601 last-update timestamp
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

    /// <summary>
    /// Public identifier used in wallet pass URLs
    /// </summary>
    [JsonPropertyName("uuid")]
    public required string Uuid { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
