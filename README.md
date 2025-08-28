# ArgoCD .NET SDK

A .NET SDK for interacting with the [ArgoCD](https://argo-cd.readthedocs.io/) API, making it easy to integrate GitOps workflows into your applications and services.

[![NuGet](https://img.shields.io/nuget/v/ArgoCD.Sdk.svg)](https://www.nuget.org/packages/ArgoCD.Sdk/) 
[![License](https://img.shields.io/github/license/neuroglia-io/argocd-sdk.svg)](./LICENSE)

---

## ✨ Features

- Strongly-typed client for the [ArgoCD REST API](https://argo-cd.readthedocs.io/en/latest/developer-guide/api-docs/)
- Easy authentication
- Generated using [Microsoft Kiota](https://github.com/microsoft/kiota) from the [ArgoCD](https://argo-cd.readthedocs.io/) [OpenAPI specification](https://www.openapis.org/) file
- Built for .NET 8.0+ (compatible with .NET 8/9)

---

## 📦 Installation

Install from [NuGet](https://www.nuget.org/packages/ArgoCD.Sdk):

```bash
dotnet add package ArgoCD.Sdk
```

## 🚀 Getting Started

```c#
...
builder.Services.AddArgoCDClient(options => 
{
  options.Endpoint = new("https://argocd.contoso.com");
  options.ApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9eyJpc3MiOiJhcmdvY2QiLC";
});
...
```

---

## 🤝 Contributing

Contributions are welcome!  
Please check out our [contribution guide](./CONTRIBUTING.md) for guidelines on how to get started.

---

## 📄 License

This project is licensed under the [Apache-2.0 License](./LICENSE).

---

## 🌐 Links

- [ArgoCD Documentation](https://argo-cd.readthedocs.io/)
- [NuGet Package](https://www.nuget.org/packages/ArgoCD.Sdk)
- [GitHub Issues](https://github.com/neuroglia-io/argocd-sdk/issues)
