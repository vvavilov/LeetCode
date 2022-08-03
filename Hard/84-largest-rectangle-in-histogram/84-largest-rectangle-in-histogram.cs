public class Solution {
    public int LargestRectangleArea(int[] heights) {
        Stack<(int height, int count)> visited = new();
        var max = 0;
        
        for(int i = 0; i < heights.Length; i++) {
            var h = heights[i];
            
            if(visited.Count == 0 || visited.Peek().height < h) {
                visited.Push((h, 1));
                continue;
            }
            
            var accumulatedCount = 0;

            while(visited.Count > 0 && visited.Peek().height >= h) {
                var prev = visited.Pop();
                accumulatedCount += prev.count;
                max = Math.Max(max, accumulatedCount * prev.height);
            }
            
            visited.Push((h, accumulatedCount + 1));
        }
        
        var count = 0;

        while(visited.Count > 0) {
            // Optimize?
            var item = visited.Pop();
            count += item.count;
            max = Math.Max(max, count * item.height);
        }
        
        return max;
    }
}