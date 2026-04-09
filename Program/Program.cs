namespace Program;

using chessField;

public class Progarm{
    public static int Main(){

        ChessField chessField = new();

        Console.WriteLine(chessField.ToString());
        
        return 0; 
    }
}