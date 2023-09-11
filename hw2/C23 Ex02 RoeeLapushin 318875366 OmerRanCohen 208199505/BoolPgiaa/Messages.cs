namespace BoolPgiaa
{
    internal class Messages
    {
        private static readonly string sr_InputNotANumber = "Please enter a positive integer.";

        private static readonly string sr_GuessNotInRightFormat = "Your guess is not in the right format.";

        private static readonly string sr_GuessContainsInvalidCharacters = "Your guess contains a character which not a letter or a space.";

        private static readonly string sr_GuessContainsLettersOutOfRange = "Your guess contains a letter which is out of the allowed range.";

        private static readonly string sr_GuessContainsDuplicates = "Your guess contains duplicate letters.";

        private static readonly string sr_InputNotYesOrNo = "Invalid input. Please enter Y or N.";

        private static readonly string sr_Lose = "No more guesses allowed. You Lost.";

        private static readonly string sr_AskForNewGame = "Would you like to start a new game? (Y/N)";

        private static readonly string sr_Goodbye = "Thanks for playing! Goodbye.";

        internal static string InputNotANumber
        {
            get => sr_InputNotANumber;
        }

        internal static string GuessNotInRightFormat
        {
            get => sr_GuessNotInRightFormat;
        }

        internal static string GuessContainsInvalidCharacters
        {
            get => sr_GuessContainsInvalidCharacters;
        }

        internal static string GuessContainsLettersOutOfRange
        {
            get => sr_GuessContainsLettersOutOfRange;
        }

        internal static string GuessContainsDuplicates
        {
            get => sr_GuessContainsDuplicates;
        }

        internal static string InputNotYesOrNo
        {
            get => sr_InputNotYesOrNo;
        }

        internal static string Lose
        {
            get => sr_Lose;
        }

        internal static string AskForNewGame
        {
            get => sr_AskForNewGame;
        }

        internal static string Goodbye
        {
            get => sr_Goodbye;
        }

        internal static string ExpectedFormat(char i_FirstAllowedChar, char i_LastAllowedChar)
        {
            return string.Format("Expecting: <X X X X> where X is an uppercase letter between {0} and {1}.", i_FirstAllowedChar, i_LastAllowedChar);
        }

        internal static string InputNumNotInAllowedRange(int i_MinAllowedNumOfGuesses, int i_MaxAllowedNumOfGuesses)
        {
            return string.Format("Please enter an integer between {0} and {1}.", i_MinAllowedNumOfGuesses, i_MaxAllowedNumOfGuesses);
        }

        internal static string AskForMaximumNumOfGuesses(int i_MinAllowedNumOfGuesses, int i_MaxAllowedNumOfGuesses)
        {
            return string.Format("Enter the maximum number of guesses (between {0} and {1}):", i_MinAllowedNumOfGuesses, i_MaxAllowedNumOfGuesses);
        }

        internal static string AskPlayerForAGuess(string i_QuitGameChar)
        {
            return string.Format("Please type your next guess <A B C D> or {0} to quit", i_QuitGameChar);
        }

        internal static string Win(int i_NumOfSteps)
        {
            return string.Format("Congratulations! You won after {0} steps!", i_NumOfSteps);
        }
    }
}
