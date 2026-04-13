namespace Program;

using System.Runtime.Intrinsics.X86;
using chessField;

public class Progarm{
    public static int Main(){

        ChessField chessField = new();

        Console.WriteLine(chessField.ToString());

        chessField.Move("a1", "b4");

        Console.WriteLine(chessField.ToString());
        
        return 0; 
    }
}