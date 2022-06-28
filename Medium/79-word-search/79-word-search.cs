public class Solution {
    private (int y, int x)[] directions = new (int y, int x)[] {
        (0, 1),
        (1, 0),
        (0, -1),
        (-1, 0)
    };
    
    public bool Exist(char[][] board, string word) {
       for(int i = 0; i < board.Length; i++) {
          for(int j = 0; j < board[0].Length; j++) {
              if(ExistsStartingFrom(i, j, board, word, 0, new HashSet<(int y, int x)>())) {
                  return true;
              }
          } 
       }

        return false;
    }
    
    private bool ExistsStartingFrom(int y, int x, char[][] board, string word, int pos, HashSet<(int y, int x)> used) {
        if(pos == word.Length) {
            return true;
        }

        if(used.Contains((y, x))) {
            return false;
        }        
        
        if(!IsInBoundaries(board, y, x) || board[y][x] != word[pos]) {
            return false;
        }
        
        used.Add((y, x));

        foreach(var dir in directions) {
            if(ExistsStartingFrom(y + dir.y, x + dir.x, board, word, pos + 1, used)) {
                
                return true;
            }
        }

        used.Remove((y, x));
        return false;
    }
    
    private bool IsInBoundaries(char[][] board, int y, int x) {
        return y >= 0
            && y < board.Length
            && x >= 0
            && x < board[0].Length;
    }
    

}