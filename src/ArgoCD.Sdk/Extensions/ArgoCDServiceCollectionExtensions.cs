using ArgoCD.Sdk.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace ArgoCD.Sdk;

/// <summary>
/// Defines extensions for <see cref="IServiceCollection"/>s.
/// </summary>
public static class ArgoCDServiceCollectionExtensions
{

    const string ClientName = "ArgoCD";

    /// <summary>
    /// Adds and configures an <see cref="ArgoCDClient"/>.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="setup">An <see cref="Action{T}"/> to configure the <see cref="ArgoCDClientOptions"/> used to setup the client.</param>
    /// <returns>The configured <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddArgoCDClient(this IServiceCollection services, Action<ArgoCDClientOptions> setup)
    {
        var options = new ArgoCDClientOptions();
        setup(options);
        if (options.Endpoint == null) throw new ArgumentException("The ArgoCD Endpoint must be set.", nameof(setup));
        services.AddHttpClient(ClientName, client =>
        {
            client.BaseAddress = options.Endpoint;
        });
        if (!options.ValidateServerCertificate) services.Configure<HttpClientFactoryOptions>(ClientName, factory =>
            {
                factory.HttpMessageHandlerBuilderActions.Add(builder =>
                {
                    builder.PrimaryHandler = new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };
                });
            });
        var allowedHosts = (options.AllowedHosts is { Count: > 0 }) ? options.AllowedHosts : [options.Endpoint.Host];
        services.AddSingleton<IAccessTokenProvider>(provider =>
        {
            return new DelegateAccessTokenProvider(cancellationToken => options.ApiKeyFactory?.Invoke(provider, cancellationToken) ?? Task.FromResult(options.ApiKey ?? throw new NullReferenceException("An API key or an API key factory must be provided to authenticate the ArgoCD client.")), allowedHosts);
        });
        services.AddSingleton<IAuthenticationProvider>(provider => 
        {
            return new BaseBearerTokenAuthenticationProvider(provider.GetRequiredService<IAccessTokenProvider>());
        });
        services.AddSingleton<IRequestAdapter>(provider =>
        {
            var authenticationProvider = provider.GetRequiredService<IAuthenticationProvider>();
            var httpClient = provider.GetRequiredService<IHttpClientFactory>().CreateClient(ClientName);
            var adapter = new HttpClientRequestAdapter(authenticationProvider, httpClient: httpClient)
            {
                BaseUrl = options.Endpoint.OriginalString
            };
            return adapter;
        });
        services.AddSingleton(provider => new ArgoCDClient(provider.GetRequiredService<IRequestAdapter>()));
        return services;
    }

}
