namespace QuizzenApp.Shared.Events.Question;

public record DeleteQuestionVoteEvent(Guid QuestionId, string UserId);
