public class TicTacToe {
    // 0  1  2
    // 3  4  5
    // 6  7  8
    private int n;
    private int[] rows;
    private int[] cols;
    private int diagonal;
    private int antiDiagonal;
    
    public TicTacToe(int n) {
        this.n = n;
        rows = new int[n];
        cols = new int[n];
    }
    
    public int Move(int row, int col, int player) {
        int increment = player == 1 ? 1 : -1;
        
        rows[row] += increment;
        cols[col] += increment;
        
        if(row == col) {
            diagonal+= increment;
        }
        
        if(row == n - col - 1) {
            antiDiagonal += increment;
        }
        
        var winConditionCount = player == 1 ? n : -n;
        
        if(rows[row] == winConditionCount
            || cols[col] == winConditionCount
            || diagonal == winConditionCount
            || antiDiagonal == winConditionCount) {
            return player;
        };
        
        return 0;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */