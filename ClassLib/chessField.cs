namespace chessField;

using System.Data;
using System.Xml;
using Figure;
using FigureLogic;

public class ChessField
{

    private Figure?[,] playFieldArray;


    public ChessField()
    {
        playFieldArray = new Figure?[8, 8];
        SetUpBoard();
    }

    public void Move(string startPos, string endPos)
    {
        int xStartPos = char.ToLower(startPos[0]) - 'a';
        int yStartPos = 0;

        int xEndPos = char.ToLower(endPos[0]) - 'a';
        int yEndPos = 0;

        if (int.TryParse(startPos.Substring(1), out int numberStart))
        {
            if (numberStart <= 8 && numberStart >= 1)
            {
                yStartPos = numberStart - 1;
            }
            else
            {
                throw new ArgumentException("number start postition isn't a valid input");
            }
        }
        else
        {
            throw new ArgumentException("number start postition isn't a number");
        }

        if (int.TryParse(endPos.Substring(1), out int numberEnd))
        {
            if (numberEnd <= 8 && numberEnd >= 1)
            {
                yEndPos = numberEnd - 1;
            }
            else
            {
                throw new ArgumentException("number end postition isn't a valid input");
            }
        }
        else
        {
            throw new ArgumentException("number end postition isn't a number");
        }

        if (xStartPos < 0 || xStartPos > 7)
            throw new ArgumentException("letter start postition isn't a valid input");

        if (xEndPos < 0 || xEndPos > 7)
            throw new ArgumentException("letter end postition isn't a valid input");

        Figure? moveFigure = playFieldArray[xStartPos, yStartPos];

        if (moveFigure == null)
            throw new ArgumentException("The field is null");

        playFieldArray[yStartPos, xStartPos] = null;
        playFieldArray[yEndPos, xEndPos] = moveFigure;
    }

    public void SetUpBoard()
    {
        playFieldArray[0, 0] = new Rook(PlayerColor.Black);
        playFieldArray[0, 1] = new Knight(PlayerColor.Black);
        playFieldArray[0, 2] = new Bishop(PlayerColor.Black);
        playFieldArray[0, 3] = new Queen(PlayerColor.Black);
        playFieldArray[0, 4] = new King(PlayerColor.Black);
        playFieldArray[0, 5] = new Bishop(PlayerColor.Black);
        playFieldArray[0, 6] = new Knight(PlayerColor.Black);
        playFieldArray[0, 7] = new Rook(PlayerColor.Black);

        for (int x = 0; x < 8; x++)
        {
            playFieldArray[1, x] = new Pawn(PlayerColor.Black);
        }

        for (int x = 0; x < 8; x++)
        {
            playFieldArray[6, x] = new Pawn(PlayerColor.White);
        }

        playFieldArray[7, 0] = new Rook(PlayerColor.White);
        playFieldArray[7, 1] = new Knight(PlayerColor.White);
        playFieldArray[7, 2] = new Bishop(PlayerColor.White);
        playFieldArray[7, 3] = new Queen(PlayerColor.White);
        playFieldArray[7, 4] = new King(PlayerColor.White);
        playFieldArray[7, 5] = new Bishop(PlayerColor.White);
        playFieldArray[7, 6] = new Knight(PlayerColor.White);
        playFieldArray[7, 7] = new Rook(PlayerColor.White);
    }



    public Figure? GetFigure(int x, int y)
    {
        if (x < 0 || x >= playFieldArray.GetLength(0) || y < 0 || y >= playFieldArray.GetLength(1))
            return null;

        return playFieldArray[x, y];
    }

    public override string ToString()
    {
        string Display(int x, int y) => GetFigure(x, y)?.ToString() ?? " ";
        string DisplayHashtag(int x, int y) => GetFigure(x, y)?.ToString() ?? "#";

        string playField = $"  a  b  c  d  e  f  g  h \n +--+--+--+--+--+--+--+--+\n";

        for (int i = 0; i < 8; i++)
        {
            playField += i + 1;

            for (int j = 0; j < 8; j++)
            {

                if ((i + j) % 2 == 0)
                {
                    playField += "|" + Display(i, j) + " ";
                }
                else
                {
                    playField += "|" + DisplayHashtag(i, j) + " ";
                }

            }
            playField += "| \n +--+--+--+--+--+--+--+--+\n";
        }

        return playField;
    }

}