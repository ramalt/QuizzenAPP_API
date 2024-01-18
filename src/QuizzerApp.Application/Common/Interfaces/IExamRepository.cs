using QuizzenApp.Domain.Entities.ExamAggregate;

namespace QuizzerApp.Application.Common.Interfaces;

public interface IExamRepository
{
    Task<List<Subject>> GetSubjectsByExamId(Guid examId);
    Task<List<Topic>> GetTopicsBySubjectId(Guid subjectId);
    Task<Exam?> GetExamAsync(Guid examId);
    Task<Subject?> GetSubjectAsync(Guid subjectId);
    Task<Topic?> GetTopicAsync(Guid topicId);
}
