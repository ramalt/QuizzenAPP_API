using MediatR;
using QuizzenApp.PhotoStock.Services;
using QuizzenApp.Shared.Exceptions;
using QuizzerApp.Application.Common.Interfaces;

namespace QuizzerApp.Application.Features.Commands.User.CreateUserImage;

public class CreateUserImageCommandHandler : IRequestHandler<CreateUserImageCommand>
{
    private readonly IRepositoryManager _manager;
    private readonly IPhotoService _photo;

    public CreateUserImageCommandHandler(IPhotoService photo, IRepositoryManager manager)
    {
        _photo = photo;
        _manager = manager;
    }

    public async Task Handle(CreateUserImageCommand request, CancellationToken cancellationToken)
    {
        var imgId = Guid.NewGuid();
        string? imgPath = await _photo.SaveUserPhoto(request.Img, imgId.ToString(), cancellationToken);

        if (string.IsNullOrEmpty(imgPath)) throw new PhotoSaveException("User");

        var res = await _manager.Photo.AddUserImageAsync(request.UserId, imgId, imgPath);

        if (!res) throw new DbPhotoSaveException();

    }
}
