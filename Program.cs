using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Number Guessing Game";
        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I'm thinking of a number between 1 and 100.");
        Console.WriteLine("Can you guess what it is?");

        var random = new Random();
        int secret = random.Next(1, 101);
        int attempts = 0;
        bool won = false;

        while (!won)
        {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int guess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }
            attempts++;

            if (guess == secret)
            {
                Console.WriteLine($"Congratulations! You guessed it in {attempts} attempts.");
                won = true;
            }
            else if (guess < secret)
            {
                Console.WriteLine("Too low. Try again.");
            }
            else
            {
                Console.WriteLine("Too high. Try again.");
            }
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
