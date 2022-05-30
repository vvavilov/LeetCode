public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        
        
        List<IList<int>> result = new();
        Array.Sort(nums);
        Subsets(nums, 0, new LinkedList<int>(), result);
        
        return result;
    }
    
    private void Subsets(int[] nums, int index, LinkedList<int> current, List<IList<int>> result) {
        result.Add(new List<int> (current));
        
        for(int i = index; i < nums.Length; i++) {
            if(i > index && nums[i] == nums[i - 1]) {
                continue;
            }
            current.AddLast(nums[i]);
            Subsets(nums, i + 1, current, result);
            current.RemoveLast();
        }
    }
    
}

public class SolutionWithoutLoop {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        List<IList<int>> result = new();
        
        Subsets(nums, 0, new LinkedList<int>(), result);
        
        return result;
    }
    
    private void Subsets(int[] nums, int index, LinkedList<int> current, IList<IList<int>> result) {
        if(index == nums.Length) {
            result.Add(new List<int>(current));
        }
        
        current.AddLast(nums[index]);
        Subsets(nums, index + 1, current, result);
        
        current.RemoveLast();
        
        if(index == 0 || nums[index] != result.Last?.Value) {
            Subsets(nums, index + 1, current, result);
        }

        
        
    }
}