public class Solution {
    public int CountBattleships(char[][] board) {
        if(board.Length == 0) {
            return 0;
        }
        
        var count = 0;

        for(int i = 0; i < board.Length; i++) {
            for(int j = 0; j < board[0].Length; j++) {
                var val = board[i][j];

                if(val == '.') {
                    continue;
                }

                if(i > 0 && board[i - 1][j] == 'X') {
                    continue;
                }

                if(j > 0 && board[i][j - 1] == 'X') {
                    continue;
                }

                count++;
             }
        }

        return count;
    }
}