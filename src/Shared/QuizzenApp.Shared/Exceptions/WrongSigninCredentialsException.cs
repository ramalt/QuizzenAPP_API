using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace QuizzenApp.Shared.Exceptions;

public class WrongSigninCredentialsException : Exception
{
    public WrongSigninCredentialsException() : base("Email or password incorrect")
    {

    }

    public HttpStatusCode statusCode = HttpStatusCode.BadRequest;
}
