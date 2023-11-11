namespace QuizzenApp.Domain.Exceptions.QuestionExceptions;

public class QuestionOverLimitException : ApplicationException
{
    public QuestionOverLimitException(string type, string limit) : base($"Invalid value Question Title: '{type}'. '{type}' value must be less than '{limit}'.")
    {
    }
}
