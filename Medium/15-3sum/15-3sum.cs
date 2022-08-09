public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);

        List<IList<int>> result = new();
        
        for(int i = 0; i < nums.Length; i++) {
            if(nums[i] > 0) {
                break;
            }
            
            if(i > 0 && nums[i] == nums[i-1]) {
                continue;
            }
        
            var set = new HashSet<int>();

            
            for(int j = i + 1; j < nums.Length; j++) {                
                var rest = 0 - nums[i] - nums[j];
                
                if(set.Contains(rest)) {
                    result.Add(new List<int> { nums[i], nums[j], rest });
                    
                    while(j + 1 < nums.Length && nums[j+1] == nums[j]) {
                        j++;
                    }
                    
                }
                
                // if(!set.Contains(nums[j])) {
                    set.Add(nums[j]);
                // }
            }
        }
        
        return result;
    }
}