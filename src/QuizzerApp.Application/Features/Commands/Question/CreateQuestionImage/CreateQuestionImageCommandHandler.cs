using MediatR;
using QuizzenApp.PhotoStock.Services;
using QuizzenApp.Shared.Exceptions;
using QuizzerApp.Application.Common.Interfaces;

namespace QuizzerApp.Application.Features.Commands.Question.CreateQuestionImage;

public class CreateQuestionImageCommandHandler : IRequestHandler<CreateQuestionImageCommand>
{
    private readonly IRepositoryManager _manager;
    private readonly IPhotoService _photo;

    public CreateQuestionImageCommandHandler(IPhotoService photo, IRepositoryManager manager)
    {
        _photo = photo;
        _manager = manager;
    }

    public async Task Handle(CreateQuestionImageCommand request, CancellationToken cancellationToken)
    {
        var imgId = Guid.NewGuid();
        // save image to photostock
        string? imgPath = await _photo.SaveQuestionPhoto(request.Img, imgId.ToString(), cancellationToken);

        if (string.IsNullOrEmpty(imgPath)) throw new PhotoSaveException("Question");


        var res = await _manager.Photo.AddQuestionImageAsync(request.QuestionId, imgId, imgPath);

        if (!res) throw new Exception("An error occured while saving photo to db");

    }
}