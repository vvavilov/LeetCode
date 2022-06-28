public class Solution {
    public int FindNumberOfLIS(int[] nums) {
        var mem = new (int, int)[nums.Length];
        
        mem[0] = (1, 1);
        
        for(int i = 1; i < nums.Length; i++) {
            var maxLength = 1;
            var maxCount = 1;
            
            for(int j = 0; j < i; j++) {
                (var leftSize, var leftCount) = mem[j];
                
                if(nums[j] >= nums[i]) {
                    continue;
                }
                
                var length = leftSize + 1;
                
                if(length > maxLength) {
                    maxLength = length;
                    maxCount = leftCount;
                } else if (length == maxLength) {
                    maxCount += leftCount;
                }
            }
            
            mem[i] = (maxLength, maxCount);

        }
                    
        return GetMaxLengthCount(mem);
    }
    
    private int GetMaxLengthCount((int, int)[] results) {
        var maxLength = 0;
        var maxCount = 0;
        
        for(int i = 0; i < results.Length; i++) {
            (var length, var count) = results[i];
            
            if(length > maxLength) {
                maxLength = length;
                maxCount = count;
            } else if(maxLength == length) {
                maxCount += count;
            }
        }
        
        return maxCount;
        
    }
}

public class SolutionTopDown {
    public int FindNumberOfLIS(int[] nums) {
        var maxLength = 0;
        var maxCount = 0;
        
        var mem = new Dictionary<int, (int, int)>();
        for(int i = 0; i < nums.Length; i++) {
            (var length, var count) = FindDP(nums, i, mem);
            
            if(length > maxLength) {
                maxLength = length;
                maxCount = count;
            } else if(length == maxLength) {
                maxCount += count;
            }
        }
        
        return maxCount;
    }
    
    private (int length, int count) FindDP(int[] nums, int pos, Dictionary<int, (int, int)> mem) {
        if(mem.ContainsKey(pos)) {
            return mem[pos];
        }
        
        var maxLength = 1;
        var count = 1;
        
        for(int i = pos + 1; i < nums.Length; i++) {
            if(nums[i] <= nums[pos]) {
                continue;
            }

            (var childLength, var childCount) = FindDP(nums, i, mem);
            var length = childLength + 1;
            
            if(length > maxLength) {
                maxLength = length;
                count = childCount;
            } else if(length == maxLength) {
                count += childCount;
            }
        }
        
        mem[pos] = (maxLength, count);
        return (maxLength, count);

    }
}