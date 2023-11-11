namespace QuizzenApp.Domain.Exceptions.AnswerExceptions;

public class InvalidStatusException : ApplicationException
{
    public InvalidStatusException(Type enumType, object invalidValue) : base($"Invalid value '{invalidValue}' for enum type '{enumType}'.")
    {
    }
}
