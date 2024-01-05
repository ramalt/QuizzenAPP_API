using QuizzenApp.Domain.Entities.UserAggregate;

namespace QuizzerApp.Application.Common.Interfaces;

public interface IUserRepository
{
    // Task<List<User>> GetAllAsync();
    Task<User> GetAsync(string id);
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
}
