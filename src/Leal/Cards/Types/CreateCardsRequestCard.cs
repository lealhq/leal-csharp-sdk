using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record CreateCardsRequestCard : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Up to two extra front-of-pass fields. Blank values are ignored.
    /// </summary>
    [JsonPropertyName("auxiliary_fields")]
    public IEnumerable<string>? AuxiliaryFields { get; set; }

    /// <summary>
    /// Hex colour for the card background (e.g. '#6B4226')
    /// </summary>
    [JsonPropertyName("card_color")]
    public string? CardColor { get; set; }

    /// <summary>
    /// Card expiry timestamp (ISO 8601)
    /// </summary>
    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; set; }

    /// <summary>
    /// Optional header text displayed on the card
    /// </summary>
    [JsonPropertyName("header_text")]
    public string? HeaderText { get; set; }

    /// <summary>
    /// Number of stamps pre-filled on new customer cards (must be &gt;= 0 and &lt; stamps_required)
    /// </summary>
    [JsonPropertyName("initial_stamps")]
    public int? InitialStamps { get; set; }

    /// <summary>
    /// Card name (e.g. 'Coffee Loyalty Card')
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Whether wallet passes show the member name field
    /// </summary>
    [JsonPropertyName("show_member_field")]
    public bool? ShowMemberField { get; set; }

    /// <summary>
    /// Whether wallet passes show the stamps-to-reward field
    /// </summary>
    [JsonPropertyName("show_stamps_to_reward_field")]
    public bool? ShowStampsToRewardField { get; set; }

    /// <summary>
    /// Hex colour for stamp backgrounds
    /// </summary>
    [JsonPropertyName("stamp_background_color")]
    public string? StampBackgroundColor { get; set; }

    /// <summary>
    /// Hex colour for stamp icons
    /// </summary>
    [JsonPropertyName("stamp_color")]
    public string? StampColor { get; set; }

    /// <summary>
    /// Stamp icon identifier
    /// </summary>
    [JsonPropertyName("stamp_icon")]
    public string? StampIcon { get; set; }

    /// <summary>
    /// Number of stamps needed to complete the card (1–21)
    /// </summary>
    [JsonPropertyName("stamps_required")]
    public int? StampsRequired { get; set; }

    /// <summary>
    /// Hex colour for the strip (used when strip_type is 'color')
    /// </summary>
    [JsonPropertyName("strip_color")]
    public string? StripColor { get; set; }

    /// <summary>
    /// Preset strip image identifier (used when strip_type is 'preset')
    /// </summary>
    [JsonPropertyName("strip_preset")]
    public string? StripPreset { get; set; }

    /// <summary>
    /// Strip image type
    /// </summary>
    [JsonPropertyName("strip_type")]
    public string? StripType { get; set; }

    /// <summary>
    /// Hex colour for card text
    /// </summary>
    [JsonPropertyName("text_color")]
    public string? TextColor { get; set; }

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
