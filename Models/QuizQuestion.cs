namespace space_quiz.Models;

public class QuizQuestion
{
    public int Id { get; set; }
    public string Prompt { get; set; } = string.Empty;
    public List<string> Choices { get; set; } = new();
    public string CorrectAnswer { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
}
