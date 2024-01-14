using MediatR;
using QuizzenApp.PhotoStock.Services;
using QuizzerApp.Application.Common.Interfaces;

namespace QuizzerApp.Application.Features.Commands.Question.CreateQuestionImage;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionImageCommand, bool>
{
    private readonly IRepositoryManager _manager;
    private readonly IPhotoService _photo;

    public CreateQuestionCommandHandler(IPhotoService photo, IRepositoryManager manager)
    {
        _photo = photo;
        _manager = manager;
    }

    public async Task<bool> Handle(CreateQuestionImageCommand request, CancellationToken cancellationToken)
    {
        var imgId = Guid.NewGuid();
        // save image to photostock
        await _photo.SaveQuestionPhoto(request.Img, imgId.ToString(), cancellationToken);

        //update db question image    
        await _manager.Photo.AddQuestionImageAsync(request.QuestionId, imgId);

        return true;
    }
}
