namespace Figure;
using chessField;
public enum PieceType
{
    None,
    Pawn,
    Knight,
    Bishop,
    Rook,
    Queen,
    King
}

public enum PlayerColor
{
    White,
    Black
}

public abstract class Figure
{
    public PlayerColor color { get; }
    public PieceType figureType { get; }

    public Figure(PlayerColor color, PieceType figureType)
    {
        this.color = color;
        this.figureType = figureType;
    }

    public abstract bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, ChessField field);

    public override string ToString()
    {
        string charPiece = "";

        if (figureType == PieceType.King) charPiece = "k";
        else if (figureType == PieceType.Queen) charPiece = "q";
        else if (figureType == PieceType.Pawn) charPiece = "p";
        else if (figureType == PieceType.Rook) charPiece = "r";
        else if (figureType == PieceType.Bishop) charPiece = "b";
        else if (figureType == PieceType.Knight) charPiece = "n";


        return (color == PlayerColor.Black) ? charPiece.ToUpper() : charPiece;
    }

}