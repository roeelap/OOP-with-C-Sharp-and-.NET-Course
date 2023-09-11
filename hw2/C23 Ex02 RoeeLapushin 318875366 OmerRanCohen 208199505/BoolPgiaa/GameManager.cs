using System.Linq;

namespace BoolPgiaa
{
    internal class GameManager
    {
        private readonly int r_MinAllowedNumOfGuesses = 4;
        private readonly int r_MaxAllowedNumOfGuesses = 10;
        private readonly int r_SolutionLength = 4;
        private readonly char r_FirstAllowedChar = 'A';
        private readonly char r_LastAllowedChar = 'H';
        private readonly string r_QuitGameChar = "Q";

        private int m_MaximumNumOfGuesses;
        private GuessHandler m_GuessHandler;

        public void Play()
        {
            bool isPlayerWantsToPlay = true;

            while (isPlayerWantsToPlay)
            {
                m_MaximumNumOfGuesses = askPlayerForMaximumNumOfGuesses();
                m_GuessHandler = new GuessHandler(m_MaximumNumOfGuesses, r_SolutionLength);
                isPlayerWantsToPlay = playRound();
                GUIManager.ClearConsole();
            }

            PrintQuitMessage();
        }

        public void PrintQuitMessage()
        {
            GUIManager.PrintGoodbye();
        }

        private bool playRound()
        {
            while (true)
            {
                GUIManager.PrintBoard(m_GuessHandler.Guesses, m_GuessHandler.Results, m_GuessHandler.NumGuessesUntilNow);

                string guess = askPlayerForAGuess();

                if (r_QuitGameChar.Equals(guess))
                {
                    return false;
                }

                m_GuessHandler.Guess(guess);

                if (m_GuessHandler.IsLatestGuessEqualsSolution())
                {
                    GUIManager.PrintWin(m_GuessHandler.Guesses, m_GuessHandler.Results, m_GuessHandler.NumGuessesUntilNow);
                    break;
                }
                else if (m_GuessHandler.NumGuessesUntilNow == m_MaximumNumOfGuesses)
                {
                    GUIManager.PrintLose(m_GuessHandler.Guesses, m_GuessHandler.Results, m_GuessHandler.NumGuessesUntilNow, m_GuessHandler.Solution);
                    break;
                }
            }

            return checkIfPlayerWantsToPlayAgain();
        }

        private int askPlayerForMaximumNumOfGuesses()
        {
            int maximumNumOfGuesses;
            string maximumNumOfGuessesStr;

            while (true)
            {
                string question = Messages.AskForMaximumNumOfGuesses(r_MinAllowedNumOfGuesses, r_MaxAllowedNumOfGuesses);

                maximumNumOfGuessesStr = GUIManager.AskPlayer(question);

                if (!int.TryParse(maximumNumOfGuessesStr, out maximumNumOfGuesses))
                {
                    GUIManager.PrintMessage(Messages.InputNotANumber);
                    continue;
                }
                else if (!isInputAnAllowedMaximumNumOfGuesses(maximumNumOfGuesses))
                {
                    GUIManager.PrintMessage(Messages.InputNumNotInAllowedRange(r_MinAllowedNumOfGuesses, r_MaxAllowedNumOfGuesses));
                    continue;
                }

                break;
            }

            return maximumNumOfGuesses;
        }

        private string askPlayerForAGuess()
        {
            string guess = null;
            bool isGuessValid = false;

            while (!isGuessValid)
            {
                guess = GUIManager.AskPlayer(Messages.AskPlayerForAGuess(r_QuitGameChar));

                if (r_QuitGameChar.Equals(guess))
                {
                    break;
                }
                else if (!isGuessInTheRightFormat(guess))
                {
                    GUIManager.PrintMessage(Messages.GuessNotInRightFormat);
                    GUIManager.PrintMessage(Messages.ExpectedFormat(r_FirstAllowedChar, r_LastAllowedChar));
                    continue;
                }
                else if (!isGuessContainsOnlyLettersAndSpaces(guess))
                {
                    GUIManager.PrintMessage(Messages.GuessContainsInvalidCharacters);
                    GUIManager.PrintMessage(Messages.ExpectedFormat(r_FirstAllowedChar, r_LastAllowedChar));
                    continue;
                }
                else if (!isGuessContainsAllowedLetters(guess))
                {
                    GUIManager.PrintMessage(Messages.GuessContainsLettersOutOfRange);
                    GUIManager.PrintMessage(Messages.ExpectedFormat(r_FirstAllowedChar, r_LastAllowedChar));
                    continue;
                }
                else if (isGuessContainsDuplicateLetters(guess))
                {
                    GUIManager.PrintMessage(Messages.GuessContainsDuplicates);
                    GUIManager.PrintMessage(Messages.ExpectedFormat(r_FirstAllowedChar, r_LastAllowedChar));
                    continue;
                }

                isGuessValid = true;
            }

            return guess;
        }

        private bool checkIfPlayerWantsToPlayAgain()
        {
            string i_UserResponse;

            while (true)
            {
                i_UserResponse = GUIManager.AskPlayer(Messages.AskForNewGame);

                if (i_UserResponse == "Y")
                {
                    return true;
                }
                else if (i_UserResponse == "N")
                {
                    return false;
                }

                GUIManager.PrintMessage(Messages.InputNotYesOrNo);
            }
        }

        private bool isInputAnAllowedMaximumNumOfGuesses(int i_Input)
        {
            return r_MinAllowedNumOfGuesses <= i_Input && i_Input <= r_MaxAllowedNumOfGuesses;
        }

        private bool isGuessInTheRightFormat(string i_InputGuess)
        {
            string[] guessAsArray = i_InputGuess.Split(' ');
            bool hasRightAmountOfSpaces = guessAsArray.Length == r_SolutionLength;
            bool hasRightAmountOfCharacters = guessAsArray.All(guessPart => guessPart.Length == 1);

            return hasRightAmountOfCharacters && hasRightAmountOfSpaces;
        }

        private bool isGuessContainsOnlyLettersAndSpaces(string i_InputGuess)
        {
            return i_InputGuess.All(guessChar => char.IsLetter(guessChar) || guessChar == ' ');
        }

        private bool isGuessContainsAllowedLetters(string i_InputGuess)
        {
            return i_InputGuess.All(character => isCharAllowed(character));
        }

        private bool isCharAllowed(char i_InputChar)
        {
            bool isCharSpace = i_InputChar == ' ';
            bool isCharInAllowedRange = r_FirstAllowedChar <= i_InputChar && i_InputChar <= r_LastAllowedChar;

            return isCharSpace || isCharInAllowedRange;
        }

        private bool isGuessContainsDuplicateLetters(string i_InputGuess)
        {
            string guessWithoutSpaces = i_InputGuess.Replace(" ", string.Empty);

            // Group characters in the input string by their value,
            // and check if any group has a count greater than 1, indicating duplicates.
            return guessWithoutSpaces.GroupBy(c => c).Any(group => group.Count() > 1);
        }
    }
}
