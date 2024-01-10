namespace QuizzenApp.Shared;

public class QConstants
{
    public const string RMQ_HOST = "localhost";
    public const string DEFAULT_EXCHANGE_TYPE = "direct";

    // EXCHANGE
    public const string VOTE_EXCHANE = "question.vote";

    //QUEUE
    public const string CREATE_QUESTION_VOTE_QUEUE = "create_question_vote";
    public const string DELETE_QUESTION_VOTE_QUEUE = "delete_question_vote";
    public const string CREATE_ANSWER_VOTE_QUEUE = "create_answer_vote";
    public const string DELETE_ANSWER_VOTE_QUEUE = "delete_answer_vote";

}
