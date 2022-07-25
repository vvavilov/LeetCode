public class Solution {
    public int Jump(int[] nums) {
        var solution = new int[nums.Length];
        Array.Fill(solution, Int32.MaxValue);
        
        solution[0] = 0;

        for(int i = 0; i < nums.Length - 1; i++) {
            for(int j = 1; j <= nums[i]; j++) {
                var jumpsSoFar = solution[i];
                var stepToReach = i + j;
                
                if(stepToReach >= nums.Length) {
                    break;
                }
                
                solution[stepToReach] = Math.Min(solution[stepToReach], jumpsSoFar + 1);
            }
        }
        
        return solution[nums.Length - 1];        
    }
}