public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        List<int> result = new();

        if(matrix.Length == 0) {
            return result;
        }
        
        ProcessLayer(matrix, matrix.Length, matrix[0].Length, 0, 0, result);
        return result;
    }

    private void ProcessLayer(int[][] matrix, int rowsCount, int colsCount, int x, int y, IList<int> acc) {
        if(rowsCount <= 0 || colsCount <= 0) {
            return;
        }
        
        GoRight(matrix, colsCount, y, x, acc);
        GoDown(matrix, rowsCount - 1, y + 1, x + colsCount - 1, acc);

        if(rowsCount > 1) {
            GoLeft(matrix, colsCount - 1, y + rowsCount - 1, x + colsCount - 2, acc);
        }

        if(colsCount > 1) {
            GoUp(matrix, rowsCount - 2, y + rowsCount - 2, x, acc);
        }

        ProcessLayer(matrix, rowsCount - 2, colsCount - 2, x + 1, y + 1, acc);
    }

    private void GoRight(int[][] matrix, int count, int y, int x, IList<int> acc) {
        while(count-- > 0) {
            acc.Add(matrix[y][x++]);
        }
    }

    private void GoLeft(int[][] matrix, int count, int y, int x, IList<int> acc) {
        while(count-- > 0) {
            acc.Add(matrix[y][x--]);
        }
    }

    private void GoUp(int[][] matrix, int count, int y, int x, IList<int> acc) {
        while(count-- > 0) {
            acc.Add(matrix[y--][x]);
        }
    }

    private void GoDown(int[][] matrix, int count, int y, int x, IList<int> acc) {
        while(count-- > 0) {
            acc.Add(matrix[y++][x]);
        }
    }
}