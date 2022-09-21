public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var greatests = new Dictionary<int, int>();
        
        var stack = new Stack<int>();
        
        foreach(var x in nums2) {
            if(stack.Count == 0 || stack.Peek() >= x) {
                stack.Push(x);
                continue;
            }
            
            while(stack.Count > 0 && stack.Peek() < x) {
                var prev = stack.Pop();
                greatests[prev] = x;
            }
            
            stack.Push(x);
        }
        
        while(stack.Count > 0) {
            greatests[stack.Pop()] = -1;
        }
        
        return nums1.Select(x => greatests[x]).ToArray();
    }
}

// 10 7 5 4 8
