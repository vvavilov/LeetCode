public class Solution {
    public long SubArrayRanges(int[] nums) {
        return MaxSum(nums) - MinSum(nums);
    }
    
    private long MinSum(int[] nums) {
        Stack<int> stack = new();
        var items = new List<int>(nums);
        items.Add(Int32.MinValue);
        var sum = 0L;
        
        for(int i = 0; i < items.Count; i++) {
            while(stack.Count > 0 && items[stack.Peek()] > items[i]) {
                var pos = stack.Pop();
                var rightBorder = i;
                var leftBorder = stack.Count > 0 ? stack.Peek() : -1;
                sum += (long)items[pos] * (pos - leftBorder) * (rightBorder - pos); 
            }
            
            stack.Push(i);
        }
        
        return sum;
    }
    
    private long MaxSum(int[] nums) {
        Stack<int> stack = new();
        var items = new List<int>(nums);
        items.Add(Int32.MaxValue);
        var sum = 0L;
        
        for(int i = 0; i < items.Count; i++) {
            while(stack.Count > 0 && items[stack.Peek()] < items[i]) {
                var pos = stack.Pop();
                var rightBorder = i;
                var leftBorder = stack.Count > 0 ? stack.Peek() : -1;
                sum += (long)items[pos] * (pos - leftBorder) * (rightBorder - pos); 
            }
            
            stack.Push(i);
        }
        
        return sum;
    }
        
}