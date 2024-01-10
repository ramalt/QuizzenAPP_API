using QuizzenApp.Shared;
using QuizzenApp.Shared.Events.Question;
using QuizzenApp.Shared.Infrastructure;
using QuizzenApp.Worker.VoteService.Services;

namespace QuizzenApp.Worker.VoteService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly QuestionService _questionService;
    private readonly IConfiguration _configuration;

    public Worker(ILogger<Worker> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        string? connectionString = _configuration.GetSection("SqlServer").GetSection("ConnectionString").Value;


        QuestionService _questionService = new(connectionString ?? throw new ArgumentNullException(connectionString));
        //CREATE 
        QProvider.CreateBasicConsumer()
                                    .SetExchange(QConstants.VOTE_EXCHANE)
                                    .SetQueue(QConstants.CREATE_QUESTION_VOTE_QUEUE, QConstants.VOTE_EXCHANE)
                                    .Receive<QuestionUpVoteEvent>(async @event =>
                                    {
                                        bool res = await _questionService.CreateQuestionVote(@event: @event);
                                        if (res is true)
                                        {
                                            _logger.LogInformation($"{DateTime.Now} - Received: {nameof(QuestionUpVoteEvent)} - {@event.QuestionId} ");
                                        }
                                        else
                                        {
                                            _logger.LogInformation($"{DateTime.Now} - Cancelled: {nameof(QuestionUpVoteEvent)} - {@event.QuestionId} ");
                                        }

                                    })
                                    .StartConsuming(QConstants.CREATE_QUESTION_VOTE_QUEUE);

        //DELETE
        QProvider.CreateBasicConsumer()
                            .SetExchange(QConstants.VOTE_EXCHANE)
                            .SetQueue(QConstants.DELETE_QUESTION_VOTE_QUEUE, QConstants.VOTE_EXCHANE)
                            .Receive<DeleteQuestionVoteEvent>(async @event =>
                            {
                                bool res = await _questionService.DeleteQuestionVote(@event: @event);

                                if (res)
                                {
                                    _logger.LogInformation($"{DateTime.Now} - Received: {nameof(DeleteQuestionVoteEvent)} - {@event.QuestionId} ");
                                }
                                else
                                {
                                    _logger.LogInformation($"{DateTime.Now} - Cancelled: {nameof(DeleteQuestionVoteEvent)} - {@event.QuestionId} ");

                                }
                            })
                            .StartConsuming(QConstants.DELETE_QUESTION_VOTE_QUEUE);

    }
}
