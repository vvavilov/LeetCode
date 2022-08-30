public class Solution {
    public int Trap(int[] height) {
        if(height.Length == 0) {
            return 0;
        }
        
        Stack<int> decreasingHeights = new();
        var amount = 0;
        decreasingHeights.Push(0);
        
        for(int i = 1; i < height.Length; i++) {
            var h = height[i];
            var leftWallPos = decreasingHeights.Peek();
            
            while(height[leftWallPos] <= h) {
                decreasingHeights.Pop();
                
                if(decreasingHeights.Count == 0) {
                    break;
                }
                
                var distance = i - decreasingHeights.Peek() - 1;
                var remainingHeight = Math.Min(h, height[decreasingHeights.Peek()]) - height[leftWallPos];
                amount += remainingHeight * distance;
                leftWallPos = decreasingHeights.Peek();
            }

            decreasingHeights.Push(i);            
        }
        
        return amount;
    }
}