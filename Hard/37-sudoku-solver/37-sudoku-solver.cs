public class Solution {
    private bool[][] filledCols;
    private bool[][] filledRows;
    private bool[][] filledQuadrants;
    
    public void SolveSudoku(char[][] board) {
        filledCols = new bool[board.Length][];
        filledRows = new bool[board.Length][];
        filledQuadrants = new bool[board.Length][];
        
        for(int i = 0; i < board.Length; i++) {
            filledRows[i] = new bool[10];

            for(int j = 0; j < board.Length; j++) {
                filledCols[j] = filledCols[j] ?? new bool[10];
                var quadrantNumber = QuadrantNumber(i, j);
                filledQuadrants[quadrantNumber] = filledQuadrants[quadrantNumber] ?? new bool[10];
                
                if(Char.IsDigit(board[i][j])) {
                    var digit = (int) Char.GetNumericValue(board[i][j]);

                    filledCols[j][digit] = true;
                    filledRows[i][digit] = true;
                    filledQuadrants[quadrantNumber][digit] = true;
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
        filledRows[y][digit] = false;
        filledCols[x][digit] = false;
        filledQuadrants[QuadrantNumber(y, x)][digit] = false;

    }
    
    private void Try(char[][] board, int y, int x, int digit) {
        board[y][x] = (char)('0' + digit);
        filledRows[y][digit] = true;
        filledCols[x][digit] = true;
        filledQuadrants[QuadrantNumber(y, x)][digit] = true;

    }
    
    private bool IsValid(int y, int x, int digit) {
        if(filledRows[y][digit]) {
            return false;
        }
        
        if(filledCols[x][digit]) {
            return false;
        }
        
        if(filledQuadrants[QuadrantNumber(y, x)][digit]) {
            return false;
        }
        
        return true;
    }
}