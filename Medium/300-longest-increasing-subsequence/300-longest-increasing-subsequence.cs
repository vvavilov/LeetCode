public class Solution {
    public int LengthOfLIS(int[] nums) {
        var length = new int[nums.Length];
        length[0] = 1;
        
        for(int i = 1; i < nums.Length; i++) {
            length[i] = 1;

            for(int j = 0; j < i; j++) {
                if(nums[j] < nums[i]) {
                    length[i] = Math.Max(length[i], 1 + length[j]);
                }
            }
        }
        
        return length.Max();
    }
    
    public int LengthOfLIS2(int[] nums) {
        if(nums.Length == 0) {
            return 0;
        }
        
        var longest = new List<int> { nums[0] };
        
        foreach(var x in nums[1..]) {
            if(x > longest[^1]) {
                longest.Add(x);
            } else {
                var indexToReplace = FindLeastBigger(x, longest);
                longest[indexToReplace] = x;
            }
        }
        
        return longest.Count;
    }
     
    private int FindLeastBigger(int target, List<int> s) {
        var left = 0;
        var right = s.Count - 1;
        
        while(left < right) {
            var mid = (right - left) / 2 + left;
            
            
            if(s[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        
        return left;
    }
}