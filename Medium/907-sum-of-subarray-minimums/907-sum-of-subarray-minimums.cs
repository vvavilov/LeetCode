public class Solution {
    public int SumSubarrayMins(int[] arr) {
        var mod = (int)Math.Pow(10, 9) + 7;
        
        Stack<int> stack = new();
        double sum = 0;
        var itemRightBorder = 0;
        var source = new List<int>(arr);
        source.Add(Int32.MinValue);
        
        for(int i = 0; i < source.Count; i++) {
            while(stack.Count > 0 && arr[stack.Peek()] >= source[i]) {
                var itemPos = stack.Pop();
                var itemLeftBorder = stack.Count > 0 ? stack.Peek() + 1 : 0;
                var subarraysCount = (0d + itemPos - itemLeftBorder) * (i - itemPos) % mod + i - itemPos;
                sum += subarraysCount * source[itemPos] % mod;
                sum %= mod;
            }
            
            stack.Push(i);            
        }
        
        return (int)sum;
        
//         if(stack.Count == 0) {
//             return (int)sum;
//         }
        
//         itemRightBorder = stack.Peek();
        
//         while(stack.Count > 0) {
//             var itemPos = stack.Pop();
//             var itemLeftBorder = stack.Count > 0 ? stack.Peek() + 1 : 0;
            
//             var subarraysCount = (0d + itemPos - itemLeftBorder) * (itemRightBorder - itemPos + 1) % mod + itemRightBorder - itemPos + 1;
            
//             sum += subarraysCount * arr[itemPos] % mod;
//             sum %= mod;
//         }
        
//         return  (int)sum;
    }
}