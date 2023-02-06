public class Solution {
    private HashSet<(int y, int x)> visited = new();
    private string word;
    private char[][] board;
    
    private (int y, int x)[] directions = new (int y, int x)[] {
        (0, 1),
        (1, 0),
        (0, -1),
        (-1, 0)
    };
    
    public bool Exist(char[][] board, string word) {
        this.word = word;
        this.board = board;
        
        for(int i = 0; i < board.Length; i++) {
            for(int j = 0; j < board[0].Length; j++) {
                if(Backtrack(board, (i, j), 0)) {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    private bool Backtrack(char[][] board, (int y, int x) cell, int pos) {
        if (board[cell.y][cell.x] != word[pos]) {
            return false;
        }
        
        visited.Add(cell);
        
        if(visited.Count == word.Length) {
            return true;
        }
        
        foreach(var dir in directions) {
            (int y, int x) neigh = (cell.y + dir.y, cell.x + dir.x);
            
            if(!IsInsideBoard(board, neigh) || visited.Contains(neigh)) {
                continue;
            }
            
            if(Backtrack(board, neigh, pos + 1)) {
                return true;
            }
        }
        
        visited.Remove(cell);
        return false;
    }
    
    private bool IsInsideBoard(char[][] board, (int y, int x) cell) {
        if(cell.y < 0 || cell.x < 0) {
            return false;
        } 
        
        if(cell.y >= board.Length || cell.x >= board[0].Length) {
            return false;
        }
        
        return true;
    }

}