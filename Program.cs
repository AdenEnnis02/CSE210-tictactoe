class TicTacToe
{
    static void Main(string[] args)
    {
        List<char> board = GetNewBoard();
        char currentPlayer = 'x';

        while (!IsGameOver(board))
        {
            DisplayBoard(board);

            GetMoveChoice(currentPlayer, board);

            currentPlayer = GetNextPlayer(currentPlayer);
        }

        DisplayBoard(board);
        Console.WriteLine("Good game. Thanks for playing!");
    }

    /// <summary>Gets a new instance of the board with the numbers 1-9 in place. </summary>
    /// <returns>A list of 9 strings representing each square.</returns>
    static List<char> GetNewBoard()
    {
        List<char> board = new List<char>()
        {
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9'
        };

        return board;
    }

    /// <summary>Displays the board in a 3x3 grid.</summary>
    /// <param name="board">The board</param>
    static void DisplayBoard(List<char> board)
    {
        Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
    }

    /// <summary>
    /// Determines if the game is over because of a win or a tie.
    /// </summary>
    /// <param name="board">The current board.</param>
    /// <returns>True if the game is over</returns>
    static bool IsGameOver(List<char> board)
    {
        return IsWinner(board, 'x') || IsWinner(board, 'o') || IsTie(board);
        
    }

    /// <summary>Determines if the provided player has a tic tac toe.</summary>
    /// <param name="board">The current board</param>
    /// <param name="player">The player to check for a win</param>
    /// <returns></returns>
    static bool IsWinner(List<char> board, char player)
    {
        if (board[0] == player && board[1] == player && board[2] == player) {
            PrintWinnerMsg(player);
            return true;
        }
        if (board[3] == player && board[4] == player && board[5] == player) {
            PrintWinnerMsg(player);
            return true;
        }
        if (board[6] == player && board[7] == player && board[8] == player) {
            PrintWinnerMsg(player);
            return true;
        }
        if (board[0] == player && board[3] == player && board[6] == player) {
            PrintWinnerMsg(player);
            return true;
        }
        if (board[1] == player && board[4] == player && board[7] == player) {
            PrintWinnerMsg(player);
            return true;
        }
        if (board[2] == player && board[5] == player && board[8] == player) {
            PrintWinnerMsg(player);
            return true;
        }
        if (board[0] == player && board[4] == player && board[8] == player) {
            PrintWinnerMsg(player);
            return true;
        }
        if (board[2] == player && board[4] == player && board[6] == player) {
            PrintWinnerMsg(player);
            return true;
        }
        return false;
    }

    static void PrintWinnerMsg(char player){
        Console.WriteLine($"player {player} is the winner.");
    }
    /// <summary>Determines if the board is full with no more moves possible.</summary>
    /// <param name="board">The current board.</param>
    /// <returns>True if the board is full.</returns>
    static bool IsTie(List<char> board)
    {
        foreach(char value in board)
        {
            if(char.IsDigit(value))
            {
                return false;
            }        
        }
        Console.WriteLine("Tie game!");
        return true;  
    }
    


    /// <summary>Cycles through the players (from x to o and o to x)</summary>
    /// <param name="currentPlayer">The current players sign (x or o)</param>
    /// <returns>The next players sign (x or o)</returns>
    static char GetNextPlayer(char currentPlayer)
    {
        if (currentPlayer.Equals('x')){
            return 'o';
        }
        else{
            return 'x';
        }
        
    }

    /// <summary>Gets the 1-based spot number associated with the user's choice.</summary>
    /// <param name="currentPlayer">The sign (x or o) of the current player.</param>
    /// <returns>A 1-based spot number (not a 0-based index)</returns>
    static void GetMoveChoice(char currentPlayer, List<char> board)
    {
        Console.WriteLine($"player {currentPlayer} make your move: ");
        var input = Console.ReadLine();
        if (int.TryParse(input, out int choice)) {
            if (choice < 1 || choice > 9){
                Console.WriteLine("Choice must be between 1 and 9");
                DisplayBoard(board);
                GetMoveChoice(currentPlayer, board);
            }
            else if (char.IsDigit(board[choice-1])){
                MakeMove(board, choice, currentPlayer);
            }
            else{
                Console.WriteLine($"Spot {choice} is already taken, please choose another.");
                DisplayBoard(board);
                GetMoveChoice(currentPlayer, board);
            }    
        }
        else
        {
            Console.WriteLine($"{input} is not a number. Please choose a value between 1 and 9.");
            DisplayBoard(board);
            GetMoveChoice(currentPlayer, board);
        }
    }

    /// <summary>
    /// Places the current players mark on the board at the desired spot.
    /// This method does NOT check to ensure the spot is available.
    /// </summary>
    /// <param name="board">The current board</param>
    /// <param name="choice">The 1-based spot number (not a 0-based index).</param>
    /// <param name="currentPlayer">The current player's sign (x or o)</param>
    static void MakeMove(List<char> board, int choice, char currentPlayer)
    {
        board[choice - 1] = currentPlayer;
    }
}
