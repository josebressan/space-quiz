# Space Quiz

Space Quiz is a small ASP.NET Core MVC application that presents a five-question astronomy quiz, evaluates the user's answers, and shows a score summary with explanations for each question.

## Features

- Multiple-choice space-themed quiz questions
- Form submission with validation and anti-forgery protection
- Final score summary with per-question feedback
- Simple Bootstrap-based interface

## Prerequisites

- .NET SDK 10.0 or later
- A browser to run the web app locally

## Run the project locally

From the repository root, run:

```bash
dotnet restore
dotnet build
dotnet run
```

Then open the local ASP.NET Core URL shown in the terminal, usually:

- https://localhost:5001
- http://localhost:5000

The app uses the default ASP.NET Core launch profile, so the exact port may vary depending on your environment.

## Project structure

- `Program.cs` — ASP.NET Core startup and routing setup
- `Controllers/HomeController.cs` — quiz page and submission logic
- `Models/` — quiz question and result model classes
- `Views/Home/` — quiz form and results pages
- `wwwroot/` — static assets and frontend styling

## How the quiz works

The application loads a fixed list of five space-related questions, renders them in a form, and compares each submitted answer with the correct one. After submission, it calculates the score and displays an explanation for each question.
