using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record ListLocationsRequest
{
    /// <summary>
    /// Parent store ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
