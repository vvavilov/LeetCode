public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        var n = matrix.Length;
        
        if(k > Math.Pow(n, 2)) {
            throw new Exception("k is bigger than items count");
        }
        
        var rowPointers = new int[n];
        int minRow = -1;
        
        while(k-- > 0) {
            minRow = -1;

            for(int i = 0; i < n; i++) {
                var rowPos = rowPointers[i];
                
                if(i > 0 && rowPos == rowPointers[i-1] || rowPos == n) {
                    continue;
                }
                
                if(minRow == -1 || matrix[i][rowPos] < matrix[minRow][rowPointers[minRow]]) {
                    minRow = i;
                }
            }
            
            rowPointers[minRow]++;
        }
        
        return matrix[minRow][rowPointers[minRow] - 1];
    }
}

