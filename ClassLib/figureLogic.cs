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
        int[,] validMoves = { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 0, 1 }, { 1, -1 }, { 1, 0 }, { 1, 1 } };

        Figure? target = field.GetFigure(xEnd, yEnd);

        if (target != null && target.color == this.color)
        {
            return false;
        }

        for (int i = 0; i < validMoves.GetLength(0); i++)
        {
            int newX = xStart + validMoves[i, 0];
            int newY = yStart + validMoves[i, 1];

            if (newX == xEnd && newY == yEnd)
            {
                return true;
            }
        }

        return false;
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
        int[,] validMoves = { { -2, -1 }, { -2, 1 }, { -1, -2 }, { -1, 2 }, { 1, -2 }, { 2, -1 }, { 2, 1 }, { 1, 2 } };

        Figure? target = field.GetFigure(xEnd, yEnd);

        if (target != null && target.color == this.color)
        {
            return false;
        }

        for (int i = 0; i < validMoves.GetLength(0); i++)
        {
            int newX = xStart + validMoves[i, 0];
            int newY = yStart + validMoves[i, 1];

            if (newX == xEnd && newY == yEnd)
            {
                return true;
            }
        }

        return false;
    }
}
public class Bishop : Figure
{

    public Bishop(PlayerColor color) : base(color, PieceType.Bishop)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, ChessField field)
    {
        int[,] validMoves = { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };

        Figure? target = field.GetFigure(xEnd, yEnd);

        if (target != null && target.color == this.color)
        {
            return false;
        }

        for (int i = 0; i < validMoves.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++)
            {
                int newX = xStart + validMoves[i, 0] * j;
                int newY = yStart + validMoves[i, 1] * j;

                if (newX == xEnd && newY == yEnd)
                {
                    return true;
                }
                if (field.GetFigure(newX, newY) != null)
                {
                    break;
                }
            }
        }

        return false;
    }
}

public class Rook : Figure
{

    public Rook(PlayerColor color) : base(color, PieceType.Rook)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, ChessField field)
    {
        int[,] validMoves = { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };

        Figure? target = field.GetFigure(xEnd, yEnd);

        if (target != null && target.color == this.color)
        {
            return false;
        }

        for (int i = 0; i < validMoves.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++)
            {
                int newX = xStart + validMoves[i, 0] * j;
                int newY = yStart + validMoves[i, 1] * j;

                if (newX == xEnd && newY == yEnd)
                {
                    return true;
                }
                if (field.GetFigure(newX, newY) != null)
                {
                    break;
                }
            }
        }

        return false;
    }
}

public class Queen : Figure
{

    public Queen(PlayerColor color) : base(color, PieceType.Queen)
    {

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, ChessField field)
    {

                int[,] validMoves = { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 }};

        Figure? target = field.GetFigure(xEnd, yEnd);

        if (target != null && target.color == this.color)
        {
            return false;
        }

        for (int i = 0; i < validMoves.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++)
            {
                int newX = xStart + validMoves[i, 0] * j;
                int newY = yStart + validMoves[i, 1] * j;

                if (newX == xEnd && newY == yEnd)
                {
                    return true;
                }
                if (field.GetFigure(newX, newY) != null)
                {
                    break;
                }
            }
        }

        return false;
    }
}