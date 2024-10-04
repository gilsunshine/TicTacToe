//A CLI game of Tic-Tac-Toe written in C#
//Coded by Gil Sunshine for Recurse Center Application

string[] positions = [" ", " ", " ", " ", " ", " ", " ", " ", " "];
int[,] winningCombinations = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
bool turn = true;
bool gameOver = false;

//Main game loop
void RunGame(){
    StartGame();
    while(gameOver == false){
        DrawBoard();
        GetPlayerInput();
    }
}

//Initial messages explaining how to play the game
void StartGame(){
    Console.WriteLine("Welcome to Tic-Tac-Toe!\n" +
    "_______________________\n\n" +
    "To play the game, get any combination of three in a row on the board below.\n" +
    "When prompted, enter numbers 1-9 to secure a spot on the board.\n" +
    "Player One is represented by an '0' and Player Two is represented by an 'X'.\n\n");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  1  |  2  |  3  ");
    Console.WriteLine("_____|_____|_____");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  4  |  5  |  6  ");
    Console.WriteLine("_____|_____|_____");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  7  |  8  |  9  ");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("\nLet's get started !\n\n");
}

//Prints the current state of the game board to the console
void DrawBoard(){
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  " + positions[0] + "  |  " + positions[1] + "  |  " + positions[2] + "  ");
    Console.WriteLine("_____|_____|_____");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  " + positions[3] + "  |  " + positions[4] + "  |  " + positions[5] + "  ");
    Console.WriteLine("_____|_____|_____");
    Console.WriteLine("     |     |     ");
    Console.WriteLine("  " + positions[6] + "  |  " + positions[7] + "  |  " + positions[8] + "  ");
    Console.WriteLine("     |     |     \n\n"); 
}

void GetPlayerInput(){
    string player = turn ? "One" : "Two";
    Console.WriteLine("Player " + player + ", enter a number 1-9 to mark the board.\n\n");
    int position = Convert.ToInt32(Console.ReadLine()) - 1;
    positions[position] = turn ? "O" : "X";
    CheckBoard();
    turn = !turn;
}

//Logic for checking if either player has secured three spots in a row and won the game
void CheckBoard()
{
    for (int i = 0; i < 8; i++)
    {
        if (positions[winningCombinations[i, 0]] == positions[winningCombinations[i, 1]] && positions[winningCombinations[i, 1]] == positions[winningCombinations[i, 2]] && positions[winningCombinations[i, 0]] != " ")
        {
            Console.WriteLine("Three " + positions[winningCombinations[i,0]] + "'s in a row!\n");
            Console.WriteLine(turn ? "Player One wins!" : "Player Two wins!\n\n");
            DrawBoard();
            gameOver = true;
        }
    }
}

RunGame();