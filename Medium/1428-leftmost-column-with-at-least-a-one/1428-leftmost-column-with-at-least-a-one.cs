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
        var rows = binaryMatrix.Dimensions()[0];
        var cols = binaryMatrix.Dimensions()[1];
        var leftMostOnePos = cols;
        
        for(int row = 0; row < rows; row++) {
            if(leftMostOnePos == 0) {
                return leftMostOnePos;
            }
            
            for(int col = leftMostOnePos - 1; col >= 0; col--) {
                if(binaryMatrix.Get(row, col) == 1) {
                    leftMostOnePos = col;
                } else {
                    break;

                }
            }
        }
        
        return leftMostOnePos == cols ? -1 : leftMostOnePos;
        
        
    }
}