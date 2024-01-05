using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Infrastructure.EFCore.Contexts;

namespace QuizzerApp.Infrastructure.Persistence;

public class RepositoryManager : IRepositoryManager
{
    private readonly QuizzerAppContext _context;
    private readonly Lazy<IQuestionRepository> _questionRepository;
    private readonly Lazy<IUserRepository> _userRepository;

    public RepositoryManager(QuizzerAppContext context)
    {
        _context = context;
        _questionRepository = new Lazy<IQuestionRepository>(() => new QuestionRepository(context: _context));
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(context: _context));
    }

    public IQuestionRepository Question => _questionRepository.Value;
    public IUserRepository User => _userRepository.Value;
    public Task SaveAsync() => _context.SaveChangesAsync();
}
