using System.Reflection.PortableExecutable;

namespace QuizzerApp.Application.Common.Interfaces;

public interface IRepositoryManager
{
    public IQuestionRepository Question { get; }
    public IUserRepository User { get; }
    public IAnswerRepository Answer { get; }
    public IPhotoRepository Photo { get; }

    public Task SaveAsync();
}
