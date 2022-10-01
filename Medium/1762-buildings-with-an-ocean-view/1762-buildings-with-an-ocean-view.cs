public class Solution {
    public int[] FindBuildings(int[] heights) {
        Stack<int> increasing = new();
        
        for(int i = 0; i < heights.Length; i++) {
            while(increasing.Count > 0 && heights[increasing.Peek()] <= heights[i]) {
                increasing.Pop();
            }
            
            increasing.Push(i);
        }
        
        return increasing.Reverse().ToArray();
    }
}