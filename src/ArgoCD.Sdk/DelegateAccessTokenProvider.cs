using Microsoft.Kiota.Abstractions.Authentication;

namespace ArgoCD.Sdk;

internal sealed class DelegateAccessTokenProvider(Func<CancellationToken, Task<string>> tokenFactory, IEnumerable<string> allowedHosts)
    : IAccessTokenProvider
{

    readonly Func<CancellationToken, Task<string>> _tokenFactory = tokenFactory ?? throw new ArgumentNullException(nameof(tokenFactory));

    public AllowedHostsValidator AllowedHostsValidator { get; } = new AllowedHostsValidator(allowedHosts ?? throw new ArgumentNullException(nameof(allowedHosts)));

    public Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
    {
        if (!AllowedHostsValidator.IsUrlHostValid(uri)) return Task.FromResult(string.Empty);
        return _tokenFactory(cancellationToken);
    }

}