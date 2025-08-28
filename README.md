# ArgoCD .NET SDK

A .NET SDK for interacting with the [ArgoCD](https://argo-cd.readthedocs.io/) API, making it easy to integrate GitOps workflows into your applications and services.

[![NuGet](https://img.shields.io/nuget/v/ArgoCD.Sdk.svg)](https://www.nuget.org/packages/ArgoCD.Sdk/) 
[![License](https://img.shields.io/github/license/neuroglia-io/argocd-sdk.svg)](./LICENSE)

---

## ✨ Features

- Strongly-typed client for the ArgoCD REST API
- Easy authentication (JWT, session tokens, gRPC/web)
- Models aligned with ArgoCD API schemas
- High-level abstractions for common GitOps operations:
  - Managing applications
  - Syncing and rolling back
  - Accessing projects, clusters, and repositories
- Built for .NET 6.0+ (compatible with .NET 7/8)

---

## 📦 Installation

Install from [NuGet](https://www.nuget.org/packages/ArgoCD.Sdk):

```bash
dotnet add package ArgoCD.Sdk
```

## 🚀 Getting Started

```c#
using ArgoCD.Sdk;
using ArgoCD.Sdk.Models;

// Create client
var client = new ArgoCDClient("https://argocd.example.com", new ArgoCDOptions
{
    Token = "your-jwt-token"
});

// List applications
var apps = await client.Applications.ListAsync();
foreach (var app in apps)
{
    Console.WriteLine($"App: {app.Metadata.Name}, Status: {app.Status.Health.Status}");
}
```

## ⚡ Roadmap

- [ ] Support gRPC endpoints
- [ ] Integration with Kubernetes SDK
- [ ] Advanced queries & filters
- [ ] Example ASP.NET Core middleware for GitOps automation

---

## 🤝 Contributing

Contributions are welcome!  
Please check out our [contribution guide](./CONTRIBUTING.md) for guidelines on how to get started.

---

## 📄 License

This project is licensed under the [MIT License](./LICENSE).

---

## 🌐 Links

- [ArgoCD Documentation](https://argo-cd.readthedocs.io/)
- [NuGet Package](https://www.nuget.org/packages/ArgoCD.Sdk)
- [GitHub Issues](https://github.com/neuroglia-io/argocd-sdk/issues)
