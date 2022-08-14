public class Solution {
    public int ArraySign(int[] nums) {
        var isNegativeSoFar = false;

        foreach(var x in nums) {
            if(x == 0) {
                return 0;
            }

            if(x < 0) {
                isNegativeSoFar = !isNegativeSoFar;
            }
        }

        if(isNegativeSoFar) {
            return -1;  
        }

        return 1;
    }
}