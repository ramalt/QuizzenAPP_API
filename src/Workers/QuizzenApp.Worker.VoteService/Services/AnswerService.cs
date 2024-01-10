using Dapper;
using Microsoft.Data.SqlClient;
using QuizzenApp.Shared.Events.Answer;

namespace QuizzenApp.Worker.VoteService.Services;

public class AnswerService
{
    private readonly string _connStr;

    public AnswerService(string connStr)
    {
        _connStr = connStr;
    }

    public async Task<bool> CreateAnswerVote(CreateAnswerUpVoteEvent @event)
    {
        using var connection = new SqlConnection(_connStr);

        var existingVote = await connection.QueryFirstOrDefaultAsync("SELECT * FROM AnswerVotes WHERE AnswerId = @AnswerId AND UserId = @UserId", new
        {
            @event.AnswerId,
            @event.UserId
        });

        if (existingVote is not null)
            return false;

        try
        {
            await connection.ExecuteAsync("INSERT INTO AnswerVotes (Id, AnswerId, UserId, VoteType, CreatedDate) VALUES(@Id, @AnswerId, @UserId, @VoteType, @CreatedDate)", new
            {
                Id = Guid.NewGuid(),
                AnswerId = @event.AnswerId,
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

    public async Task<bool> DeleteAnswerVote(DeleteAnswerVoteEvent @event)
    {
        using var connection = new SqlConnection(_connStr);

        var existingVote = await connection.QueryFirstOrDefaultAsync("SELECT * FROM AnswerVotes WHERE AnswerId = @AnswerId AND UserId = @UserId", new
        {
            @event.AnswerId,
            @event.UserId
        });

        if (existingVote is null)
            return false;

        try
        {
            await connection.ExecuteAsync("DELETE FROM AnswerVotes WHERE AnswerId = @AnswerId AND UserId = @UserId", new
            {
                Id = Guid.NewGuid(),
                AnswerId = @event.AnswerId,
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
