public class Solution {
    private char[][] board;
    private string word;
    
    private List<(int y, int x)> directions = new List<(int y, int x)> {
        (-1, 0),
        (0, 1),
        (1, 0),
        (0, -1)
    };
    
    public bool Exist(char[][] board, string word) {
        this.board = board;
        this.word = word;
        
        for(int i = 0; i < board.Length; i++) {
            for(int j = 0; j < board[0].Length; j++) {
                if(FindWord(0, i, j, new HashSet<(int y, int x)>())) {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    private bool FindWord(int wordPos, int y, int x, HashSet<(int y, int x)> visited) {
        if(wordPos == word.Length - 1) {
            return word[wordPos] == board[y][x];
        }

        if(word[wordPos] != board[y][x]) {
            return false;
        }
        
        visited.Add((y, x));
        
        foreach(var dir in directions) {
            var childY = y + dir.y;
            var childX = x + dir.x;
            
            if(!IsInGrid(childY, childX) || visited.Contains((childY,childX))) {
                continue;
            }
            
            if(FindWord(wordPos + 1, childY, childX, visited)) {
                return true;
            }
        }
        
        visited.Remove((y, x));        
        return false;
    }
    
    private bool IsInGrid(int y, int x) {
        return y >= 0 
            && x >= 0
            && y < board.Length
            && x < board[0].Length;
    }
}