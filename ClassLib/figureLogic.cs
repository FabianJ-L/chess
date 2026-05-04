namespace FigureLogic;

using Figure;
using chessField;
using System;

public class King : Figure
{
    public King(PlayerColor color) : base(color, PieceType.King)
    {
    }

    public override bool IsValidMove(int yStart, int xStart, int yEnd, int xEnd, ChessField field)
    {
        if (yStart < 0 || yStart > 7 || xStart < 0 || xStart > 7 || yEnd < 0 || yEnd > 7 || xEnd < 0 || xEnd > 7)
            return false;

        Figure? target = field.GetFigure(yEnd, xEnd);

        if (target != null && target.color == color)
            return false;

        int dy = Math.Abs(yEnd - yStart);
        int dx = Math.Abs(xEnd - xStart);

        return dx <= 1 && dy <= 1;
    }
}

public class Pawn : Figure
{
    public Pawn(PlayerColor color) : base(color, PieceType.Pawn)
    {
    }

    public override bool IsValidMove(int yStart, int xStart, int yEnd, int xEnd, ChessField field)
    {
        if (yStart < 0 || yStart > 7 || xStart < 0 || xStart > 7 || yEnd < 0 || yEnd > 7 || xEnd < 0 || xEnd > 7)
            return false;

        Figure? target = field.GetFigure(yEnd, xEnd);

        if (target != null && target.color == color)
            return false;

        int dir = color == PlayerColor.White ? -1 : 1;

        if (xStart == xEnd && yEnd == yStart + dir && target == null)
            return true;

        if (!hasMoved &&
            xStart == xEnd &&
            yEnd == yStart + 2 * dir &&
            target == null &&
            field.GetFigure(yStart + dir, xStart) == null)
            return true;

        if (Math.Abs(xEnd - xStart) == 1 &&
            yEnd == yStart + dir &&
            target != null &&
            target.color != color)
            return true;

        return false;
    }
}

public class Knight : Figure
{
    public Knight(PlayerColor color) : base(color, PieceType.Knight)
    {
    }

    public override bool IsValidMove(int yStart, int xStart, int yEnd, int xEnd, ChessField field)
    {
        if (yStart < 0 || yStart > 7 || xStart < 0 || xStart > 7 || yEnd < 0 || yEnd > 7 || xEnd < 0 || xEnd > 7)
            return false;

        Figure? target = field.GetFigure(yEnd, xEnd);

        if (target != null && target.color == color)
            return false;

        int dx = Math.Abs(xEnd - xStart);
        int dy = Math.Abs(yEnd - yStart);

        return (dx == 1 && dy == 2) || (dx == 2 && dy == 1);
    }
}

public class Bishop : Figure
{
    public Bishop(PlayerColor color) : base(color, PieceType.Bishop)
    {
    }

    public override bool IsValidMove(int yStart, int xStart, int yEnd, int xEnd, ChessField field)
    {
        if (yStart < 0 || yStart > 7 || xStart < 0 || xStart > 7 || yEnd < 0 || yEnd > 7 || xEnd < 0 || xEnd > 7)
            return false;

        int[,] validMoves = { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };

        Figure? target = field.GetFigure(yEnd, xEnd);

        if (target != null && target.color == color)
            return false;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j < 8; j++)
            {
                int newX = xStart + validMoves[i, 0] * j;
                int newY = yStart + validMoves[i, 1] * j;

                if (newX < 0 || newX > 7 || newY < 0 || newY > 7)
                    break;

                Figure? blocker = field.GetFigure(newY, newX);

                if (newX == xEnd && newY == yEnd)
                    return blocker == null || blocker.color != color;

                if (blocker != null)
                    break;
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

    public override bool IsValidMove(int yStart, int xStart, int yEnd, int xEnd, ChessField field)
    {
        if (yStart < 0 || yStart > 7 || xStart < 0 || xStart > 7 || yEnd < 0 || yEnd > 7 || xEnd < 0 || xEnd > 7)
            return false;

        int[,] moves = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

        Figure? target = field.GetFigure(yEnd, xEnd);

        if (target != null && target.color == color)
            return false;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j < 8; j++)
            {
                int x = xStart + moves[i, 0] * j;
                int y = yStart + moves[i, 1] * j;

                if (x < 0 || x > 7 || y < 0 || y > 7)
                    break;

                Figure? f = field.GetFigure(y, x);

                if (x == xEnd && y == yEnd)
                    return f == null || f.color != color;

                if (f != null)
                    break;
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

    public override bool IsValidMove(int yStart, int xStart, int yEnd, int xEnd, ChessField field)
    {
        if (yStart < 0 || yStart > 7 || xStart < 0 || xStart > 7 || yEnd < 0 || yEnd > 7 || xEnd < 0 || xEnd > 7)
            return false;

        int[,] moves =
        {
            { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 },
            { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 }
        };

        Figure? target = field.GetFigure(yEnd, xEnd);

        if (target != null && target.color == color)
            return false;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 1; j < 8; j++)
            {
                int x = xStart + moves[i, 0] * j;
                int y = yStart + moves[i, 1] * j;

                if (x < 0 || x > 7 || y < 0 || y > 7)
                    break;

                Figure? f = field.GetFigure(y, x);

                if (x == xEnd && y == yEnd)
                    return f == null || f.color != color;

                if (f != null)
                    break;
            }
        }

        return false;
    }
}