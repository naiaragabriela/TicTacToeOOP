
namespace TicTacToeOOP.Models;

public class Piece
{
    public const char Noughts = 'O';
    public const char Crosses = 'X';
    private char currentValue;

    public Piece(char value)
    {
        currentValue = char.ToUpper(value);
    }

    public char GetValue()
    {
        return currentValue;
    }

    public bool IsValid()
    {
        if (currentValue == Noughts)
        {
            return true;
        }

        if (currentValue == Crosses)
        {
            return true;
        }

        return false;
    }
}
