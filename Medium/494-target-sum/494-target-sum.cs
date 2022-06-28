public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        if(nums.Length == 0) {
            return 0;
        }
        
        var storage = InitStorage(nums);
        var firstVal = nums[0];
        AddOrCreate(storage[0], 0 - firstVal, 1);
        AddOrCreate(storage[0], 0 + firstVal, 1);
        
        for(int i = 1; i < nums.Length; i++) {
            foreach(var pair in storage[i - 1]) {
                var prevVal = pair.Key;
                var prevCount = pair.Value;
                var curVal = nums[i];
                
                AddOrCreate(storage[i], prevVal + curVal, prevCount);
                AddOrCreate(storage[i], prevVal - curVal, prevCount);
            }
        }

        storage[nums.Length - 1].TryGetValue(target, out var result);
        return result;
    }
    
    private void AddOrCreate(Dictionary<int, int> dict, int key, int val) {
        dict.TryGetValue(key, out var existing);
        dict[key] = existing + val;
    }
    
    private Dictionary<int, int>[] InitStorage(int[] nums) {
        var result = new Dictionary<int, int>[nums.Length];
        
        for(int i = 0; i < nums.Length; i++) {
            result[i] = new Dictionary<int, int>();
        }
        
        return result;
    }
}

public class SolutionTopDown {
    public int FindTargetSumWays(int[] nums, int target) {
        return Dfs(nums, target, 0, new Dictionary<(int pos, int sum), int>());
    }
    
    private int Dfs(int[] nums, int target, int pos, Dictionary<(int pos, int sum), int> mem) {
        if(mem.ContainsKey((pos, target))) {
            return mem[(pos, target)];
        }
        
        if(pos == nums.Length) {
            return target == 0 ? 1 : 0;
        }
        
        var val = nums[pos];
        var posOutcomes = Dfs(nums, target + val, pos + 1, mem);
        var negOutcomes = Dfs(nums, target - val, pos + 1, mem);
        
        var sum =  posOutcomes + negOutcomes;
        mem[(pos, target)] = sum;

        return sum;
        
    }
}