# Redington Probability Calculator – Backend Documentation

## 📌 Project Summary

This ASP.NET Core Web API backend is built to solve a simple but real-world problem: enabling Redington investment consultants to calculate basic probability operations using user-provided inputs. While the logic is simple, the implementation showcases clean architecture, best practices, and scalable structure suitable for enterprise-grade solutions.

---

## 📺 Technologies Used

| Technology               | Purpose                                           |
|--------------------------|---------------------------------------------------|
| ASP.NET Core Web API     | Backend API and REST interface                   |
| FluentValidation         | Input validation (probabilities between 0–1)     |
| xUnit, Moq               | Unit testing and mocking                         |
| Swagger (Swashbuckle)    | Auto-generated interactive API docs              |
| System.Text.Json         | JSON serialization with enum string support      |
| File I/O (Async)         | Logging user calculations to a `.txt` file       |

---

## 🛡️ Architecture & Structure

This project follows a modular and layered architecture:

```
Redington.ProbabilityCalculator/
├── Api/              → Web API, Controllers, DI, Swagger
├── Core/             → DTOs, Interfaces, Enums, Services
├── Infrastructure/   → Logging (File I/O)
└── Tests/            → Unit tests using xUnit and Moq
```

---

## ✅ Key Design Principles

| Principle / Pattern              | Implementation                                    |
|----------------------------------|---------------------------------------------------|
| SOLID Principles                 | SRP, DI, Interface segregation                   |
| Clean Architecture (Lite)       | Core domain decoupled from infrastructure         |
| Command Pattern (CQRS-lite)     | `ProbabilityRequestDto` as Command DTO            |
| Async/Await for I/O             | Async logging via `File.AppendAllTextAsync()`     |
| Separation of Concerns          | Controller → Service → DTO → Logger → File        |
| Centralized Validation          | `FluentValidation` for probability bounds         |
| Consistent API Shape (Optional) | Can wrap with `ApiResponse<T>`                    |
| Swagger Enum Display            | Shows enum values as strings (`"Either"`, etc.)   |

---

## 💪 Testing

- Unit tests for both the calculator service and controller
- Mocked dependencies using Moq
- FluentAssertions for clean and expressive validation

Run tests:

```bash
dotnet test
```

---

## ❌ Why We Didn’t Use Certain Technologies

| Technology            | Reason                                                |
|-----------------------|--------------------------------------------------------|
| Entity Framework / DB | Not required; file-based log was sufficient            |
| JWT / Authentication  | Explicitly excluded per Redington brief                |
| Full CQRS/MediatR     | Unnecessary for single-action API, pattern simulated   |

---

## 🧐 Why This Approach?

This backend design reflects:
- **Scalable thinking** for a small-scope problem
- Focus on **clean code, testability, and structure**
- Adherence to **real-world best practices** without overengineering

It proves readiness for:
- Extending the system (user history, database, auth)
- Clean onboarding for teams
- Production-readiness from day one

---

## 🚀 Future-Ready Ideas

- Replace file logger with database persistence
- Introduce MediatR for CQRS messaging
- Add versioning and correlation ID middleware
- Add authentication layer (if needed)

---

## 🌐 Running the API

```bash
cd src/Redington.ProbabilityCalculator.Api
dotnet run
```

Then open Swagger UI:

```
http://localhost:5007/swagger
```

Try this sample payload:

```json
{
  "probabilityA": 0.5,
  "probabilityB": 0.6,
  "calculationType": "Either"
}
```

Expected result:

```json
{
  "result": 0.8
}
```

Check logs at:

```
Redington.ProbabilityCalculator.Api/Logs/calculations.txt
```

---

## 👨‍💼 Author Notes

This project was built with real-world architecture in mind to demonstrate clean design, testability, async programming, and thoughtful abstraction — while keeping it aligned with the provided scope and constraints.

