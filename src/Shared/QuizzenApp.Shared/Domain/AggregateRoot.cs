namespace QuizzenApp.Shared.Domain;

public abstract class AggregateRoot<TId> where TId : notnull
{
    public TId Id { get; protected set; }
}
