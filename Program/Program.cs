namespace Program;

using chessField;

public class Progarm
{
    public static int Main()
    {
        try
        {
            ChessField chessField = new ChessField();

            Console.WriteLine(chessField.ToString());

            while (true)
            {
                try
                {
                    Console.Write("Figure (z.B. a1): ");
                    string? startFigure = Console.ReadLine();

                    Console.Write("Field (z.B. a1): ");
                    string? endFigure = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(startFigure) || string.IsNullOrWhiteSpace(endFigure))
                    {
                        Console.WriteLine("Ungültige Eingabe.");
                        continue;
                    }

                    chessField.Move(startFigure, endFigure);

                    Console.WriteLine(chessField.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fehler beim Zug: " + ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fataler Fehler: " + ex.Message);
            return 1;
        }
    }
}