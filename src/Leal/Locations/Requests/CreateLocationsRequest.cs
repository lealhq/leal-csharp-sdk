using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record CreateLocationsRequest
{
    /// <summary>
    /// Parent store ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    [JsonPropertyName("location")]
    public required CreateLocationsRequestLocation Location { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
