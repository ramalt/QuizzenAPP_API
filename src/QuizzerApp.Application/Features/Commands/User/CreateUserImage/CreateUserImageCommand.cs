using MediatR;
using Microsoft.AspNetCore.Http;
using QuizzenApp.PhotoStock.Services;
using QuizzerApp.Application.Common.Interfaces;

namespace QuizzerApp.Application.Features.Commands.User.CreateUserImage;

public record CreateUserImageCommand(IFormFile Img, string UserId) : IRequest<bool>;

public class CreateUserImageCommandHandler : IRequestHandler<CreateUserImageCommand, bool>
{
    private readonly IRepositoryManager _manager;
    private readonly IPhotoService _photo;

    public CreateUserImageCommandHandler(IPhotoService photo, IRepositoryManager manager)
    {
        _photo = photo;
        _manager = manager;
    }

    public async Task<bool> Handle(CreateUserImageCommand request, CancellationToken cancellationToken)
    {
        var imgId = Guid.NewGuid();
        await _photo.SaveUserPhoto(request.Img, imgId.ToString(), cancellationToken);

        await _manager.Photo.AddUserImageAsync(request.UserId, imgId);

        return true;
    }
}
