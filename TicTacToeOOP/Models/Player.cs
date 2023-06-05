namespace TicTacToeOOP.Models;

public class Player
{
    private string name;
    private Piece piece;

    public Player(string name, Piece piece)
    {
        this.name = name;
        this.piece = piece;
    }

    public string GetName()
    {
        return name;
    }

    public Piece GetPiece() { return  piece; }
}