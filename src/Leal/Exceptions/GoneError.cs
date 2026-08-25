namespace Leal;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class GoneError(Error body, Leal.RawResponse? rawResponse = null)
    : LealClientApiException("GoneError", 410, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new Error Body => body;
}
