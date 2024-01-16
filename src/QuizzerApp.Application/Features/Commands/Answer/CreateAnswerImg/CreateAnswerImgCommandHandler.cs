using MediatR;
using QuizzenApp.PhotoStock.Services;
using QuizzerApp.Application.Common.Interfaces;

namespace QuizzerApp.Application.Features.Commands.Answer.CreateAnswerImg;

public class CreateAnswerImgCommandHandler : IRequestHandler<CreateAnswerImgCommand, bool>
{
    private readonly IRepositoryManager _manager;
    private readonly IPhotoService _photo;

    public CreateAnswerImgCommandHandler(IPhotoService photo, IRepositoryManager manager)
    {
        _photo = photo;
        _manager = manager;
    }

    public async Task<bool> Handle(CreateAnswerImgCommand request, CancellationToken cancellationToken)
    {
        var imgId = Guid.NewGuid();

        await _photo.SaveAnswerPhoto(request.Img, imgId.ToString(), cancellationToken);

        await _manager.Photo.AddAnswerImageAsync(request.AnswerId, imgId);

        return true;
    }
}
