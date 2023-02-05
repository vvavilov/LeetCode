public class Solution {
    public bool CanJump(int[] nums) {
        if(nums.Length == 1) {
            return true;
        }
        
        var reachableStart = 0;
        var reachableEnd = 0;
        
        while(reachableEnd < nums.Length - 1) {
            var newReachableEnd = reachableEnd;
            
            for(int i = reachableStart; i <= reachableEnd; i++) {
                newReachableEnd = Math.Max(newReachableEnd, i + nums[i]);
            }     
            
            if(newReachableEnd <= reachableEnd) {
                return false;
            }
            
            reachableStart = reachableEnd + 1;
            reachableEnd = newReachableEnd;
        }
        
        return true;
        
    }
}