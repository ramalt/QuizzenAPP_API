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
    private const string PHOTO_SERVICE_BASE = "http://localhost:5173"; // TODO: get service address from configurations

    public PhotoRepository(QuizzerAppContext context)
    {
        _context = context;
    }
    public async Task<bool> AddQuestionImageAsync(QuestionId questionId, Guid imgId, string imgPath)
    {
        // string path = "http://localhost:5173/q/" + imgId.ToString() + ".jpg";
        string path = PHOTO_SERVICE_BASE + imgPath; // "http://localhost:5173/q/[img id here].jpg"

        QuestionImage qImage = new(imgId, questionId, path);
        await _context.QuestionImages.AddAsync(qImage);

        var res = await _context.SaveChangesAsync();

        return res > 0;
    }
    public async Task<bool> AddAnswerImageAsync(AnswerId answerId, Guid imgId, string imgPath)
    {

        string path = PHOTO_SERVICE_BASE + imgPath; // "http://localhost:5173/q/[img id here].jpg"

        AnswerImage qImage = new(imgId, answerId, path);
        await _context.AnswerImages.AddAsync(qImage);

        var res = await _context.SaveChangesAsync();

        return res > 0;
    }
    public async Task<bool> AddUserImageAsync(string userId, Guid imgId, string imgPath)
    {

        string path = PHOTO_SERVICE_BASE + imgPath;

        var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (dbUser is null) throw new Exception("user does not exist");

        dbUser.ProfileImg = path;
        var res = await _context.SaveChangesAsync();
        return res > 0;



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
