//setup

string secretWord = "mumin";
List<char> guessedLetters = [];
int lives = 6;

Console.Clear();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine();
Console.Write("\nWelcome to Hangman!");
Console.WriteLine();

while(lives > 0)
{
    DisplayMaskedWord(secretWord, guessedLetters);

    InfoLine($"\nLives: {lives}");
    Info("\nGuess a letter or a word: ");

    string stringInput = Console.ReadLine()!;
    char guess = stringInput[0];
    Console.WriteLine();

    if(stringInput.Length > 1)
    {
        if(secretWord == stringInput)
        {
            SuccessLine("Correct!");
            return;
        }
        else
        {
            ErrorLine("Wrong. -2 lives gone\n");
            lives -= 2;
            continue;
        }
    }

    if(!IsAllowedGuess(guess))
    {
        WarningLine("Please enter a letter.\n");
        continue;
    }

    if(guessedLetters.Contains(guess))
    {
        WarningLine("You've already guessed that letter.\n");
        continue;
    }

    guessedLetters.Add(guess);

    if(secretWord.Contains(guess))
    {
        SuccessLine("Correct!\n");
    }
    else
    {
        lives--;
        ErrorLine("Wrong!\n");
    }

    if(IsWordGuessed(secretWord, guessedLetters))
    {
        SuccessLine("Congrats! You won!");
        InfoLine();
        return;
    }
}

ErrorLine($"Game over! The word was {secretWord}");

static bool IsWordGuessed(string word, List<char> guessedLetters)
{
    return word.All(guessedLetters.Contains);
}

static bool IsAllowedGuess(char guess)
{
    return char.IsLetter(guess);
}

static void DisplayMaskedWord(string word, List<char> guessedLetters)
{
    foreach(char letter in word)
    {
        if(guessedLetters.Contains(letter))
        {
            Info(letter + " ");
        }
        else
        {
            Info("_ ");
        }
    }
}

static void Info(string message)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(message);
}

static void InfoLine(string message="")
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(message);
}

static void SuccessLine(string message="")
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(message);
}

static void ErrorLine(string message="")
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(message);
}

static void WarningLine(string message="")
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(message);
}