namespace chessFieldTest;

using Xunit;
using chessField;
using Figure;
using FigureLogic;

public class ChessFieldTests
{
    [Fact]
    public void ChessField_InitialSetup_ShouldHavePieces()
    {
        var field = new ChessField();

        Assert.NotNull(field.GetFigure(0, 0));
        Assert.NotNull(field.GetFigure(7, 4));
        Assert.IsType<Rook>(field.GetFigure(0, 0));
        Assert.IsType<King>(field.GetFigure(7, 4));
    }

    [Fact]
    public void ChessField_InitialPawns_ShouldBeCorrect()
    {
        var field = new ChessField();

        for (int x = 0; x < 8; x++)
        {
            Assert.IsType<Pawn>(field.GetFigure(1, x));
            Assert.IsType<Pawn>(field.GetFigure(6, x));
        }
    }

    [Fact]
    public void Move_ValidPawnMove_ShouldMovePiece()
    {
        var field = new ChessField();

        // "a2" -> yStartPos = 8 - 2 = 6, xStartPos = 0
        // "a3" -> yEndPos   = 8 - 3 = 5, xEndPos   = 0
        field.Move("a2", "a3");

        Assert.Null(field.GetFigure(6, 0));
        Assert.IsType<Pawn>(field.GetFigure(5, 0));
    }

    [Fact]
    public void Move_InvalidPawnMove_ShouldThrow()
    {
        var field = new ChessField();

        Assert.Throws<ArgumentException>(() => field.Move("a2", "a5"));
    }

    [Fact]
    public void Move_InvalidStartField_ShouldThrow()
    {
        var field = new ChessField();

        Assert.Throws<ArgumentException>(() => field.Move("a3", "a4"));
    }

    [Fact]
    public void Move_InvalidCoordinates_ShouldThrow()
    {
        var field = new ChessField();

        Assert.Throws<ArgumentException>(() => field.Move("z9", "a4"));
    }

    [Fact]
    public void Move_CaptureEnemyPiece_ShouldWork()
    {
        var field = new ChessField();

        // e2 -> y=6,x=4   e4 -> y=4,x=4
        field.Move("e2", "e4");
        // d7 -> y=1,x=3   d5 -> y=3,x=3
        field.Move("d7", "d5");
        // e4 -> y=4,x=4   d5 -> y=3,x=3  (capture)
        field.Move("e4", "d5");

        var piece = field.GetFigure(3, 3);

        Assert.IsType<Pawn>(piece);
        Assert.Equal(PlayerColor.White, piece!.color);
    }

    [Fact]
    public void Move_CannotCaptureOwnPiece_ShouldThrow()
    {
        var field = new ChessField();

        Assert.Throws<ArgumentException>(() => field.Move("a1", "a2"));
    }

    [Fact]
    public void Move_PieceShouldBeRemovedFromStart()
    {
        var field = new ChessField();

        field.Move("a2", "a3");

        // "a2" maps to y=6, x=0
        Assert.Null(field.GetFigure(6, 0));
    }

    [Fact]
    public void Move_BlockingPiece_ShouldThrow()
    {
        var field = new ChessField();

        Assert.Throws<ArgumentException>(() => field.Move("a1", "a3"));
    }

    [Fact]
    public void Move_OutOfBounds_ShouldThrow()
    {
        var field = new ChessField();

        Assert.Throws<ArgumentException>(() => field.Move("a2", "a9"));
    }

    [Fact]
    public void Move_ShouldSetHasMoved()
    {
        var field = new ChessField();

        field.Move("a2", "a3");

        // "a3" maps to y=5, x=0
        var pawn = field.GetFigure(5, 0);

        Assert.True(pawn!.hasMoved);
    }
}