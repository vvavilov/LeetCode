public class Solution {
//     1 2 3 4 5 6
//
        
        //     6 -> 6
    //     56 -> max(5,6);
    //    456 -> max(sum(4,f(6), f(5))
    //   3456 -> max(sum(3,f(56)), sum(4,f(6))
    //  23456 -> max(sum(2, f(456)), sum(3, f(56)))
    // 123456 -> max(sum(1, f(3456)), sum(2, f(456)),
//         f(n) = {
//                  6 -> n[6]
//                  5 -> n[5]
                    // 1-4 -> max(n[n] + n[n+2], n[n+1])
//         
            
            
    public int Rob(int[] nums) {
        if(nums.Length == 1) {
            return nums[0];
        }
        
        var steps = new int[nums.Length];
        var furtherRobResult = nums[0];
        var neighhbourRobResult = Math.Max(nums[1], nums[0]);
        
        for(int i = 2; i < nums.Length; i++) {
            var robCurrent = nums[i] + furtherRobResult;
            var doNotRobCurrent = neighhbourRobResult;
            furtherRobResult = neighhbourRobResult;
            neighhbourRobResult = Math.Max(robCurrent, doNotRobCurrent);
        }
        
        return neighhbourRobResult;
    }
}