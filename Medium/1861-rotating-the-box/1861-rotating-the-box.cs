public class Solution {
    public char[][] RotateTheBox(char[][] box) {
        if(box == null && box.Length == 0) {
            return box;
        }
        
        return Rotate(ShakeStones(box));
    }
    
    private char[][] ShakeStones(char[][] box) {
        foreach(var row in box) {
            var posForStone = row.Length - 1;
            
            for(var colPos = row.Length - 1; colPos >= 0; colPos--) {
                var cell = row[colPos];
                
                if(cell == '.') {
                    continue;
                }
                
                if(cell == '*') {
                    posForStone = colPos - 1;
                    continue;
                }

                row[colPos] = '.';
                row[posForStone] = '#';
                posForStone = posForStone - 1;
            }
        }
        
        return box;
    }
    
    private char[][] Rotate(char[][] box) {
        var newBox = new char[box[0].Length][];
        
        for(int i = 0; i < newBox.Length; i++) {
            newBox[i] = new char[box.Length];
        }
        
        for(var row = 0; row < box.Length; row++) {
            for(var col = 0; col < box[0].Length; col++) {
                newBox[col][newBox[0].Length - row - 1] = box[row][col];
            } 
        }
        
        return newBox;
    }
}

// 0 1 2
// 3 4 5


// 3 0
// 4 1
// 5 2