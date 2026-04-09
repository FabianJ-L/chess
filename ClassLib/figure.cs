namespace figure;

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

public class Figure()
{
    private PlayerColor _color;
    private PieceType _figureType;

    public Figure(PlayerColor color, PieceType figureType){
        this._color = color;
        this._figureType = figureType;
    }

    public override string ToString()
    {
        return "";
    }

}