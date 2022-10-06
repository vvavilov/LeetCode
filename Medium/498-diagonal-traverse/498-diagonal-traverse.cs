public class Solution {
    public int[] FindDiagonalOrder(int[][] mat) {
        List<int> output = new();
        var nextToProcess = (0, 0);

        while(true) {
            var lastProcessed = GoUp(mat, nextToProcess, output);

            nextToProcess = IsInBorder(mat, (lastProcessed.y, lastProcessed.x + 1))
                ? (lastProcessed.y, lastProcessed.x + 1)
                : (lastProcessed.y + 1, lastProcessed.x);

            if(!IsInBorder(mat, nextToProcess)) {
                return output.ToArray();

            }

            lastProcessed = GoDown(mat, nextToProcess, output);
            nextToProcess = IsInBorder(mat, (lastProcessed.y + 1, lastProcessed.x))
                ? (lastProcessed.y + 1, lastProcessed.x)
                : (lastProcessed.y, lastProcessed.x + 1);

            if(!IsInBorder(mat, nextToProcess)) {
                return output.ToArray();
            }
        }
    }

    private (int y, int x) GoUp(int[][] mat, (int y, int x) cell, List<int> output) {
        while(IsInBorder(mat, cell)) {
            output.Add(mat[cell.y][cell.x]);
            cell = (cell.y - 1, cell.x + 1);
        }

        return (cell.y + 1, cell.x - 1);
    }

    private (int y, int x) GoDown(int[][] mat, (int y, int x) cell, List<int> output) {
        while(IsInBorder(mat, cell)) {
            output.Add(mat[cell.y][cell.x]);
            cell = (cell.y + 1, cell.x - 1);
        }

        return (cell.y - 1, cell.x + 1);
    }

    private bool IsInBorder(int[][] mat, (int y, int x) cell) {
        return !(cell.y < 0 || cell.y >= mat.Length || cell.x < 0 || cell.x >= mat[0].Length);
    }
    
}