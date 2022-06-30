public class Solution {
    public void SortColors(int[] nums) {
        var count = new int[3];
        
        foreach(var x in nums) {
            count[x]++;
        }
        
        var pos = 0;
        
        for(int i = 0; i < count.Length; i++) {
            while(count[i] > 0) {
                nums[pos] = i;
                count[i]--;
                pos++;
            }
        }
    }
}