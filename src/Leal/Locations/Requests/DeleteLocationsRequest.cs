using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record DeleteLocationsRequest
{
    /// <summary>
    /// Parent store ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    /// <summary>
    /// Location ID
    /// </summary>
    [JsonIgnore]
    public required int Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
