using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var random = new Random();
int secret = random.Next(1, 101);

app.MapGet("/", () =>
{
    return """
    <html>
    <body>
        <h1>Number Guessing Game</h1>
        <form action="/guess" method="get">
            <input type="number" name="guess" />
            <button type="submit">Guess</button>
        </form>
    </body>
    </html>
    """;
});

app.MapGet("/guess", (int guess) =>
{
    string message;

    if (guess == secret)
    {
        message = "Congratulations! You guessed correctly!";
        secret = random.Next(1, 101);
    }
    else if (guess < secret)
    {
        message = "Too low!";
    }
    else
    {
        message = "Too high!";
    }

    return $"""
    <html>
    <body>
        <h1>{message}</h1>
        <a href="/">Try Again</a>
    </body>
    </html>
    """;
});

app.Run();
