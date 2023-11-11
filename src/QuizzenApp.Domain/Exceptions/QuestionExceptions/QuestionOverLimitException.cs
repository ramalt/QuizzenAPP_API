namespace QuizzenApp.Domain.Exceptions.QuestionExceptions;

public class QuestionOverLimitException : ApplicationException
{
    private Type type;
    private string v;

    public QuestionOverLimitException(string type, string limit) : base($"Invalid value for Question: '{type}'. '{type}' value must be less than '{limit}'.")
    {
    }

    public QuestionOverLimitException(Type type, string v)
    {
        this.type = type;
        this.v = v;
    }
}
