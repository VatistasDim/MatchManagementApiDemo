# Match Management API

## Overview:
The Match Management API is a web application developed using ASP.NET Core. It provides a set of endpoints to manage information related to matches and their corresponding odds.

## Key Features:

### 1. Matches Management:
- Retrieve a list of matches.
- Retrieve details of a specific match by ID.
- Add a new match to the system.
- Update the details of an existing match.
- Delete a match based on its ID.

### 2. Match Odds Management::
- Retrieve a list of match odds.
- Retrieve details of specific match odds by ID.
- Add new match odds to the system.
- Update the details of existing match odds.
- Delete match odds based on their ID.

## Technologies Used:

- ASP.NET Core: The core framework for building the web application.
- Entity Framework Core: Used for interacting with the database to perform CRUD operations.
- Swagger: Integrated for API documentation, allowing developers to explore and test API endpoints easily.
- Automapper: Used for mapping between DTOs (Data Transfer Objects) and entity models.
- Docker: Containerization tool for packaging the application and its dependencies.

## API Response Format:
The API follows a consistent response format using the ApiResponse<T> class. It includes information about the success of the operation, the data returned (if applicable), and an error message in case of failure.

## Swagger Documentation:
The application includes Swagger UI for interactive API documentation. Developers can access Swagger to explore, test, and understand the available endpoints.

## Development Practices:
- The application follows a modular and organized structure with a generic base service for common CRUD operations.
- DTOs are used to transfer data between the API and the client, helping to shape the data exchanged

## Known Issues:
Sometimes when running on Docker mode, the container that runs the SQLServer is unable to log in to the server. However, the second time that the application will start, this issue is no longer reproducible.

## Docker Support:
The application includes a Dockerfile for containerization. Developers can build and run the application within a Docker container, providing better consistency and portability.
This Match Management API serves as a backend system for managing sports-related data, offering a RESTful API for creating, retrieving, updating, and deleting information about matches and their odds.
   
