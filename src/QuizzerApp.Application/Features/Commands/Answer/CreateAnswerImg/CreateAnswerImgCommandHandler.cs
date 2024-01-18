using MediatR;
using QuizzenApp.PhotoStock.Services;
using QuizzenApp.Shared.Exceptions;
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

        var imgId = Guid.NewGuid();

        string? imgPath = await _photo.SaveAnswerPhoto(request.Img, imgId.ToString(), cancellationToken);

        if (string.IsNullOrEmpty(imgPath)) throw new PhotoSaveException("Answer");

        var res = await _manager.Photo.AddAnswerImageAsync(request.AnswerId, imgId, imgPath);

        if (!res) throw new DbPhotoSaveException();


    }
}
