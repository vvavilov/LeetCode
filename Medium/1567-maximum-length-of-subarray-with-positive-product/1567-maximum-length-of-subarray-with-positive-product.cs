//            0 1 2 3 4
//            ^
// posSoFar   0 
// negSoFar   0
// max        0

public class Solution {
    private int max = 0;
    private int maxPositiveSoFar = 0;
    private int maxNegativeSoFar = 0;
    
    public int GetMaxLen(int[] nums) {
        foreach(var x in nums) {
            ResetIfZero(x);
            UpdateCurrentValues(x);
            UpdateMax();
        }
        
        return max;
    }
    
    //        -7,-10,-7,21,20,-12,-34,26,2
    //         ^  ^   ^ ^  ^   ^  ^
    // neg 0 1 1 3 4 5 6 7 8 9
    // pos 0 0 2 2 3 4 5 6 7 8
    // max 0 0 2 3 4
    //
    private void UpdateCurrentValues(int value) {
        if(value == 0) {
            return;
        }
        
        if(value > 0) {
            maxPositiveSoFar++;
            
            if(maxNegativeSoFar > 0) {
                maxNegativeSoFar++;
            }
        }
        
        if(value < 0) {
            var newPos = 0;

            if(maxNegativeSoFar > 0) {
                newPos = maxNegativeSoFar + 1;
            }
            
            maxNegativeSoFar = maxPositiveSoFar + 1;
            maxPositiveSoFar = newPos;
        }
    }
    
    private void UpdateMax() {
        max = Math.Max(max, maxPositiveSoFar);
    }
    
    private void ResetIfZero(int value) {
        if(value == 0) {
            maxPositiveSoFar = 0;
            maxNegativeSoFar = 0;
        }
    }
}