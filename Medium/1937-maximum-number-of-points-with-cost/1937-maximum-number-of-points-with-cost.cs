public class Solution {
    public long MaxPoints(int[][] points) {
        if(points.Length == 0) {
            return 0;
        }

        var prevValues = new long[points[0].Length];

        for(int i = 0; i < prevValues.Length; i++) {
            prevValues[i] = points[0][i];
        }

        var maxPossible = MaxPerRow(prevValues, points, 0);

        for(int i = 1; i < points.Length; i++) {
            for(int j = 0; j < points[0].Length; j++) {
                prevValues[j] = maxPossible[j] + points[i][j];
            }

            maxPossible = MaxPerRow(prevValues, points, i);
        }

        return prevValues.Max();
    }

    private long[] MaxPerRow(long[] rowPoints, int[][] points, int rowNumber ) {
        var maxPossible = new long[points[0].Length];
        maxPossible[0] = rowPoints[0];

        for(int j = 1; j < rowPoints.Length; j++) {
            maxPossible[j] = Math.Max(maxPossible[j - 1] - 1, rowPoints[j]);
        }

        maxPossible[maxPossible.Length - 1] = Math.Max(maxPossible[maxPossible.Length - 1], points[rowNumber][maxPossible.Length - 1]);

        for(int j = rowPoints.Length - 2; j >= 0; j--) {
            maxPossible[j] = Math.Max(maxPossible[j], maxPossible[j + 1] - 1);
        }
        
        return maxPossible;
    }
}