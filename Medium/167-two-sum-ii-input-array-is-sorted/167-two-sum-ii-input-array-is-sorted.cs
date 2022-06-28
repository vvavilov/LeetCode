public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var first = 0;
        var last = numbers.Length - 1;
        while(first < last) {
            var curSum = numbers[first] + numbers[last];
            if(curSum == target) {
                return new int[] {first+1, last+1};
            }
            
            if(curSum > target) {
                last--;
            } else {
                first++;
            }
        }
        
        return new int[]{};
    }
}