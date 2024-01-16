using Microsoft.EntityFrameworkCore;
using QuizzenApp.Domain.Entities.AnswerAggregate;
using QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Infrastructure.EFCore.Contexts;

namespace QuizzerApp.Infrastructure.Persistence;

public class PhotoRepository : IPhotoRepository
{
    private readonly QuizzerAppContext _context;

    public PhotoRepository(QuizzerAppContext context)
    {
        _context = context;
    }
    public async Task AddQuestionImageAsync(QuestionId questionId, Guid imgId)
    {

        string path = "http://localhost:5173/q/" + imgId.ToString() + ".jpg";

        QuestionImage qImage = new(imgId, questionId, path);
        await _context.QuestionImages.AddAsync(qImage);

        await _context.SaveChangesAsync();
    }
    public async Task AddAnswerImageAsync(AnswerId answerId, Guid imgId)
    {

        string path = "http://localhost:5173/a/" + imgId.ToString() + ".jpg";

        AnswerImage qImage = new(imgId, answerId, path);
        await _context.AnswerImages.AddAsync(qImage);

        await _context.SaveChangesAsync();
    }
    public async Task AddUserImageAsync(string userId, Guid imgId)
    {

        string path = "http://localhost:5173/a/" + imgId.ToString() + ".jpg";

        var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (dbUser is not null)
        {
            dbUser.ProfileImg = path;
            await _context.SaveChangesAsync();

        }
    }
    public async Task DeleteQuestionImageAsync(Guid imageId)
    {
        var dbImage = await _context.QuestionImages.FirstOrDefaultAsync(i => i.Id == imageId);
        _context.QuestionImages.Remove(dbImage);
        await _context.SaveChangesAsync();
    }
    public List<QuestionImage> GetDbQuestionImgPaths(Guid questionId)
    {
        return _context.QuestionImages.Where(qi => qi.QuestionId == new QuestionId(questionId)).ToList();

    }

    public List<AnswerImage> GetDbAnswerImgPaths(Guid answerId)
    {
        return _context.AnswerImages.Where(ai => ai.AnswerId == new AnswerId(answerId)).ToList();

    }
}
