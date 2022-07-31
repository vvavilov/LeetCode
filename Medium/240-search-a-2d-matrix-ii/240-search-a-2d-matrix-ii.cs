public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        if(matrix.Length == 0) {
            return false;
        }

        return SearchBinary(matrix, target, 0, matrix.Length - 1, 0, matrix[0].Length - 1);    
    }
    
    private bool SearchBinary(int[][] matrix, int target, int startRow, int endRow, int startCol, int endCol) {
        if(startRow > endRow || startCol > endCol) {
            return false;
        }
        
        var midRow = (endRow - startRow) / 2 + startRow;
        var midCol = (endCol - startCol) / 2 + startCol;
        
        var midValue = matrix[midRow][midCol]; 
        if(midValue == target) {
            return true;
        }
        
        if(midValue > target) {
            return SearchBinary(matrix, target, startRow, endRow, startCol, midCol - 1)
                || SearchBinary(matrix, target, startRow, midRow - 1, midCol, endCol);
        } else {
            return SearchBinary(matrix, target, midRow + 1, endRow, startCol, midCol)
                || SearchBinary(matrix, target, startRow, endRow, midCol + 1, endCol);
        }
        
    }
}