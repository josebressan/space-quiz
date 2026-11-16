using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using space_quiz.Models;

namespace space_quiz.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(GetQuizQuestions());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Submit()
    {
        var questions = GetQuizQuestions();
        var results = new List<QuestionResult>();
        var score = 0;

        foreach (var question in questions)
        {
            var selectedAnswer = Request.Form[$"answer-{question.Id}"].ToString();
            var isCorrect = string.Equals(selectedAnswer, question.CorrectAnswer, StringComparison.OrdinalIgnoreCase);

            if (isCorrect)
            {
                score++;
            }

            results.Add(new QuestionResult
            {
                Question = question,
                UserAnswer = selectedAnswer,
                IsCorrect = isCorrect
            });
        }

        var summary = score switch
        {
            5 => "Mission accomplished. You are a true space explorer!",
            4 => "Excellent work. Your orbital instincts are sharp.",
            3 => "Solid effort. A few cosmic facts still need polishing.",
            2 => "You are in the launch window, but the galaxy needs more study.",
            _ => "The stars are still waiting for you to learn a little more."
        };

        return View("Results", new QuizResultViewModel
        {
            Score = score,
            Total = questions.Count,
            Summary = summary,
            Results = results
        });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private static List<QuizQuestion> GetQuizQuestions()
    {
        return new List<QuizQuestion>
        {
            new()
            {
                Id = 1,
                Prompt = "Which planet is known as the Red Planet?",
                Choices = new List<string> { "Mars", "Venus", "Jupiter", "Mercury" },
                CorrectAnswer = "Mars",
                Explanation = "Mars appears reddish because iron oxide dust covers much of its surface."
            },
            new()
            {
                Id = 2,
                Prompt = "What is the name of the galaxy that contains our Solar System?",
                Choices = new List<string> { "Andromeda", "Triangulum", "Milky Way", "Whirlpool" },
                CorrectAnswer = "Milky Way",
                Explanation = "Our Solar System sits within the Milky Way galaxy, a barred spiral galaxy."
            },
            new()
            {
                Id = 3,
                Prompt = "Which celestial body is the largest in our Solar System?",
                Choices = new List<string> { "Earth", "Saturn", "Jupiter", "Pluto" },
                CorrectAnswer = "Jupiter",
                Explanation = "Jupiter is the largest planet, with a diameter of about 139,820 km."
            },
            new()
            {
                Id = 4,
                Prompt = "Who was the first person to walk on the Moon?",
                Choices = new List<string> { "Buzz Aldrin", "John Glenn", "Yuri Gagarin", "Neil Armstrong" },
                CorrectAnswer = "Neil Armstrong",
                Explanation = "Neil Armstrong took the first steps on the Moon during Apollo 11 in 1969."
            },
            new()
            {
                Id = 5,
                Prompt = "What force keeps planets in orbit around the Sun?",
                Choices = new List<string> { "Magnetism", "Gravity", "Radiation pressure", "Friction" },
                CorrectAnswer = "Gravity",
                Explanation = "Gravity is the attractive force that keeps planets, moons, and other objects in orbit."
            }
        };
    }
}
