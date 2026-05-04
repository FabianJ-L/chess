namespace FigureLogicTest;

using Xunit;
using chessField;
using Figure;
using FigureLogic;

public class PawnTests
{
    [Fact]
    public void Pawn_SingleStep_ShouldBeValid()
    {
        var field = new ChessField();
        var pawn = new Pawn(PlayerColor.White);

        Assert.True(pawn.IsValidMove(6, 0, 5, 0, field));
    }

    [Fact]
    public void Pawn_DiagonalCapture_ShouldBeValid()
    {
        var field = new ChessField();

        field.Move("a2", "a4");
        field.Move("b7", "b5");

        var pawn = field.GetFigure(4, 0);

        Assert.True(pawn.IsValidMove(4, 0, 3, 1, field));
    }

    [Fact]
    public void Pawn_BackwardMove_ShouldBeInvalid()
    {
        var field = new ChessField();
        var pawn = new Pawn(PlayerColor.White);

        Assert.False(pawn.IsValidMove(6, 0, 7, 0, field));
    }
}

public class KnightTests
{
    [Fact]
    public void Knight_ValidMove_ShouldBeTrue()
    {
        var field = new ChessField();
        var knight = new Knight(PlayerColor.White);

        Assert.True(knight.IsValidMove(7, 1, 5, 0, field));
    }

    [Fact]
    public void Knight_InvalidMove_ShouldBeFalse()
    {
        var field = new ChessField();
        var knight = new Knight(PlayerColor.White);

        Assert.False(knight.IsValidMove(7, 1, 5, 1, field));
    }
}

public class BishopTests
{
    [Fact]
    public void Bishop_ClearDiagonal_ShouldBeValid()
    {
        var field = new ChessField();

        // c2 = y=6,x=2  und  d2 = y=6,x=3 muessen frei sein
        // damit der Weg (7,2) -> (6,3) -> (5,4) -> (4,5) blockierungsfrei ist
        field.Move("c2", "c3");
        field.Move("d2", "d3");

        var bishop = new Bishop(PlayerColor.White);

        Assert.True(bishop.IsValidMove(7, 2, 4, 5, field));
    }

    [Fact]
    public void Bishop_BlockedPath_ShouldBeInvalid()
    {
        var field = new ChessField();

        var bishop = new Bishop(PlayerColor.White);

        Assert.False(bishop.IsValidMove(7, 2, 4, 5, field));
    }
}

public class RookTests
{
    [Fact]
    public void Rook_ClearPath_ShouldBeValid()
    {
        var field = new ChessField();

        field.Move("a2", "a4");

        var rook = field.GetFigure(7, 0);

        Assert.True(rook.IsValidMove(7, 0, 5, 0, field));
    }

    [Fact]
    public void Rook_BlockedPath_ShouldBeFalse()
    {
        var field = new ChessField();
        var rook = new Rook(PlayerColor.White);

        Assert.False(rook.IsValidMove(7, 0, 3, 0, field));
    }
}

public class QueenTests
{
    [Fact]
    public void Queen_DiagonalMove_ShouldBeValid()
    {
        var field = new ChessField();

        field.Move("d2", "d3");
        field.Move("c2", "c3");

        var queen = new Queen(PlayerColor.White);

        Assert.True(queen.IsValidMove(7, 3, 4, 0, field));
    }

    [Fact]
    public void Queen_StraightMove_ShouldBeValid()
    {
        var field = new ChessField();

        // d2->d4: Bauer landet auf y=4,x=3 -> (6,3) und (5,3) sind frei
        field.Move("d2", "d4");

        var queen = new Queen(PlayerColor.White);

        Assert.True(queen.IsValidMove(7, 3, 5, 3, field));
    }
}

public class KingTests
{
    [Fact]
    public void King_OneStep_ShouldBeValid()
    {
        var field = new ChessField();

        field.Move("e2", "e3");

        var king = new King(PlayerColor.White);

        Assert.True(king.IsValidMove(7, 4, 6, 4, field));
    }

    [Fact]
    public void King_TwoSteps_ShouldBeInvalid()
    {
        var field = new ChessField();
        var king = new King(PlayerColor.White);

        Assert.False(king.IsValidMove(7, 4, 5, 4, field));
    }
}