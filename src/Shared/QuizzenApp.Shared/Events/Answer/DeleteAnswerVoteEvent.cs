namespace QuizzenApp.Shared.Events.Answer;

public record DeleteAnswerVoteEvent(Guid AnswerId, string UserId);
