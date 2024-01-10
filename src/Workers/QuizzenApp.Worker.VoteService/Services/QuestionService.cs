using Dapper;
using Microsoft.Data.SqlClient;
using QuizzenApp.Shared.Events.Question;

namespace QuizzenApp.Worker.VoteService.Services;

public class QuestionService
{
    private readonly string _connStr;

    public QuestionService(string connStr)
    {
        _connStr = connStr;
    }

    public async Task<bool> CreateQuestionVote(QuestionUpVoteEvent @event)
    {
        using var connection = new SqlConnection(_connStr);

        var existingVote = await connection.QueryFirstOrDefaultAsync("SELECT * FROM QuestionVotes WHERE QuestionId = @QuestionId AND UserId = @UserId", new
        {
            @event.QuestionId,
            @event.UserId
        });

        if (existingVote is not null)
            return false;
        try
        {
            await connection.ExecuteAsync("INSERT INTO QuestionVotes (Id, QuestionId, UserId, VoteType, CreatedDate) VALUES(@Id, @QuestionId, @UserId, @VoteType, GETDATE())", new
            {
                Id = Guid.NewGuid(),
                QuestionId = @event.QuestionId,
                UserId = @event.UserId,
                VoteType = 1,
                CreatedDate = DateTime.Now
            });


        }
        catch (Exception e)
        {
            throw new Exception(e.Message);


        }


        return true;




    }

    public async Task<bool> DeleteQuestionVote(DeleteQuestionVoteEvent @event)
    {
        using var connection = new SqlConnection(_connStr);

        var existingVote = await connection.QueryFirstOrDefaultAsync("SELECT * FROM QuestionVotes WHERE QuestionId = @QuestionId AND UserId = @UserId", new
        {
            @event.QuestionId,
            @event.UserId
        });

        if (existingVote is null)
            return false;

        try
        {
            await connection.ExecuteAsync("DELETE FROM QuestionVotes WHERE QuestionId = @QuestionId AND UserId = @UserId", new
            {
                Id = Guid.NewGuid(),
                QuestionId = @event.QuestionId,
                UserId = @event.UserId,
            });

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);

        }

        return true;

    }
}
