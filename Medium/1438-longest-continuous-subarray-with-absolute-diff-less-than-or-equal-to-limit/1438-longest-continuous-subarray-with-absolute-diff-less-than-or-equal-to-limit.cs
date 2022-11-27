// 10 1 2 4 1 7 2      5
// max:  
// min: 1

public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
        var left = 0;
        var right = 0;
        var length = 0;
        
        var max = new LinkedList<int>();
        var min = new LinkedList<int>();
        
        while(right < nums.Length) {
            while(max.Count > 0 && nums[max.Last.Value] < nums[right]) {
                max.RemoveLast();
            }
            
            max.AddLast(right);
            
            while(min.Count > 0 && nums[min.Last.Value] > nums[right]) {
                min.RemoveLast();
            }
            
            min.AddLast(right);
            
            while(nums[max.First.Value] - nums[min.First.Value] > limit) {
                if(max.First.Value == left) {
                    max.RemoveFirst();
                }
                
                if(min.First.Value == left) {
                    min.RemoveFirst();
                }
                
                left++;

            }
            

            length = Math.Max(length, right - left + 1);
            right++;
        }
        
        return length;

    }
}
