namespace Program;

using System.Runtime.Intrinsics.X86;
using chessField;

public class Progarm{
    public static int Main(){

        ChessField chessField = new();

        Console.WriteLine(chessField.ToString());
        while(true){
            Console.Write("Figure (z.B. a1):");
            string? startFigure = Console.ReadLine();
            Console.Write("Field (z.B. a1):");
            string? endFigure = Console.ReadLine();

            chessField.Move(startFigure, endFigure);
            Console.WriteLine(chessField.ToString());
        }
        
        return 0; 
    }
}