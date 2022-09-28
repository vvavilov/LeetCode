public class Solution {
    public long SubArrayRanges(int[] nums) {
        return MaximumSum(nums) - MinimumSum(nums);
    }

    private long MinimumSum(int[] nums) {
        Stack<int> increasing = new();
        long total = 0;
        var listOfNums = new List<int>(nums);
        listOfNums.Add(Int32.MinValue);

        for(int i = 0; i < listOfNums.Count; i++) {
            var cur = listOfNums[i];

            while(increasing.Count > 0 && listOfNums[increasing.Peek()] > cur) {
                var itemPos = increasing.Pop();
                var leftBorder = increasing.Count > 0 ? increasing.Peek() + 1 : 0;
                var subarraysCount = 0L + (itemPos - leftBorder) * (i - itemPos) + i - itemPos;
                total += subarraysCount * listOfNums[itemPos];
            }

            increasing.Push(i);
        }

        return total;

    }

    private long MaximumSum(int[] nums) {
        Stack<int> decreasing = new();
        long total = 0;
        var listOfNums = new List<int>(nums);
        listOfNums.Add(Int32.MaxValue);

        for(int i = 0; i < listOfNums.Count; i++) {
            var cur = listOfNums[i];

            while(decreasing.Count > 0 && listOfNums[decreasing.Peek()] < cur) {
                var itemPos = decreasing.Pop();
                var leftBorder = decreasing.Count > 0 ? decreasing.Peek() + 1 : 0;
                var subarraysCount = 0L + (itemPos - leftBorder) * (i - itemPos) + i - itemPos;
                total += subarraysCount * listOfNums[itemPos];
            }
            
            decreasing.Push(i);
        }

        return total;

    }
}