public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length == 1) {
            return nums[0];
        }
        /*
        1 2 3 4 5
        each -> rob\do not rob with money result
        each - will have next state based on prev
        1 is decided to rob - we cannot rob 5
        1 is decided to skip - we can rob 5
        */
        var robFirstPlan = PlanRobbery(nums, 0, nums.Length - 2 );
        var doNotRobFirst = PlanRobbery(nums, 1, nums.Length - 1);
        return Math.Max(robFirstPlan, doNotRobFirst);
    }
    
    public int PlanRobbery(int[] nums, int firstStep, int lastStep) {
        var rob = nums[firstStep];
        var doNotRob = 0;
        
        for(int i = firstStep + 1; i <= lastStep; i++) {
            var tryToRob = doNotRob + nums[i];
            doNotRob = Math.Max(doNotRob, rob);
            rob = tryToRob;
        }
        
        return Math.Max(doNotRob, rob);
        
    }
}