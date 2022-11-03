public class Solution {
    public int PartitionArray(int[] nums, int k) {
        if(nums.Length == 0) {
            return 0;
        }
        
        Array.Sort(nums);
        var count = 1;
        var min = nums[0];
        
        foreach(var x in nums) {
            if(x - k > min) {
                count++;
                min = x;
            }
        }
        
        return count;
    }
}

//        1 2 3 5 6
//        ^
// count  1 1 2
// min    1 1 5
