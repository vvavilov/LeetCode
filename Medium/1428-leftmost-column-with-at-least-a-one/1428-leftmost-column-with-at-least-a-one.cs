/**
 * // This is BinaryMatrix's API interface.
 * // You should not implement it, or speculate about its implementation
 * class BinaryMatrix {
 *     public int Get(int row, int col) {}
 *     public IList<int> Dimensions() {}
 * }
 */

class Solution {
    public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix) {
        var row = 0;
        var rows = binaryMatrix.Dimensions()[0];
        var cols = binaryMatrix.Dimensions()[1];
        
        var colSoFar = cols - 1;
        
        while(row < rows) {
            var val = binaryMatrix.Get(row, colSoFar);

            if(val == 0) {
                row++;
                continue;
            }
            
            if(colSoFar == 0) {
                return colSoFar;
            }
            
            colSoFar--;
        }
        
        if(colSoFar == cols - 1) {
            return -1;
        }
        
        return colSoFar + 1;
    }
}