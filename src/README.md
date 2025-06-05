# MyWeatherHub Aspire Solution

## Overview
This solution is a distributed .NET Aspire application that demonstrates modern cloud-native development with multiple services, including:

- **API Service**: Provides weather data and exposes a Swagger/OpenAPI endpoint for easy testing and integration.
- **MyWeatherHub Web App**: A Blazor-based interactive web frontend for weather information, consuming the API service.
- **Redis Cache**: Used for caching weather data to improve performance and reduce API calls.
- **PostgreSQL Database**: Stores persistent weather and user data, accessible by the API and web app.
- **PgAdmin**: Web-based administration for PostgreSQL (when running locally).
- **Aspire Dashboard**: Visualizes the health, dependencies, and endpoints of all services in the solution.

## Key Capabilities
- **Distributed Application Orchestration**: Uses .NET Aspire to define, run, and manage multiple interdependent services locally and in Azure.
- **Cloud-Ready Infrastructure**: Infrastructure-as-Code (Bicep) templates for provisioning Azure resources (App Service, PostgreSQL, Redis, etc.).
- **API Documentation**: Built-in Swagger UI for the API service.
- **Local and Cloud Development**: Easily switch between local containers and Azure-managed services.
- **Observability**: Integrated logging and health checks via the Aspire dashboard and Azure Log Analytics.
- **Extensible**: Modular project structure for adding new services or integrations.

## Getting Started
1. Clone the repository.
2. Use `dotnet run --project AppHost` for local development (with containers).
3. Use `azd up` to provision and deploy to Azure (requires Azure CLI and azd).
4. Access the Aspire dashboard and Swagger UI via the provided endpoints.

## Project Structure
- `AppHost/` - Orchestrates all services and dependencies.
- `Api/` - Weather API service.
- `MyWeatherHub/` - Blazor web frontend.
- `ServiceDefaults/` - Shared service configuration and extensions.
- `infra/` - Bicep templates for Azure infrastructure.
- `IntegrationTests/` - Automated tests for environment and service integration.

---

## References
- [Aspire PostgreSQL Integration](https://learn.microsoft.com/en-us/dotnet/aspire/database/postgresql-integration?tabs=dotnet-cli)
- [Azure Container Apps Deployment with azd](https://learn.microsoft.com/en-us/dotnet/aspire/deployment/azure/aca-deployment-azd-in-depth?tabs=windows)

For more details, see the code and comments in each project folder.
