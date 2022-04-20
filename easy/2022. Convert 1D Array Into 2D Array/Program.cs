public class Solution {
    public int[][] Construct2DArray(int[] original, int m, int n) {
        /*
            [0 1 2 3 4 5]   n = 2, m = 2
            iterate over original 0 -> original.length
            j = i / n
            k = i % m
            int[j][k] = original[i];
        */
        
        if(m*n != original.Length) { return new int[0][]; }
        
        var solution = new int[m][];
        for(int i = 0; i < m; i++) {
            solution[i] = new int[n];
        }
        
        

        for(int i = 0; i < original.Length; i++) {
            solution[i / n][i % n] = original[i];
        }
        
        return solution;
    }
}