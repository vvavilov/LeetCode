public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        var i = 0;
        var result = new List<IList<int>>();
        Array.Sort(nums);
        while( i < nums.Length) {
            var left = i + 1;
            var right = nums.Length - 1;
            
            while(left < right){
                var cur = nums[i] + nums[left] + nums[right];
                if(cur == 0) {
                    result.Add(new List<int> { nums[i], nums[left], nums[right]});
                    left = GetNextDifferent(nums, left);
                    right = GetPreviousDifferent(nums, right);
                } else if(cur < 0) {
                    left = GetNextDifferent(nums, left);
                } else {
                    right = GetPreviousDifferent(nums, right);
                }
            }
            
            i = GetNextDifferent(nums, i);
        }
    }
    
    private int GetNextDifferent(int [] nums, int i) {
        var cur = nums[i];
        i++;
        while(i < nums.Length) {
            if(cur == nums[i]){
                i++;
            } else {
                return i;
            }     
        }        
        return i;
    }
    
    private int GetPreviousDifferent(int [] nums, int i) {
        var cur = nums[i];
        i--;
        while(i >= 0) {
            if(cur == nums[i]){
                i--;
            } else {
                return i;
            }     
        }        
        return i;
    }
}