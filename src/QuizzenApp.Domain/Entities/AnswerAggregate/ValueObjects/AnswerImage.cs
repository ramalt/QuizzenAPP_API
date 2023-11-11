using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;

public class AnswerImage
{
    public string Url { get; init; }

    public AnswerImage(string url)
    {
        Url = url;   
    }
}
