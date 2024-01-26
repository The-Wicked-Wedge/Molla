using Molla.Application.Extensions;
using Molla.Application.Interfaces.IPoviders;
using Polly;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.Retry;

namespace Molla.Infrastructure.SMSProvider
{
    public class SMSProvider : ISMSProvider
    {
        private readonly AsyncRetryPolicy<Result> _retryPolicy;
        private readonly AsyncFallbackPolicy<Result> _fallbackPolicy;
        private static AsyncCircuitBreakerPolicy _circuitBreakerPolicy;

        private readonly HttpClient _httpClient;

        private const string url = "https://";

        public SMSProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _circuitBreakerPolicy = Policy.Handle<Exception>()
                                    .CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));

            _retryPolicy = Policy<Result>.Handle<Exception>().RetryAsync(2);

            _fallbackPolicy = Policy<Result>.Handle<Exception>().FallbackAsync
                (Result.Failure("Error on Sending message"));
        }
        public async Task<Result> SendAsync(string receiver, string text)
        {
            var result = await _circuitBreakerPolicy.ExecuteAsync(async () =>
            {
                var content = new FormUrlEncodedContent(new[]
                            {
                new KeyValuePair<string, string>("receiver",receiver),
                new KeyValuePair<string, string>("text",text)
           });
                return await _httpClient.PostAsync(url, content);
            });
            if (result.IsSuccessStatusCode)
                return new();
            else return new("Error on Sending message");
        }
    }
}
