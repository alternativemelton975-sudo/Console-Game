@page "/"

<h1>Number Guessing Game</h1>

<p>@message</p>

@if (!won)
{
    <input type="number" @bind="guessInput" placeholder="Enter your guess" />

    <button @onclick="CheckGuess">
        Guess
    </button>
}

@if (won)
{
    <button @onclick="StartNewGame">
        Play Again
    </button>
}

<p>Attempts: @attempts</p>

@code {
    private Random random = new();

    private int secret;
    private int attempts;
    private bool won;

    private string guessInput = "";
    private string message = "";

    protected override void OnInitialized()
    {
        StartNewGame();
    }

    private void StartNewGame()
    {
        secret = random.Next(1, 101);
        attempts = 0;
        won = false;
        guessInput = "";

        message = "I'm thinking of a number between 1 and 100. Can you guess it?";
    }

    private void CheckGuess()
    {
        if (!int.TryParse(guessInput, out int guess))
        {
            message = "Please enter a valid number.";
            return;
        }

        attempts++;

        if (guess == secret)
        {
            won = true;
            message = $"🎉 Congratulations! You guessed it in {attempts} attempts.";
        }
        else if (guess < secret)
        {
            message = "⬆️ Too low. Try again.";
        }
        else
        {
            message = "⬇️ Too high. Try again.";
        }

        guessInput = "";
    }
}
