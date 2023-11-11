namespace QuizzenApp.Domain.Exceptions.Common;

public class EmptyValueException : ApplicationException
{
    public EmptyValueException(string type) : base($"The type of '{type}' cannot be null or empty.")
    {
    }
}
