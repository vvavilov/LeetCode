

public class SolutionWithoutLoop {
    public IList<IList<int>> Subsets(int[] nums) {
        List<IList<int>> result = new();
        Subsets(nums, 0,  new LinkedList<int>(), result);
        return result;
    }
    
    private void Subsets(int[] nums, int index, LinkedList<int> current, IList<IList<int>> result) {
        if(index == nums.Length) {
            result.Add(new List<int>(current));
            return;
        }

        current.AddLast(nums[index]);
        Subsets(nums, index + 1, current, result);
        current.RemoveLast();
        Subsets(nums, index + 1, current, result);
    }
}

public class SolutionWithLoop {
    public IList<IList<int>> Subsets(int[] nums) {
        List<IList<int>> result = new();
        Subsets(nums, 0,  new LinkedList<int>(), result);
        return result;
    }
    
    private void Subsets(int[] nums, int index, LinkedList<int> current, IList<IList<int>> result) {
        result.Add(new List<int>(current));
        
        for(int i = index; i < nums.Length; i++) {
            current.AddLast(nums[i]);
            Subsets(nums, i + 1, current, result);
            current.RemoveLast();
        }
    }
}