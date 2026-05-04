namespace Figure;

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
    public bool hasMoved { get; set; }

    public Figure(PlayerColor color, PieceType figureType)
    {
        this.color = color;
        this.figureType = figureType;
        this.hasMoved = false;
    }

    public abstract bool IsValidMove(int yStart, int xStart, int yEnd, int xEnd, chessField.ChessField field);

    public override string ToString()
    {
        string c = "";

        if (figureType == PieceType.King) c = "k";
        else if (figureType == PieceType.Queen) c = "q";
        else if (figureType == PieceType.Rook) c = "r";
        else if (figureType == PieceType.Bishop) c = "b";
        else if (figureType == PieceType.Knight) c = "n";
        else if (figureType == PieceType.Pawn) c = "p";

        return color == PlayerColor.Black ? c.ToUpper() : c;
    }
}