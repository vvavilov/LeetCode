public class Solution {
    int[][] lengthStartingFrom;
    int maxLength = 0;
    (int y, int x)[] directions = new [] {
        (-1, 0),
        (0, 1),
        (1, 0),
        (0, -1)
    };
    
    public int LongestIncreasingPath(int[][] matrix) {
        if(matrix.Length == 0) {
            return 0;
        }

        lengthStartingFrom = new int[matrix.Length][];

        for(int i = 0; i < matrix.Length; i++) {
            lengthStartingFrom[i] = new int[matrix[0].Length];
        }

        for(int i = 0; i < matrix.Length; i++) {
            for(int j = 0; j < matrix[0].Length; j++) {
                GetLengthStartingFrom(matrix, i, j, -1);
            }
        }

        return maxLength;
    }

    private int GetLengthStartingFrom(int[][] matrix, int y, int x, int prevValue) {
        if(y < 0 || y >= matrix.Length || x < 0 || x >= matrix[0].Length) {
            return 0;
        }

        if(matrix[y][x] <= prevValue) {
            return 0;
        }

        if(lengthStartingFrom[y][x] != 0) {
            return lengthStartingFrom[y][x];
        }

        var lengthSoFar = 1;
        
        foreach(var dir in directions) {
            lengthSoFar = Math.Max(lengthSoFar, GetLengthStartingFrom(matrix, y + dir.y, x + dir.x, matrix[y][x]) + 1);
        }

        lengthStartingFrom[y][x] = lengthSoFar;
        maxLength = Math.Max(maxLength, lengthSoFar);
        return lengthSoFar;
    }

    
}