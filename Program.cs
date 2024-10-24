//setup
string secretWord = File.ReadAllText("./secretWord.txt");
List<char> guessedLetters = [];
int lives = 6;
bool showHint = true;

Console.Clear();

Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine();
Console.Write("\nWelcome to Hangman!");
Console.WriteLine();

while(lives > 0)
{
    DisplayMaskedWord(secretWord, guessedLetters);

    InfoLine($"\nLives: {lives}");
    Info("\nGuess a letter or a word: ");

    string stringInput = Console.ReadLine()!;

    if(stringInput.Length == 0)
    {
        WarningLine("Please enter a letter or a word.\n");
        continue;
    }

    if(stringInput.Length > 1)
    {
        if(secretWord == stringInput)
        {
            SuccessLine("Congrats! You won!\n");
            InfoLine("Do you want to play again? Click 'y' if not click 'n': ");
            string yesOrNo = Console.ReadLine()!;
            if(yesOrNo == "y")
            {
                lives = 6;
                showHint = true;
                var emptyList = new List<char>();
                guessedLetters = emptyList;
                Console.Clear();
                continue;
            }
            else if(yesOrNo == "n")
            {
                break;
            }
        }
        else
        {
            ErrorLine("Wrong. -2 lives \n");
            lives -= 2;
            continue;
        }
    }

    char guess = stringInput[0];
    Console.WriteLine();

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

    if (lives <= 2 && showHint)
    {
        Info("HINT: Hello in swedish.\n");
        showHint = false;
        continue;
    }

    if(IsWordGuessed(secretWord, guessedLetters))
    {   
        SuccessLine("Congrats! You won!\n");
        InfoLine();
        InfoLine("Do you want to play again? Click 'y' if not click 'n': ");
            string yesOrNo = Console.ReadLine()!;
            if(yesOrNo == "y")
            {
                lives = 6;
                showHint = true;
                var emptedList = new List<char>();
                guessedLetters = emptedList;
                Console.Clear();
                continue;
            }
            else if(yesOrNo == "n")
            { 
            return;
            }
    }

    System.Console.WriteLine("Hej");

    if (lives == 0)
    {   
        ErrorLine("Game over!\n");
        InfoLine($"The word was: {secretWord}.\n");
        InfoLine();
        InfoLine("Do you want to play again? Click 'y' if not click 'n': ");
            string yesOrNo = Console.ReadLine()!;
            if(yesOrNo == "y")
            {
                lives = 6;
                showHint = true;
                var emptedList = new List<char>();
                guessedLetters = emptedList;
                Console.Clear();
                continue;
            }
            else if(yesOrNo == "n")
            {
            return;
            }
    }
}

// ErrorLine("Game over!");


// static void startOver(int lives, bool showHint,List<char> guessedLetters)
// {
//     InfoLine("Do you want to play again? Click 'y' if not click 'n': ");
//             string yesOrNo = Console.ReadLine()!;
//             if(yesOrNo == "y")
//             {
//                 lives = 6;
//                 showHint = true;
//                 var emptedList = new List<char>();
//                 guessedLetters = emptedList;
//                 Console.Clear();
//                 continue;
//             }
//             else if(yesOrNo == "n")
//             {
//             return;
//             }
// }

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
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write(message);
}

static void InfoLine(string message="")
{
    Console.ForegroundColor = ConsoleColor.Black;
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