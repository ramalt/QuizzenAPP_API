using QuizzenApp.Domain.Enums;

namespace QuizzerApp.Application.Dtos.Answer;

public record AnswerDto(Guid Id,
                        string Text,
                        AnswerStatus Status,
                        string UserId,
                        string QuestionId,
                        DateTime CreatedDate,
                        DateTime UpdatedDate);