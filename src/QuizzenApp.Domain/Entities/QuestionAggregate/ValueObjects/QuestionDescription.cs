using QuizzenApp.Domain.Exceptions.Common;
using QuizzenApp.Domain.Exceptions.QuestionExceptions;

namespace QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

public record QuestionDescription
{
    public string Text { get; init; }
    public List<QuestionImage> Images { get; init; }

    public QuestionDescription(string text, List<QuestionImage> images)
    {
        int textMaxLimit = 500;
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new EmptyValueException(nameof(Text));
        }

        if (text.Length > textMaxLimit)
        {
            throw new QuestionOverLimitException(type: typeof(QuestionDescription), textMaxLimit.ToString());
        }
        Text = text;
        Images = images;
    }
}
