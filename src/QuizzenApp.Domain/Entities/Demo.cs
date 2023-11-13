// using Microsoft.AspNetCore.Identity;
// using QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;
// using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
// using QuizzenApp.Domain.Entities.UserAggregate.ValueObjects;
// using QuizzenApp.Shared.Domain;

// namespace QuizzenApp.Domain.Entities;

// public class Question : AggregateRoot<QuestionId>
// {
//     public new QuestionId Id { get; private set; } 
//     public QuestionTitle Title { get; private set; } 
//     public List<QuestionImage> Images {get; set;}
//     public string UserId { get; private set; }
//     public User User { get; private set; } 

//     public List<Answer>? Answers { get; private set; }   
// }
// public class QuestionImage
// {
//     public QuestionImageId Id { get; set; }
//     public string Url { get; private set; }
//     public Guid QuestionId { get; set; }
//     public Question Question { get; set; }
// }

// public class Answer : AggregateRoot<AnswerId>
// {
//     public AnswerId Id { get; set; }
//     public AnswerText Text { get; private set; } 
//     public List<AnswerImage> Images { get; private set; } 
//     public string UserId { get; private set; }
//     public User User { get; private set; } 

//     public Guid QuestionId { get; set; }
//     public virtual Question Question { get; set; }
// }
// public class AnswerImage
// {
//     public AnswerImageId Id { get; private set; }
//     public string Url { get; set; }

//     public Guid AnswerId { get; set; }
//     public Answer Answer { get; set; }
// }

// public class User : IdentityUser 
// {
//     public UserProfileImage ProfilePic { get; private set; }
//     public ICollection<Question> Questions { get; set; }
//     public ICollection<Answer> Answers { get; set; }   
// }