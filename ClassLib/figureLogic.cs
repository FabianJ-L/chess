namespace FigureLogic;

using Figure;

public class King : Figure{

    public King(PlayerColor color) : base(color, PieceType.King) 
    { 

    } 
}
public class Pawn : Figure{

    public Pawn(PlayerColor color) : base(color, PieceType.Pawn) 
    { 
        
    } 
}
public class Knight : Figure{

    public Knight(PlayerColor color) : base(color, PieceType.Knight) 
    { 
        
    } 
}
public class Bishop : Figure{

    public Bishop(PlayerColor color) : base(color, PieceType.Bishop) 
    { 
        
    } 
}

public class Rook : Figure{

    public Rook(PlayerColor color) : base(color, PieceType.Rook) 
    { 
        
    } 
}

public class Queen : Figure{

    public Queen(PlayerColor color) : base(color, PieceType.Queen) 
    { 
        
    } 
}