using MediatR;
using QuizzenApp.PhotoStock.Services;
using QuizzerApp.Application.Common.Interfaces;

namespace QuizzerApp.Application.Features.Commands.Answer.CreateAnswerImg;

public class CreateAnswerImgCommandHandler : IRequestHandler<CreateAnswerImgCommand>
{
    private readonly IRepositoryManager _manager;
    private readonly IPhotoService _photo;

    public CreateAnswerImgCommandHandler(IPhotoService photo, IRepositoryManager manager)
    {
        _photo = photo;
        _manager = manager;
    }

    public async Task Handle(CreateAnswerImgCommand request, CancellationToken cancellationToken)
    {
        //TODO: Check is answer exist

        var imgId = Guid.NewGuid();

        string? imgPath = await _photo.SaveAnswerPhoto(request.Img, imgId.ToString(), cancellationToken);

        if (string.IsNullOrEmpty(imgPath)) throw new Exception("Image cannot save");

        var res = await _manager.Photo.AddAnswerImageAsync(request.AnswerId, imgId, imgPath);

        if (!res) throw new Exception("An error occured while saving photo to db");


    }
}
