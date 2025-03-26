# Redington Probability Calculator – Full Stack Project Documentation

## 🌎 Project Overview

The Redington Probability Calculator is a full-stack web application designed to help investment consultants compute basic probability operations: `CombinedWith` and `Either`, based on two input probabilities. The goal was to deliver a solution that is:

- Professionally structured
- Scalable and maintainable
- Demonstrates advanced yet appropriate use of technology
- Easy to test, explain, and extend

The project has been split into two distinct layers:

- **Backend**: ASP.NET Core Web API
- **Frontend**: React with TypeScript and Bootstrap

This document outlines the reasoning behind each decision, technology used, architecture design, and what was deliberately avoided for good reasons.

---

## 🧬 Backend – ASP.NET Core Web API

### 📺 Technologies Used

| Technology                      | Purpose                                                                 |
|----------------------------------|-------------------------------------------------------------------------|
| ASP.NET Core Web API            | Lightweight REST API and application host                              |
| FluentValidation                | Declarative and centralized input validation                           |
| xUnit, Moq, FluentAssertions    | Unit testing with mocks and expressive assertions                      |
| Swashbuckle / Swagger UI        | Auto-generated, interactive API documentation                          |
| System.Text.Json Enum Converter | Displays enums as strings in request/response                          |
| File I/O (Async)                | Logging calculations to a file (no database required)                  |

### 📚 Architecture & Structure

```
Redington.ProbabilityCalculator/
├── Api/              → Controllers, Swagger, DI setup, CORS
├── Core/             → Business logic, DTOs, Enums, Interfaces
├── Infrastructure/   → Logging implementation (file-based)
└── Tests/            → Unit tests for service and controller layers
```

### 🤝 Design Decisions

- **Clean Architecture Principles**: Code is split into Core (business logic), Infrastructure (implementation), and API (presentation layer).
- **Dependency Injection**: All services (calculator, logger, validator) are injected, making testing and extension easy.
- **Single Responsibility Principle**: Each class has one job — e.g., the logger only logs, the calculator only calculates.
- **Async Programming**: File logging is async to avoid blocking I/O operations.
- **Validation with FluentValidation**: Clean and testable validation rules for probability range.
- **Centralized Error Handling**: Middleware to catch and return friendly error responses.

### ❌ What We Didn't Use (and Why)

| Excluded Feature       | Reason                                                                 |
|------------------------|------------------------------------------------------------------------|
| Entity Framework / DB  | Brief explicitly asked for no database; file-based logging was sufficient |
| MediatR / CQRS         | Overhead for a single use case; pattern simulated via service layer     |
| Authentication / JWT   | Explicitly excluded per project requirements                            |
| Global State / Caching | Not needed due to stateless, single-calculation nature of API           |

---

## 🌐 Frontend – React + TypeScript + Bootstrap

### 📺 Technologies Used

| Technology     | Purpose                                           |
|----------------|---------------------------------------------------|
| React          | Component-based UI development                   |
| TypeScript     | Strong typing, safer state management            |
| Vite           | Lightning-fast dev server and build tool         |
| Bootstrap 5    | Clean, responsive UI styling                     |
| Axios          | HTTP client for backend communication            |

### 📚 Structure

```
src/
├── components/          → Reusable UI components
│   └── CalculatorForm.tsx
├── services/            → Axios API client
│   └── api.ts
├── types/               → DTOs and enums shared with backend model
│   └── Probability.ts
├── App.tsx              → Application entry point
└── main.tsx             → Bootstrap file for React/Vite
```

### 🤝 Design Decisions

- **Bootstrap instead of complex UI libraries**: Lightweight, fast to style, and acceptable for enterprise-grade UI.
- **No Formik/Yup**: Handled basic form validation manually, as it's a simple form with minimal fields.
- **TypeScript**: Prevents bugs, aligns with backend DTOs, improves long-term maintainability.
- **Axios**: Clean and reliable HTTP client with interceptors support (for future).
- **No Global State**: This is a stateless form — no need for Redux or Context API.

### ❌ What We Didn't Use (and Why)

| Feature/Library         | Reason                                                             |
|-------------------------|--------------------------------------------------------------------|
| Tailwind / MUI          | Avoided to keep styling simple and aligned with enterprise norms   |
| Redux / Zustand         | No shared or global state required                                 |
| Formik / React Hook Form| Simple validation logic achievable without dependencies             |
| React Testing Library   | Out of scope for this exercise; can be easily added if needed      |

---

## 🚀 How to Run Locally

### 📂 Backend
```bash
cd src/Redington.ProbabilityCalculator.Api
dotnet run
```
Visit Swagger UI at:
```
http://localhost:5007/swagger
```

### 📂 Frontend
```bash
cd redington-calculator-frontend
npm install
npm run dev
```
Open in browser:
```
http://localhost:5173
```
Ensure backend is also running at `http://localhost:5007`.

---

## 💡 Additional Notes

- CORS is enabled on the backend for `http://localhost:5173`
- Logging is written to `Logs/calculations.txt` with timestamps and results
- The backend is thoroughly tested with `xUnit` and `Moq`

---

## 💪 Interview-Worthy Highlights

- Clean separation of responsibilities
- Real-world practices like async I/O, centralized validation, and API documentation
- Scalable, testable architecture that avoids overengineering
- Demonstrates mature judgment: **when to use something, and when not to**

---

## 🔄 Future Enhancements

- Add Docker support for backend + frontend containerized deployment
- Add GitHub Actions for CI testing
- Add environment-based API URL config in React
- Extend with user history (requires database + EF Core)
- Add frontend test coverage and loading states

---

## 👨‍💼 Author Statement

This project is intentionally crafted to reflect clean coding principles, industry-standard architecture, and thoughtful design decisions. It stays within the scope of the brief while being fully extensible — proving readiness for production systems, collaboration, and further innovation.

