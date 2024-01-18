using Microsoft.EntityFrameworkCore;
using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Infrastructure.EFCore.Contexts;

namespace QuizzerApp.Infrastructure.Persistence;

public class ExamRepository : IExamRepository
{
    private readonly QuizzerAppContext _context;

    public ExamRepository(QuizzerAppContext context)
    {
        _context = context;
    }

    public async Task<List<Subject>> GetSubjectsByExamId(Guid examId) => await _context.Subjects.Where(s => s.ExamId == examId).ToListAsync();
    public async Task<List<Topic>> GetTopicsBySubjectId(Guid subjectId) => await _context.Topics.Where(t => t.SubjectId == subjectId).ToListAsync();
    public async Task<Exam?> GetExamAsync(Guid examId) => await _context.Exams.FirstOrDefaultAsync(e => e.Id == examId);
    public async Task<Subject?> GetSubjectAsync(Guid subjectId) => await _context.Subjects.FirstOrDefaultAsync(e => e.Id == subjectId);
    public async Task<Topic?> GetTopicAsync(Guid topicId) => await _context.Topics.FirstOrDefaultAsync(e => e.Id == topicId);
}