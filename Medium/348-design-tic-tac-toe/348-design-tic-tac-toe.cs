public class TicTacToe {
    // 0  1  2
    // 3  4  5
    // 6  7  8
    private int[][] board;
    private int n;
    
    public TicTacToe(int n) {
        this.n = n;
        board = new int[n][];
        
        for(int i = 0; i < n; i++) {
            board[i] = new int[n];
        }
    }
    
    public int Move(int row, int col, int player) {
        board[row][col] = player;
        
        if(WonByRow(row, player)
           || WonByColumn(col, player)
           || WonByLeftDiagonal(row, col, player)
           || WonByRightDiagonal(row, col, player)
          ) {
            return player;
        }
        
        return 0;
    }
    
    private bool WonByRow(int row, int player) {
        return board[row].All(x => x == player);
    }
    
    private bool WonByColumn(int column, int player) {
        for(int i = 0; i < n; i++) {
            if(board[i][column] != player) {
                return false;
            }
        }
        
        return true;
    }
    
    private bool WonByLeftDiagonal(int row, int col, int player) {
        if(row != col) {
            return false;
        }
        
        for(int i = 0; i < n; i++) {
            if(board[i][i] != player) {
                return false;
            }
        }
        
        return true;
    }
    
    private bool WonByRightDiagonal(int row, int col, int player) {
        if(row != n - col - 1) {
            return false;
        }
        
        for(int i = 0; i < n; i++) {
            if(board[n - i - 1][i] != player) {
                return false;
            }
        }
        
        return true;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */