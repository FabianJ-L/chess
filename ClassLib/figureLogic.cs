namespace FigureLogic;

using Figure;
using chessField;

public class King : Figure
{

    public King(PlayerColor color) : base(color, PieceType.King)
    {

    }

    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, ChessField field)
    {

        return true;
    }
}
public class Pawn : Figure
{

    public Pawn(PlayerColor color) : base(color, PieceType.Pawn)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, ChessField field)
    {

        return true;
    }
}
public class Knight : Figure
{

    public Knight(PlayerColor color) : base(color, PieceType.Knight)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, ChessField field)
    {

        return true;
    }
}
public class Bishop : Figure
{

    public Bishop(PlayerColor color) : base(color, PieceType.Bishop)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, ChessField field)
    {

        return true;
    }
}

public class Rook : Figure
{

    public Rook(PlayerColor color) : base(color, PieceType.Rook)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, ChessField field)
    {

        return true;
    }
}

public class Queen : Figure
{

    public Queen(PlayerColor color) : base(color, PieceType.Queen)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, ChessField field)
    {

        return true;
    }
}