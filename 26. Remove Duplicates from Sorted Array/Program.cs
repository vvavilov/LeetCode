public class Solution {
    public int RemoveDuplicates(int[] nums) {
        /*
        2 pointers: SLOW, FAST. 
        so if the number is the same, slow pointer remains, fast moves
        if number is different, it is moved to slowPoiner, slowPointer incremented
        
        1 2 3 4 5 5 6
        */
        
        var slow = 0;
        var fast = 0;        
        var prev = Int32.MinValue;

        while(fast < nums.Length) {
            if(nums[fast] > prev) {
                nums[slow] = nums[fast];
                slow++;
                prev = nums[fast];
            }
            
            fast++;
        }
        
        return slow;
    }
}