public class Solution {
    public int FindNumberOfLIS(int[] nums) {
        Dictionary<int, (int Length, int Count)> dp = new();

        if(nums.Length == 0) {
            return 0;
        }

        dp[0] = (1, 1);
        var maxLength = 1;
        var maxCount = 1;
        
        
        for(int i = 1; i < nums.Length; i++) {
            dp[i] = (1, 1);
            
            for(int j = 0; j < i; j++) {
                if(nums[j] >= nums[i]) {
                    continue;
                }
                
                UpdateMax(dp[j].Length + 1, dp[j].Count, i, dp);
            }
            
            if(dp[i].Length > maxLength) {
                maxLength = dp[i].Length;
                maxCount = dp[i].Count;
            } else if(dp[i].Length == maxLength) {
                maxCount += dp[i].Count;
            }
        }
        
        return maxCount;
    }
    
    private void UpdateMax(int length, int count, int pos, Dictionary<int, (int Length, int Count)> dp) {
        var cur = dp[pos];
        
        if(cur.Length == length) {
            dp[pos] = (length, count + dp[pos].Count);
            return;
        }
        
        if(cur.Length < length) {
            dp[pos] = (length, count);
        }
    }
}

public class SolutionTopDown {
    Dictionary<int, (int Length, int Count)> dp = new();
    
    public int FindNumberOfLIS(int[] nums) {
        var maxCount = 0;
        var maxLength = 0;
        
        for(int i = 0; i < nums.Length; i++) {
            var result = TopDown(i, nums);
            
            if(result.Length > maxLength) {
                maxLength = result.Length;
                maxCount = result.Count;
                continue;
            }
            
            if(result.Length == maxLength) {
                maxCount += result.Count;
            }
        }
        
        return maxCount;
    }
    
    private (int Length, int Count) TopDown(int pos, int[] nums) {
        if(dp.ContainsKey(pos)) {
            return dp[pos];
        }
        
        dp[pos] = (1, 1);
        
        for(int i = pos + 1; i < nums.Length; i++) {
            if(nums[i] <= nums[pos]) {
                continue;
            }
            
            var child = TopDown(i, nums);
            
            var length = 1 + child.Length;
            UpdateMax(length, child.Count, pos, dp);
        }
        
        return dp[pos];
    }
    
    private void UpdateMax(int length, int count, int pos, Dictionary<int, (int Length, int Count)> dp) {
        var cur = dp[pos];

        if(cur.Length == length) {
            dp[pos] = (length, count + dp[pos].Count);
            return;
        }

        if(cur.Length < length) {
            dp[pos] = (length, count);
        }
    }
}