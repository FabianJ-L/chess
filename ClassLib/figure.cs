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

public class Figure
{
    private PlayerColor _color;
    private PieceType _figureType;

    public Figure(PlayerColor color, PieceType figureType)
    {
        this._color = color;
        this._figureType = figureType;
    }

    public override string ToString()
    {
        string charPiece = "";

        if (_figureType == PieceType.King) charPiece = "k";
        else if (_figureType == PieceType.Queen) charPiece = "q";
        else if (_figureType == PieceType.Pawn) charPiece = "p";
        else if (_figureType == PieceType.Rook) charPiece = "r";
        else if (_figureType == PieceType.Bishop) charPiece = "b";
        else if (_figureType == PieceType.Knight) charPiece = "n";


        return (_color == PlayerColor.Black) ? charPiece.ToUpper() : charPiece;
    }

}