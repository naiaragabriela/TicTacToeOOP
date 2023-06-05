
namespace TicTacToeOOP.Models;

public class Board
{
    private char[,] grid;
    private const int RowDimension = 0;
    private const int ColumnDimension = 1;

    public Board()
    {
        grid = new[,] { {'1','2','3'}, {'4','5','6'}, {'7','8','9'}};
    }

    public void Show()
    {
        Console.WriteLine("Escolha a posição do tabuleiro para colocar o valor");

        for (int row = 0; row < grid.GetLength(RowDimension); row++)
        {
            for (int column = 0; column < grid.GetLength(ColumnDimension); column++)
            {
                Console.Write("  " + grid[row, column] + "  |");
            }

            Console.WriteLine("\n");
        }
    }

    public bool TrySetPosition(Piece piece, char position)
    {
        bool successSetPosition;

        switch (position)
        {
            case '1':
                successSetPosition = TrySetIndexOf(0, 0, piece.GetValue());
                break;
            case '2':
                successSetPosition = TrySetIndexOf(0, 1, piece.GetValue());
                break;
            case '3':
                successSetPosition = TrySetIndexOf(0, 2, piece.GetValue());
                break;
            case '4':
                successSetPosition = TrySetIndexOf(1, 0, piece.GetValue());
                break;
            case '5':
                successSetPosition = TrySetIndexOf(1, 1, piece.GetValue());
                break;
            case '6':
                successSetPosition = TrySetIndexOf(1, 2, piece.GetValue());
                break;
            case '7':
                successSetPosition = TrySetIndexOf(2, 0, piece.GetValue());
                break;
            case '8':
                successSetPosition = TrySetIndexOf(2, 1, piece.GetValue());
                break;
            case '9':
                successSetPosition = TrySetIndexOf(2, 2, piece.GetValue());
                break;
            default:
                successSetPosition = false;
                break;
        }

        return successSetPosition;
    }

    private bool TrySetIndexOf(int row, int column, char value)
    {
        char matrixPosition = grid[row, column];

        if (char.IsNumber(matrixPosition))
        {
            grid[row, column] = value;
            return true;
        }

        return false;
    }

    public char GetPieceWinner()
    {

        for (int i = 0; i < 3; i ++)
        {
            if ((grid[i, 0] == grid[i, 1]) && (grid[i, 1] == grid[i, 2]))
            {
                return grid[i, 0];
            }

            if ((grid[0, i] == grid[1, i]) && (grid[1, i] == grid[2, i]))
            {
                return grid[0, i];
            }
        }

        if ((grid[0, 0] == grid[1, 1]) && (grid[1, 1] == grid[2, 2]))
        {
            return grid[0, 0];
        }

        if ((grid[0, 2] == grid[1, 1]) && (grid[1, 1] == grid[2, 0]))
        {
            return grid[0, 2];
        }

        return ' ';
    }
}