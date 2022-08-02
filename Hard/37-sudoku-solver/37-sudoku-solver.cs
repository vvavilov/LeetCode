public class Solution {
    private static int n = 9;
    private bool[,] cols = new bool[n,n + 1];
    private bool[,] rows = new bool[n,n + 1];
    private bool[,] quadrants = new bool[n,n + 1];
    
    public void SolveSudoku(char[][] board) {
        for(int i = 0; i < board.Length; i++) {
            for(int j = 0; j < board.Length; j++) {                
                if(Char.IsDigit(board[i][j])) {
                    var digit = (int) Char.GetNumericValue(board[i][j]);
                    var quadrantNumber = QuadrantNumber(i, j);
                    cols[j,digit] = true;
                    rows[i,digit] = true;
                    quadrants[quadrantNumber,digit] = true;
                }
            }
        }
        
        Backtrack(board, 0, 0);
    }
    
    private int QuadrantNumber(int y, int x) {
        var quadrantY = y / 3;
        var quadrantX = x / 3;
        return quadrantY * 3 + quadrantX;
    }
    
    private bool Backtrack(char[][] board, int y, int x) {
        if(y == board.Length) {
            return true;
        }
        
        var next = Next(y, x, board.Length);
        
        if(Char.IsDigit(board[y][x])) {
            return Backtrack(board, next.y, next.x);
        }
        
        for(int i = 1; i <= 9; i++) {
            if(!IsValid(y, x, i)) {
                continue;
            }
            
            Try(board, y, x, i);
            
            if(Backtrack(board, next.y, next.x)) {
                return true;
            };

            Invalidate(board, y, x, i);
        }
        
        return false;
    }
    
    private (int y, int x) Next(int y, int x, int length) {
        var nextY = x == length - 1 ? y + 1 : y;
        var nextX = nextY == y ? x + 1 : 0;
        
        return (nextY, nextX);
    }
    
    private void Invalidate(char[][] board, int y, int x, int digit) {
        board[y][x] = '.';
        rows[y,digit] = false;
        cols[x,digit] = false;
        quadrants[QuadrantNumber(y, x),digit] = false;

    }
    
    private void Try(char[][] board, int y, int x, int digit) {
        board[y][x] = (char)('0' + digit);
        rows[y,digit] = true;
        cols[x,digit] = true;
        quadrants[QuadrantNumber(y, x),digit] = true;

    }
    
    private bool IsValid(int y, int x, int digit) {
        if(rows[y,digit]) {
            return false;
        }
        
        if(cols[x,digit]) {
            return false;
        }
        
        if(quadrants[QuadrantNumber(y, x),digit]) {
            return false;
        }
        
        return true;
    }
}