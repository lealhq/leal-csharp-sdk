namespace Leal;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class LealClientException(string message, Exception? innerException = null)
    : Exception(message, innerException);
