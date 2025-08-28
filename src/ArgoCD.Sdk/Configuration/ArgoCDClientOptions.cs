namespace ArgoCD.Sdk.Configuration;

/// <summary>
/// Represents the options used to configure an ArgoCD client.
/// </summary>
public sealed class ArgoCDClientOptions
{

    /// <summary>
    /// Gets or sets the ArgoCD server endpoint.
    /// </summary>
    public Uri Endpoint { get; set; } = null!;

    /// <summary>
    /// Gets or sets the API key used for authentication with the ArgoCD server. If not set, the client will use the specified <see cref="ApiKeyFactory"/> to obtain the API key.
    /// </summary>
    public string? ApiKey { get; set; }

    /// <summary>
    /// Gets or sets a factory function to obtain the API key used for authentication with the ArgoCD server. If not set, the client will use the value of the <see cref="ApiKey"/> property.
    /// </summary>
    public Func<IServiceProvider, CancellationToken, Task<string>>? ApiKeyFactory { get; set; }

    /// <summary>
    /// Gets a boolean indicating whether to validate the server's SSL certificate. Defaults to <c>true</c>.
    /// </summary>
    public bool ValidateServerCertificate { get; set; } = true;

    /// <summary>
    /// Gets or sets the list of hosts for which the API key should be sent. If not set, the API key will only be sent to the host specified in the <see cref="Endpoint"/> property.
    /// </summary>
    public List<string>? AllowedHosts { get; set; }

}
