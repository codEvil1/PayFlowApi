# 💳 PayFlow API

> **Production-ready REST API for a Point of Sale (POS) system**, built with **ASP.NET Core (.NET 10)** and **Clean Architecture**. Designed to demonstrate enterprise-level backend development practices including authentication, cloud storage, Docker, CI/CD, and cloud deployment.

<p align="center">

![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-13-239120?logo=csharp&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?logo=docker&logoColor=white)
![Azure](https://img.shields.io/badge/Azure-0078D4?logo=microsoftazure&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?logo=microsoftsqlserver&logoColor=white)
![GitHub Actions](https://img.shields.io/badge/GitHub_Actions-2088FF?logo=github-actions&logoColor=white)
![Cloudflare R2](https://img.shields.io/badge/Cloudflare-R2-F38020?logo=cloudflare&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green)

</p>

---

# 📖 About

**PayFlow API** is a modern backend solution for **Point of Sale (POS)** systems developed with **ASP.NET Core (.NET 10)** following **Clean Architecture** principles.

The goal of this project is to demonstrate real-world backend development practices commonly found in enterprise applications, including:

- Authentication & Authorization
- RESTful API Design
- Layered Architecture
- Docker Containerization
- Cloud Storage
- CI/CD Pipelines
- Cloud Deployment
- Validation & Exception Handling
- Health Monitoring
- API Documentation

---

# ✨ Features

- 🔐 JWT Authentication
- 🔄 Refresh Token Authentication
- 👥 Role-Based Authorization
- 🏗️ Clean Architecture
- 📦 Repository Pattern
- 🗄️ Entity Framework Core
- 💾 SQL Server
- 🐳 Docker Support
- ☁️ Azure Container Apps Deployment
- 📂 Cloudflare R2 File Storage
- 📑 Swagger / OpenAPI
- ✅ FluentValidation
- ⚠️ Global Exception Middleware
- 📋 Standardized API Responses
- ❤️ Health Checks
- 📈 API Versioning
- 📝 Structured Logging (Serilog)
- 🚀 GitHub Actions CI/CD
- 🔒 Password Hashing (BCrypt)

---

# 🏛️ Architecture

The project follows **Clean Architecture** principles.

```text
src
│
├── PayFlow.Api
│
├── PayFlow.Application
│
├── PayFlow.Domain
│
└── PayFlow.Infrastructure
```

## Layers

### API

- Controllers
- Middlewares
- Swagger
- Dependency Injection
- Authentication

### Application

- Services
- DTOs
- Validators
- Interfaces

### Domain

- Entities
- Enums
- Business Rules

### Infrastructure

- Entity Framework Core
- SQL Server
- Repositories
- Authentication
- Cloudflare R2
- External Services

---

# 🛠️ Tech Stack

| Technology | Purpose |
|------------|---------|
| ASP.NET Core (.NET 10) | REST API |
| C# | Backend |
| Entity Framework Core | ORM |
| SQL Server | Database |
| Docker | Containerization |
| GitHub Actions | CI/CD |
| Azure Container Apps | Cloud Deployment |
| Cloudflare R2 | Object Storage |
| Swagger | API Documentation |
| FluentValidation | Validation |
| JWT | Authentication |
| BCrypt | Password Hashing |
| Serilog | Logging |

---

# 🔐 Authentication

Authentication is based on **JWT Bearer Tokens**.

Implemented features:

- Login
- JWT Access Token
- Refresh Token
- Secure Password Hashing
- Protected Endpoints

Example:

```http
Authorization: Bearer eyJhbGciOiJIUzI1NiIs...
```

---


# ☁️ Cloudflare R2 Storage

Instead of storing binary files inside SQL Server, images are uploaded to **Cloudflare R2**.

Only the public image URL is persisted in the database.

Benefits:

- Faster database
- Lower storage costs
- Better scalability
- CDN-ready assets

---

# ✅ Validation

Every incoming request is validated using **FluentValidation**.

Examples:

- Required Fields
- Email Format
- Password Rules
- CPF Validation
- Phone Validation
- Business Rules

---

# ⚠️ Exception Handling

A custom global middleware catches all unhandled exceptions and returns standardized responses.

Example:

```json
{
    "success": false,
    "message": "Validation failed.",
    "errors": [
        "Email is required."
    ]
}
```

---

# 📄 Standard API Response

All endpoints return a standardized response object.

Example:

```json
{
    "success": true,
    "message": "Product created successfully.",
    "data": {}
}
```

---

# ❤️ Health Checks

Health monitoring endpoints are available.

```text
GET /health
```

Used to verify:

- API Availability
- Database Connection
- Container Readiness

---

# 📑 Swagger

Interactive documentation is available at:

```text
/swagger
```

Features:

- JWT Authentication
- Endpoint Testing
- OpenAPI Documentation

---

# 🐳 Docker

## Build

```bash
docker build -t payflow-api .
```

## Run

```bash
docker run -d -p 8080:8080 payflow-api
```

---

# 🚀 CI/CD

The project includes a fully automated GitHub Actions pipeline.

Pipeline:

```text
Push
   │
   ▼
Restore Dependencies
   │
   ▼
Build
   │
   ▼
Run Tests
   │
   ▼
Publish
   │
   ▼
Docker Build
   │
   ▼
Push to GitHub Container Registry
   │
   ▼
Deploy to Azure Container Apps
```

---

# ☁️ Deployment

Current infrastructure:

- GitHub Actions
- GitHub Container Registry (GHCR)
- Azure Container Apps

---

# 📂 Project Structure

```text
PayFlow.Api
│
├── Controllers
├── Middlewares
├── Extensions
├── HealthChecks
└── Program.cs

PayFlow.Application
│
├── DTOs
├── Interfaces
├── Services
├── Validators
└── DependencyInjection

PayFlow.Domain
│
├── Entities
├── Enums
├── Interfaces
└── Exceptions

PayFlow.Infrastructure
│
├── Authentication
├── Cloudflare
├── Persistence
├── Repositories
├── Services
└── DependencyInjection
```

---

# 💻 Running Locally

Clone the repository

```bash
git clone https://github.com/codEvil1/PayFlowApi.git
```

Navigate to the project

```bash
cd PayFlowApi
```

Restore packages

```bash
dotnet restore
```

Apply migrations

```bash
dotnet ef database update
```

Run the application

```bash
dotnet run
```

---

# 🐳 Running with Docker

```bash
docker build -t payflow-api .
```

```bash
docker run -p 8080:8080 payflow-api
```

---

# 🎯 Roadmap

Planned features:

- [ ] Unit Tests
- [ ] Integration Tests
- [ ] Redis Cache
- [ ] Background Jobs (Hangfire)
- [ ] OpenTelemetry
- [ ] Prometheus Metrics
- [ ] RabbitMQ
- [ ] Rate Limiting
- [ ] Audit Logs
- [ ] Multi-Tenant Support
- [ ] PIX Integration
- [ ] NF-e Integration (SEFAZ)
- [ ] Melhor Envio Integration
- [ ] Email Notifications

---

# 🤝 Contributing

Contributions are welcome!

1. Fork the repository
2. Create a feature branch

```bash
git checkout -b feature/my-feature
```

3. Commit your changes

```bash
git commit -m "feat: add new feature"
```

4. Push

```bash
git push origin feature/my-feature
```

5. Open a Pull Request

---

# 📜 License

This project is licensed under the MIT License.

---

# 👨‍💻 Author

**Bruno Vinícius Paese**

Backend Developer | ASP.NET Core | C# | Cloud | Docker

GitHub:

**https://github.com/codEvil1**

---

⭐ If you found this project useful, consider giving it a **Star** on GitHub.
