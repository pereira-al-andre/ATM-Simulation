# ATM Machine API

## Description

This repository contains an API that simulates the basic functioning of an ATM (Automated Teller Machine).

## Technical Details

The API is built using a layered architecture, following the repository pattern, implementing dependency injection, CQRS, and is exposed through a single controller for simplified understanding.

- **ORM:** Entity Framework Core
- **CQRS Implementation:** Mediatr

## Points for Future Improvement

To enhance this API, consider adding the following features:

- More functionalities for detailed control of operations
- Transaction storage
- User entity for withdrawal operations
- Caching for ATM note retrieval
- Authentication and authorization for routes

Please note that these features are not included in the initial version for the sake of simplicity.

## Instructions

To run the project:

1. Clone the repository to your machine.
2. Execute the solution.
3. Start the project using the Docker Compose button in Visual Studio.

Make sure you have Docker installed and running on your machine before following the above steps.
