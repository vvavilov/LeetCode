public class Solution {
    public int LongestConsecutive(int[] nums) {
        if(nums.Length == 0) {
            return 0;
        }
        
        Dictionary<int, int> knownLength = new();
        
        foreach(var x in nums) {
            knownLength[x] = 1;
        }
        
        foreach(var x in nums) {
            if(!knownLength.ContainsKey(x)) {
                continue;
            }
            
            var startingPoint = x;
            var currentPoint = startingPoint + 1;
            
            while(knownLength.ContainsKey(currentPoint)) {
                var length = knownLength[currentPoint];
                knownLength.Remove(currentPoint);
                currentPoint++;
                knownLength[startingPoint] += length;
            }
        }
        
        return knownLength.Values.Max();
    }
}