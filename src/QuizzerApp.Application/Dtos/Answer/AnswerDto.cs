using QuizzenApp.Domain.Enums;
using QuizzerApp.Application.Dtos.Image;
using QuizzerApp.Application.Dtos.User;

namespace QuizzerApp.Application.Dtos.Answer;

public record AnswerDto(Guid Id,
                        string Text,
                        AnswerStatus Status,
                        UserDto User,
                        string QuestionId,
                        List<ImageDto> Images,
                        DateTime CreatedDate,
                        DateTime UpdatedDate);