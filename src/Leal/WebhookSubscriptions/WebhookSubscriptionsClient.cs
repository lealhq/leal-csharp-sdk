using global::System.Text.Json;
using Leal.Core;

namespace Leal;

public partial class WebhookSubscriptionsClient : IWebhookSubscriptionsClient
{
    private readonly RawClient _client;

    internal WebhookSubscriptionsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<IEnumerable<GetApiV1AccountsAccountIdWebhookSubscriptionsResponseItem>>
    > GetApiV1AccountsAccountIdWebhookSubscriptionsAsyncCore(
        GetApiV1AccountsAccountIdWebhookSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Leal.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("event", request.Event)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Leal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "api/v1/accounts/{0}/webhook_subscriptions",
                        ValueConvert.ToPathParameterString(request.AccountId)
                    ),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<
                    IEnumerable<GetApiV1AccountsAccountIdWebhookSubscriptionsResponseItem>
                >(responseBody)!;
                return new WithRawResponse<
                    IEnumerable<GetApiV1AccountsAccountIdWebhookSubscriptionsResponseItem>
                >()
                {
                    Data = responseData,
                    RawResponse = new Leal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new LealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Leal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 404:
                        throw new NotFoundError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 410:
                        throw new GoneError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 429:
                        throw new TooManyRequestsError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new LealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Leal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<
        WithRawResponse<PostApiV1AccountsAccountIdWebhookSubscriptionsResponse>
    > PostApiV1AccountsAccountIdWebhookSubscriptionsAsyncCore(
        PostApiV1AccountsAccountIdWebhookSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Leal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Leal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "api/v1/accounts/{0}/webhook_subscriptions",
                        ValueConvert.ToPathParameterString(request.AccountId)
                    ),
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData =
                    JsonUtils.Deserialize<PostApiV1AccountsAccountIdWebhookSubscriptionsResponse>(
                        responseBody
                    )!;
                return new WithRawResponse<PostApiV1AccountsAccountIdWebhookSubscriptionsResponse>()
                {
                    Data = responseData,
                    RawResponse = new Leal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new LealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Leal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 404:
                        throw new NotFoundError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 410:
                        throw new GoneError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 422:
                        throw new UnprocessableEntityError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 429:
                        throw new TooManyRequestsError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new LealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Leal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<
        WithRawResponse<GetApiV1AccountsAccountIdWebhookSubscriptionsIdResponse>
    > GetApiV1AccountsAccountIdWebhookSubscriptionsIdAsyncCore(
        GetApiV1AccountsAccountIdWebhookSubscriptionsIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Leal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Leal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "api/v1/accounts/{0}/webhook_subscriptions/{1}",
                        ValueConvert.ToPathParameterString(request.AccountId),
                        ValueConvert.ToPathParameterString(request.Id)
                    ),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData =
                    JsonUtils.Deserialize<GetApiV1AccountsAccountIdWebhookSubscriptionsIdResponse>(
                        responseBody
                    )!;
                return new WithRawResponse<GetApiV1AccountsAccountIdWebhookSubscriptionsIdResponse>()
                {
                    Data = responseData,
                    RawResponse = new Leal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new LealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Leal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 404:
                        throw new NotFoundError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 410:
                        throw new GoneError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 429:
                        throw new TooManyRequestsError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new LealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Leal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<RawResponse> DeleteApiV1AccountsAccountIdWebhookSubscriptionsIdAsyncCore(
        DeleteApiV1AccountsAccountIdWebhookSubscriptionsIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Leal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Leal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "api/v1/accounts/{0}/webhook_subscriptions/{1}",
                        ValueConvert.ToPathParameterString(request.AccountId),
                        ValueConvert.ToPathParameterString(request.Id)
                    ),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return new Leal.RawResponse()
            {
                StatusCode = response.Raw.StatusCode,
                Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
            };
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 404:
                        throw new NotFoundError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 410:
                        throw new GoneError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 429:
                        throw new TooManyRequestsError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new LealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Leal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<
        WithRawResponse<PatchApiV1AccountsAccountIdWebhookSubscriptionsIdResponse>
    > PatchApiV1AccountsAccountIdWebhookSubscriptionsIdAsyncCore(
        PatchApiV1AccountsAccountIdWebhookSubscriptionsIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Leal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Leal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethodExtensions.Patch,
                    Path = string.Format(
                        "api/v1/accounts/{0}/webhook_subscriptions/{1}",
                        ValueConvert.ToPathParameterString(request.AccountId),
                        ValueConvert.ToPathParameterString(request.Id)
                    ),
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData =
                    JsonUtils.Deserialize<PatchApiV1AccountsAccountIdWebhookSubscriptionsIdResponse>(
                        responseBody
                    )!;
                return new WithRawResponse<PatchApiV1AccountsAccountIdWebhookSubscriptionsIdResponse>()
                {
                    Data = responseData,
                    RawResponse = new Leal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new LealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Leal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 404:
                        throw new NotFoundError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 410:
                        throw new GoneError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 422:
                        throw new UnprocessableEntityError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 429:
                        throw new TooManyRequestsError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new LealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Leal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<
        WithRawResponse<PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretResponse>
    > PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretAsyncCore(
        PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Leal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Leal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "api/v1/accounts/{0}/webhook_subscriptions/{1}/rotate_secret",
                        ValueConvert.ToPathParameterString(request.AccountId),
                        ValueConvert.ToPathParameterString(request.Id)
                    ),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData =
                    JsonUtils.Deserialize<PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretResponse>(
                        responseBody
                    )!;
                return new WithRawResponse<PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretResponse>()
                {
                    Data = responseData,
                    RawResponse = new Leal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new LealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Leal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 404:
                        throw new NotFoundError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 410:
                        throw new GoneError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 429:
                        throw new TooManyRequestsError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new LealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Leal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<
        WithRawResponse<PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestResponse>
    > PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestAsyncCore(
        PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Leal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Leal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "api/v1/accounts/{0}/webhook_subscriptions/{1}/test",
                        ValueConvert.ToPathParameterString(request.AccountId),
                        ValueConvert.ToPathParameterString(request.Id)
                    ),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData =
                    JsonUtils.Deserialize<PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestResponse>(
                        responseBody
                    )!;
                return new WithRawResponse<PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestResponse>()
                {
                    Data = responseData,
                    RawResponse = new Leal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new LealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Leal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 401:
                        throw new UnauthorizedError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 404:
                        throw new NotFoundError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 410:
                        throw new GoneError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                    case 429:
                        throw new TooManyRequestsError(
                            JsonUtils.Deserialize<Error>(responseBody),
                            rawResponse: new Leal.RawResponse()
                            {
                                StatusCode = response.Raw.StatusCode,
                                Url =
                                    response.Raw.RequestMessage?.RequestUri
                                    ?? new Uri("about:blank"),
                                Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                            }
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new LealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Leal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    /// <summary>
    /// Returns every webhook subscription for the store, oldest first. Signing secrets are not included; fetch a single subscription to read its secret.
    /// </summary>
    /// <example><code>
    /// await client.WebhookSubscriptions.GetApiV1AccountsAccountIdWebhookSubscriptionsAsync(
    ///     new GetApiV1AccountsAccountIdWebhookSubscriptionsRequest { AccountId = 1 }
    /// );
    /// </code></example>
    public WithRawResponseTask<
        IEnumerable<GetApiV1AccountsAccountIdWebhookSubscriptionsResponseItem>
    > GetApiV1AccountsAccountIdWebhookSubscriptionsAsync(
        GetApiV1AccountsAccountIdWebhookSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<
            IEnumerable<GetApiV1AccountsAccountIdWebhookSubscriptionsResponseItem>
        >(
            GetApiV1AccountsAccountIdWebhookSubscriptionsAsyncCore(
                request,
                options,
                cancellationToken
            )
        );
    }

    /// <summary>
    /// Subscribes a URL to one or more events. The response includes the signing `secret`; store it to
    /// verify deliveries. The URL must be publicly reachable over https.
    ///
    /// Events: `customer.created`, `customer.updated`, `customer_card.created`, `stamp.earned`, `stamp.removed`, `reward.unlocked`, `reward.redeemed`, or `*` for all of them.
    /// </summary>
    /// <example><code>
    /// await client.WebhookSubscriptions.PostApiV1AccountsAccountIdWebhookSubscriptionsAsync(
    ///     new PostApiV1AccountsAccountIdWebhookSubscriptionsRequest
    ///     {
    ///         AccountId = 1,
    ///         TargetUrl = "target_url",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PostApiV1AccountsAccountIdWebhookSubscriptionsResponse> PostApiV1AccountsAccountIdWebhookSubscriptionsAsync(
        PostApiV1AccountsAccountIdWebhookSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PostApiV1AccountsAccountIdWebhookSubscriptionsResponse>(
            PostApiV1AccountsAccountIdWebhookSubscriptionsAsyncCore(
                request,
                options,
                cancellationToken
            )
        );
    }

    /// <summary>
    /// Returns a single subscription, including its signing secret and the result of the most recent delivery.
    /// </summary>
    /// <example><code>
    /// await client.WebhookSubscriptions.GetApiV1AccountsAccountIdWebhookSubscriptionsIdAsync(
    ///     new GetApiV1AccountsAccountIdWebhookSubscriptionsIdRequest { AccountId = 1, Id = 1 }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetApiV1AccountsAccountIdWebhookSubscriptionsIdResponse> GetApiV1AccountsAccountIdWebhookSubscriptionsIdAsync(
        GetApiV1AccountsAccountIdWebhookSubscriptionsIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetApiV1AccountsAccountIdWebhookSubscriptionsIdResponse>(
            GetApiV1AccountsAccountIdWebhookSubscriptionsIdAsyncCore(
                request,
                options,
                cancellationToken
            )
        );
    }

    /// <summary>
    /// Stops deliveries and deletes the subscription. This cannot be undone.
    /// </summary>
    /// <example><code>
    /// await client.WebhookSubscriptions.DeleteApiV1AccountsAccountIdWebhookSubscriptionsIdAsync(
    ///     new DeleteApiV1AccountsAccountIdWebhookSubscriptionsIdRequest { AccountId = 1, Id = 1 }
    /// );
    /// </code></example>
    public WithRawResponseTask DeleteApiV1AccountsAccountIdWebhookSubscriptionsIdAsync(
        DeleteApiV1AccountsAccountIdWebhookSubscriptionsIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask(
            DeleteApiV1AccountsAccountIdWebhookSubscriptionsIdAsyncCore(
                request,
                options,
                cancellationToken
            )
        );
    }

    /// <summary>
    /// Changes the URL, events, label or payload format, or turns the subscription off and on. Re-enabling a subscription that was disabled for failing clears its failure state.
    /// </summary>
    /// <example><code>
    /// await client.WebhookSubscriptions.PatchApiV1AccountsAccountIdWebhookSubscriptionsIdAsync(
    ///     new PatchApiV1AccountsAccountIdWebhookSubscriptionsIdRequest { AccountId = 1, Id = 1 }
    /// );
    /// </code></example>
    public WithRawResponseTask<PatchApiV1AccountsAccountIdWebhookSubscriptionsIdResponse> PatchApiV1AccountsAccountIdWebhookSubscriptionsIdAsync(
        PatchApiV1AccountsAccountIdWebhookSubscriptionsIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PatchApiV1AccountsAccountIdWebhookSubscriptionsIdResponse>(
            PatchApiV1AccountsAccountIdWebhookSubscriptionsIdAsyncCore(
                request,
                options,
                cancellationToken
            )
        );
    }

    /// <summary>
    /// Replaces the subscription's signing secret. Deliveries are signed with the new secret straight away, so update your receiver at the same time.
    /// </summary>
    /// <example><code>
    /// await client.WebhookSubscriptions.PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretAsync(
    ///     new PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretRequest
    ///     {
    ///         AccountId = 1,
    ///         Id = 1,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretResponse> PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretAsync(
        PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretResponse>(
            PostApiV1AccountsAccountIdWebhookSubscriptionsIdRotateSecretAsyncCore(
                request,
                options,
                cancellationToken
            )
        );
    }

    /// <summary>
    /// Immediately sends a signed `webhook.test` event to the subscription's URL and reports what
    /// happened, so you can check your endpoint and signature verification without waiting for real
    /// activity. Test events are not retried and do not count towards disabling the subscription.
    /// </summary>
    /// <example><code>
    /// await client.WebhookSubscriptions.PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestAsync(
    ///     new PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestRequest { AccountId = 1, Id = 1 }
    /// );
    /// </code></example>
    public WithRawResponseTask<PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestResponse> PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestAsync(
        PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestResponse>(
            PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestAsyncCore(
                request,
                options,
                cancellationToken
            )
        );
    }
}
