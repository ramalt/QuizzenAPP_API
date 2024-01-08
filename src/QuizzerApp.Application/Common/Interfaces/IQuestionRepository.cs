using QuizzenApp.Domain.Entities.QuestionAggregate;

namespace QuizzerApp.Application.Common.Interfaces;

public interface IQuestionRepository
{
    Task<List<Question>> GetAllAsync();
    Task<List<Question>> GetAllByUserIdAsync(string userId);
    Task<Question> GetAsync(Guid id);
    Task CreateAsync(Question question);
    void UpdateAsync(Question question);
    void DeleteAsync(Question question);

}
