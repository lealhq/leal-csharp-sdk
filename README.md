# Leal C# Library

[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-Built%20with%20Fern-brightgreen)](https://buildwithfern.com?utm_source=github&utm_medium=github&utm_campaign=readme&utm_source=https%3A%2F%2Fgithub.com%2Flealhq%2Fleal-csharp-sdk)
[![nuget shield](https://img.shields.io/nuget/v/Leal)](https://nuget.org/packages/Leal)

Digital loyalty stamp cards in Apple Wallet and Google Wallet, for local
businesses. This library covers the whole [Leal](https://www.getleal.com)
API, so you can enrol customers, add stamps, redeem rewards and read a
card's wallet links from your own application.

- Guides and a page for every language: [www.getleal.com/developers](https://www.getleal.com/developers)
- Create an API token: [app.getleal.com/api_tokens](https://app.getleal.com/api_tokens)
- The OpenAPI description these libraries are built from: [www.getleal.com/openapi.json](https://www.getleal.com/openapi.json)


## Table of Contents

- [Documentation](#documentation)
- [Requirements](#requirements)
- [Installation](#installation)
- [Reference](#reference)
- [Usage](#usage)
- [Environments](#environments)
- [Exception Handling](#exception-handling)
- [Advanced](#advanced)
  - [Retries](#retries)
  - [Timeouts](#timeouts)
  - [Raw Response](#raw-response)
  - [Additional Headers](#additional-headers)
  - [Additional Query Parameters](#additional-query-parameters)
  - [Additional Body Properties](#additional-body-properties)
- [Contributing](#contributing)

## Documentation

API reference documentation is available [here](https://app.getleal.com/docs/api.html).

## Requirements

This SDK requires:
- .NET 8 and above
- .NET Framework 4.6.2 and above
- .NET Standard 2.0 and above

## Installation

```sh
dotnet add package Leal
```

## Reference

A full reference for this library is available [here](https://github.com/lealhq/leal-csharp-sdk/blob/HEAD/./reference.md).

## Usage

Instantiate and use the client with the following:

```csharp
using Leal;

var client = new LealClient("TOKEN");
await client.CustomerCards.StampAsync(
    new StampCustomerCardsRequest
    {
        AccountId = 1,
        CustomerId = 1,
        Id = 1,
        Stamps = 1,
    }
);
```

## Environments

This SDK allows you to configure different environments for API requests.

```csharp
using Leal;

var client = new LealClient(clientOptions: new ClientOptions
{
    BaseUrl = LealClientEnvironment.Production
});
```

## Exception Handling

When the API returns a non-success status code (4xx or 5xx response), a subclass of the following error
will be thrown.

```csharp
using Leal;

try {
    var response = await client.CustomerCards.StampAsync(...);
} catch (LealClientApiException e) {
    System.Console.WriteLine(e.Body);
    System.Console.WriteLine(e.StatusCode);

    // Access the raw HTTP response (status code, URL, headers) off the exception
    var rawResponse = e.RawResponse;
    if (rawResponse != null)
    {
        System.Console.WriteLine(rawResponse.Url);
        if (rawResponse.Headers.TryGetValue("X-Request-Id", out var requestId))
        {
            System.Console.WriteLine($"Request ID: {requestId}");
        }
    }
}
```

## Advanced

### Retries

The SDK is instrumented with automatic retries with exponential backoff. A request will be retried as long
as the request is deemed retryable and the number of retry attempts has not grown larger than the configured
retry limit (default: 2).

Which status codes are retried depends on the `retryStatusCodes` generator configuration:

**`legacy`** (current default): retries on
- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [5XX](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status#server_error_responses) (All server errors, including 500)

**`recommended`**: retries on
- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [502](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/502) (Bad Gateway)
- [503](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/503) (Service Unavailable)
- [504](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/504) (Gateway Timeout)

Use the `MaxRetries` request option to configure this behavior.

```csharp
var response = await client.CustomerCards.StampAsync(
    ...,
    new RequestOptions {
        MaxRetries = 0 // Override MaxRetries at the request level
    }
);
```

### Timeouts

The SDK defaults to a 30 second timeout. Use the `Timeout` option to configure this behavior.

```csharp
var response = await client.CustomerCards.StampAsync(
    ...,
    new RequestOptions {
        Timeout = TimeSpan.FromSeconds(3) // Override timeout to 3s
    }
);
```

### Raw Response

Access raw HTTP response data (status code, headers, URL) alongside parsed response data using the `.WithRawResponse()` method.

```csharp
using Leal;

// Access raw response data (status code, headers, etc.) alongside the parsed response
var result = await client.CustomerCards.StampAsync(...).WithRawResponse();

// Access the parsed data
var data = result.Data;

// Access raw response metadata
var statusCode = result.RawResponse.StatusCode;
var headers = result.RawResponse.Headers;
var url = result.RawResponse.Url;

// Access specific headers (case-insensitive)
if (headers.TryGetValue("X-Request-Id", out var requestId))
{
    System.Console.WriteLine($"Request ID: {requestId}");
}

// For the default behavior, simply await without .WithRawResponse()
var parsedData = await client.CustomerCards.StampAsync(...);

// .WithRawResponse() also works on streaming endpoints (returns IAsyncEnumerable<T> + RawResponse)
// and on endpoints with no response body (returns RawResponse only).
```

### Additional Headers

If you would like to send additional headers as part of the request, use the `AdditionalHeaders` request option.

```csharp
var response = await client.CustomerCards.StampAsync(
    ...,
    new RequestOptions {
        AdditionalHeaders = new Dictionary<string, string?>
        {
            { "X-Custom-Header", "custom-value" }
        }
    }
);
```

### Additional Query Parameters

If you would like to send additional query parameters as part of the request, use the `AdditionalQueryParameters` request option.

```csharp
var response = await client.CustomerCards.StampAsync(
    ...,
    new RequestOptions {
        AdditionalQueryParameters = new Dictionary<string, string>
        {
            { "custom_param", "custom-value" }
        }
    }
);
```

### Additional Body Properties

If you would like to send additional body properties as part of the request, use the `AdditionalBodyProperties` request option.
This is only applied to JSON requests.

```csharp
var response = await client.CustomerCards.StampAsync(
    ...,
    new RequestOptions {
        AdditionalBodyProperties = new Dictionary<string, object>
        {
            { "custom_field", "custom-value" }
        }
    }
);
```

## Contributing

While we value open-source contributions to this SDK, this library is generated programmatically.
Additions made directly to this library would have to be moved over to our generation code,
otherwise they would be overwritten upon the next generated release. Feel free to open a PR as
a proof of concept, but know that we will not be able to merge it as-is. We suggest opening
an issue first to discuss with us!

On the other hand, contributions to the README are always very welcome!
