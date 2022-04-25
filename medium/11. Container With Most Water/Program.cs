public class Solution {
    public int MaxArea(int[] height) {
        var left = 0;
        var right = height.Length - 1;
        
        var volume = Int32.MinValue;
        
        while(left < right) {
            var leftHeight = height[left];
            var rightHeight = height[right];
            volume = Math.Max(volume, (right - left) * Math.Min(leftHeight, rightHeight));
            
            if(leftHeight < rightHeight) {
                left++;
            } else {
                right--;
            }
        }
        
        return volume;
    }
}