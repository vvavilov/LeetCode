public class Solution {
    public bool IsToeplitzMatrix(int[][] matrix) {
        if(matrix.Length == 0) {
            return false;
        }

        for(int i = 0; i < matrix[0].Length; i++) {
            var firstValue = matrix[0][i];
            var row = 0;
            var col = i;

            while(row < matrix.Length && col < matrix[0].Length) {
                if(matrix[row][col] != firstValue) {
                    return false;
                }

                col++;
                row++;
            }
        }

        for(int i = 0; i < matrix.Length; i++) {
            var firstValue = matrix[i][0];
            var row = i;
            var col = 0;

            while(row < matrix.Length && col < matrix[0].Length) {
                if(matrix[row][col] != firstValue) {
                    return false;
                }

                col++;
                row++;
            }
        }

        return true;
    }
}