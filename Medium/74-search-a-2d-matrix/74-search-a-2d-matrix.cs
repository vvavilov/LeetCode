public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        var total = matrix.Length * matrix[0].Length;
        var left = 0;
        var right = total - 1;
        
        while(left <= right) {
            var mid = (right - left) / 2 + left;
            (var y, var x) = FromId(matrix, mid);
            
            if(matrix[y][x] == target) {
                return true;
            }
            
            if(matrix[y][x] < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        
        return false;
    }
    
    private (int y, int x) FromId(int[][] matrix, int id) {
        var y = id / matrix[0].Length;
        var x = id - y * matrix[0].Length;
        return (y, x);
    }
}