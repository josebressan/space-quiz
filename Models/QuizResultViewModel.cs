namespace space_quiz.Models;

public class QuizResultViewModel
{
    public int Score { get; set; }
    public int Total { get; set; }
    public string Summary { get; set; } = string.Empty;
    public List<QuestionResult> Results { get; set; } = new();
}

public class QuestionResult
{
    public QuizQuestion Question { get; set; } = new();
    public string UserAnswer { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
}
