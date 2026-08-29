using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record UpdatePostersResponse : IJsonOnDeserialized
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
    /// Whether the public signup URL is live
    /// </summary>
    [JsonPropertyName("active")]
    public required bool Active { get; set; }

    /// <summary>
    /// Loyalty card customers are signed up to
    /// </summary>
    [JsonPropertyName("card_id")]
    public required int CardId { get; set; }

    /// <summary>
    /// Whether the public signup form collects email
    /// </summary>
    [JsonPropertyName("collect_email")]
    public required bool CollectEmail { get; set; }

    /// <summary>
    /// Whether the public signup form collects phone number
    /// </summary>
    [JsonPropertyName("collect_phone")]
    public required bool CollectPhone { get; set; }

    /// <summary>
    /// Which contact fields appear on the public signup form: 'email_and_phone', 'email_only', or 'phone_only'
    /// </summary>
    [JsonPropertyName("contact_collection_mode")]
    public required string ContactCollectionMode { get; set; }

    /// <summary>
    /// ISO 8601 creation timestamp
    /// </summary>
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// URL of the on screen version of the poster
    /// </summary>
    [JsonPropertyName("display_url")]
    public required string DisplayUrl { get; set; }

    /// <summary>
    /// Unique poster ID
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Minimum customer age required for signup
    /// </summary>
    [JsonPropertyName("minimum_age")]
    public required double MinimumAge { get; set; }

    /// <summary>
    /// Paper size the poster is laid out for
    /// </summary>
    [JsonPropertyName("paper_size")]
    public required string PaperSize { get; set; }

    /// <summary>
    /// Hex colour for the poster background
    /// </summary>
    [JsonPropertyName("primary_color")]
    public required string PrimaryColor { get; set; }

    /// <summary>
    /// URL encoded in the QR code
    /// </summary>
    [JsonPropertyName("qr_code_url")]
    public required string QrCodeUrl { get; set; }

    /// <summary>
    /// Whether date of birth is required on the public signup form
    /// </summary>
    [JsonPropertyName("require_birthday")]
    public required bool RequireBirthday { get; set; }

    /// <summary>
    /// Whether email is required when it is collected
    /// </summary>
    [JsonPropertyName("require_email")]
    public required bool RequireEmail { get; set; }

    /// <summary>
    /// Whether phone number is required when it is collected
    /// </summary>
    [JsonPropertyName("require_phone")]
    public required bool RequirePhone { get; set; }

    /// <summary>
    /// Hex accent colour
    /// </summary>
    [JsonPropertyName("secondary_color")]
    public required string SecondaryColor { get; set; }

    /// <summary>
    /// Public URL the QR code points at
    /// </summary>
    [JsonPropertyName("signup_url")]
    public required string SignupUrl { get; set; }

    /// <summary>
    /// Hex colour for poster text
    /// </summary>
    [JsonPropertyName("text_color")]
    public required string TextColor { get; set; }

    /// <summary>
    /// Heading printed on the poster
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// ISO 8601 last-update timestamp
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

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
