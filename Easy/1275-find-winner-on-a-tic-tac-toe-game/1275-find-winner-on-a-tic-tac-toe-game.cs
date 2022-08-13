public class Solution {
    public string Tictactoe(int[][] moves) {
        var game = new char[3][];

        for(int i = 0; i < 3; i++) {
            game[i] = new char[3];
        }

        var isFirst = true;
        var count = 0;
        
        foreach(var turn in moves) {
            count++;
            var row = turn[0];
            var col = turn[1];
            
            game[row][col] = GetSymbol(isFirst);

            if(HasWon(game)) {
                return GetPlayerName(isFirst).ToString();
            }

            isFirst = !isFirst;
        }

        return count == 9 ? "Draw" : "Pending";
    }

    private bool HasWon(char[][] game) {
        for(int i = 0; i < 3; i++) {
            var wonByRow = game[i][0] != '\0' && game[i][0] == game[i][1] && game[i][0] == game[i][2];

            if(wonByRow) {
                return true;
            }
        }

        for(int i = 0; i < 3; i++) {
            var wonByColumn = game[0][i] != '\0' && game[0][i] == game[1][i] && game[0][i] == game[2][i];

            if(wonByColumn) {
                return true;
            }
        }

        return game[0][0] != '\0' && game[0][0] == game[1][1] && game[0][0] == game[2][2]
            || game[0][2] != '\0' && game[0][2] == game[1][1] && game[0][2] == game[2][0];
    }

    private char GetSymbol(bool isFirstPlayer) {
        return isFirstPlayer ? 'X' : 'O';
    }

    private char GetPlayerName(bool isFirstPlayer) {
        return isFirstPlayer ? 'A' : 'B';
    }
}