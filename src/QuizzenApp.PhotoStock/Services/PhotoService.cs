using SystemFile = System.IO.File;


namespace QuizzenApp.PhotoStock.Services;

public class PhotoService : IPhotoService
{
    private const string ROOTPATH = "../QuizzenApp.PhotoStock/wwwroot";



    public async Task<string?> SaveQuestionPhoto(IFormFile file, string imgId, CancellationToken cancellationToken)
    {
        if (file is not null && file.Length > 0)
        {
            var path = ROOTPATH + "/q/" + imgId + ".jpg";


            using Stream stream = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(stream, cancellationToken);

            string res = "/q/" + imgId + ".jpg";
            return res;
        }
        return null;
    }


    public bool DeleteQuestionPhoto(string url)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", url); // ~/wwwroot/photos/example.jpg

        if (!SystemFile.Exists(path))
            return false;

        SystemFile.Delete(path);

        return true;
    }

    public async Task<string?> SaveUserPhoto(IFormFile file, string imgId, CancellationToken cancellationToken)
    {
        if (file is not null && file.Length > 0)
        {
            var path = ROOTPATH + "/u/" + imgId + ".jpg";


            using Stream stream = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(stream, cancellationToken);

            string res = "/u/" + imgId + ".jpg";
            return res;


        }
        return null;
    }

    public bool DeleteUserPhoto(string url)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> SaveAnswerPhoto(IFormFile file, string imgId, CancellationToken cancellationToken)
    {
        if (file is not null && file.Length > 0)
        {
            var path = ROOTPATH + "/a/" + imgId + ".jpg";


            using Stream stream = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(stream, cancellationToken);

            string res = "/a/" + imgId + ".jpg";
            return res;
        }
        return null;
    }

    public bool DeleteAnswerPhoto(string url)
    {
        throw new NotImplementedException();
    }
}
