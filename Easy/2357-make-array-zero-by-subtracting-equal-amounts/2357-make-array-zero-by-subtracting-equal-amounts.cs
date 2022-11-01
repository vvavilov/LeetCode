public class Solution {
    public int MinimumOperations(int[] nums) {
        var hashSet = new HashSet<int>(nums);
        return hashSet.Contains(0) ? hashSet.Count - 1 : hashSet.Count;
    }
}