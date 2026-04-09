namespace chessField;

using System.Data;
using System.Xml;
using Figure;
public class ChessField
{

    private Figure?[,] playFieldArray;

    

    public ChessField()
    {
        playFieldArray = new Figure?[7, 7];
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
                }else{
                    playField += "|" + DisplayHashtag(i, j) + " ";
                }

            }
            playField += "| \n +--+--+--+--+--+--+--+--+\n";
        }

        return playField;
    }

}
