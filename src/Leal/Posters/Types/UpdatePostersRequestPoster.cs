using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record UpdatePostersRequestPoster : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether the poster is active
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// Which contact fields appear on the public signup form
    /// </summary>
    [JsonPropertyName("contact_collection_mode")]
    public string? ContactCollectionMode { get; set; }

    /// <summary>
    /// Minimum customer age required for signup. Requires require_birthday to be true.
    /// </summary>
    [JsonPropertyName("minimum_age")]
    public double? MinimumAge { get; set; }

    /// <summary>
    /// Print size – one of: a4, a5, a6, letter
    /// </summary>
    [JsonPropertyName("paper_size")]
    public string? PaperSize { get; set; }

    /// <summary>
    /// Primary brand color as a hex string
    /// </summary>
    [JsonPropertyName("primary_color")]
    public string? PrimaryColor { get; set; }

    /// <summary>
    /// Whether date of birth is required on the public signup form
    /// </summary>
    [JsonPropertyName("require_birthday")]
    public bool? RequireBirthday { get; set; }

    /// <summary>
    /// Whether email is required when it is collected
    /// </summary>
    [JsonPropertyName("require_email")]
    public bool? RequireEmail { get; set; }

    /// <summary>
    /// Whether phone number is required when it is collected
    /// </summary>
    [JsonPropertyName("require_phone")]
    public bool? RequirePhone { get; set; }

    /// <summary>
    /// Secondary brand color as a hex string
    /// </summary>
    [JsonPropertyName("secondary_color")]
    public string? SecondaryColor { get; set; }

    /// <summary>
    /// Text color as a hex string
    /// </summary>
    [JsonPropertyName("text_color")]
    public string? TextColor { get; set; }

    /// <summary>
    /// Headline text displayed on the poster
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

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
