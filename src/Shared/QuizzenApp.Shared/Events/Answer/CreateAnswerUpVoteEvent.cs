namespace QuizzenApp.Shared.Events.Answer;

public record CreateAnswerUpVoteEvent(Guid AnswerId, string UserId);
