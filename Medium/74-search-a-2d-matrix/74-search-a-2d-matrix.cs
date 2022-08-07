public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        if(matrix.Length == 0) {
            return false;
        }
        
        var rowsN = matrix.Length;
        var colsN = matrix[0].Length;
        var left = 0;
        var right = rowsN * colsN - 1;
        
        while(left <= right) {
            var mid = (right - left) / 2 + left;
            var midRow = mid / colsN;
            var midCol = mid % colsN;
            
            if(matrix[midRow][midCol] == target) {
                return true;
            }
            
            if(matrix[midRow][midCol] < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        
        return false;
    }
}