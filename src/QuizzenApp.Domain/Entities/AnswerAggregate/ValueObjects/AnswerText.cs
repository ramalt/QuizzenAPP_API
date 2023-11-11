using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using QuizzenApp.Domain.Exceptions.Common;

namespace QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;

public record AnswerText
{
    public string Value { get; init; }

    public AnswerText(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyValueException(nameof(AnswerText));

        }
        Value = value;
    }
}
