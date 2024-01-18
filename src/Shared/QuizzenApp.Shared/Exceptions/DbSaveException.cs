namespace QuizzenApp.Shared.Exceptions;

public class DbSaveException : Exception
{
    public DbSaveException(string objectName) : base($"An error occured while saving {objectName} to database")
    {

    }
}
