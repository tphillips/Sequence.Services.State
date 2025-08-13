# RESTful State API

A RESTful ASP.NET Core Web API service for state management, providing persistent storage capabilities using Redis as the backing store.

## Overview

The Sequence State Service is a microservice designed to handle state persistence and retrieval operations. It provides a simple API for storing and retrieving state objects with versioning support.

Data is stored under a Guid and retrieved under the same.

The body field of the state object would be most useful as a JSON object. But you do you.

## Features

- RESTful API for state management
- Redis-based persistence
- State versioning
- Swagger/OpenAPI documentation
- Docker containerization

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **Database**: Redis (using NRedisStack)
- **Documentation**: Swagger/OpenAPI
- **Containerization**: Docker & Docker Compose

## Project Structure

```
├── BLL/                    # Business Logic Layer
│   └── StateBLL.cs        # Core business logic for state operations
├── Controllers/           # API Controllers
│   ├── ApiController.cs   # Base API controller
│   └── StateController.cs # State management endpoints
├── Entities/              # Data models
│   └── State.cs          # State entity definition
├── compose.yaml          # Docker Compose configuration
├── Dockerfile           # Container definition
├── Program.cs           # Application entry point
├── Startup.cs           # Service configuration
```

## API Endpoints

### State Management

- `POST /State` - Create or update a state object
- `GET /State/{id}` - Retrieve a state object by ID

### State Entity

```json
{
  "id": "guid",
  "version": 1,
  "body": "string"
}
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Docker and Docker Compose (for containerized deployment)
- Redis (if running locally without Docker)

### Running with Docker Compose (Recommended)

1. Clone the repository
2. Navigate to the project directory
3. Run the application:

```bash
docker-compose up -d
```

The service will be available at:
- API: http://localhost:8079
- Swagger UI: http://localhost:8079/swagger

### Running Locally

1. Start Redis server locally or update connection string in `appsettings.json`
2. Build and run the application:

```bash
dotnet build
dotnet run
```

The service will be available at:
- HTTPS: https://localhost:5001
- HTTP: http://localhost:5000
- Swagger UI: https://localhost:5001/swagger

### Development

For development with hot reload:

```bash
dotnet watch run
```

## Configuration

### Environment Variables

- `ASPNETCORE_ENVIRONMENT` - Environment (Development/Production)
- `ApiPrefix` - API prefix for routing
- `RedisServer` - Redis server connection string
- `RedisPassword` - Redis authentication password

### Redis Configuration

The service uses Redis for state persistence. Default configuration:
- Host: localhost:6379 (development) / redis:6379 (Docker)
- Password: Configured via environment variables

## Docker

### Building the Image

```bash
docker build -t sequence-state-service .
```

### Running with Docker

```bash
docker run -p 8079:80 \
  -e RedisServer=your-redis-host:6379 \
  -e RedisPassword=your-redis-password \
  sequence-state-service
```

## API Documentation

When running the application, comprehensive API documentation is available via Swagger UI at `/swagger` endpoint.

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details.

