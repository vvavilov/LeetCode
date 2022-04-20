// Cumulative Sum
public class NumArray {
    private int[] nums;
    
    public NumArray(int[] nums) {
        this.nums = new int[nums.Length];
        this.nums[0] = nums[0];
        for(int i = 1; i < nums.Length; i++ ) {
            this.nums[i] = this.nums[i-1] + nums[i];
        }
    }
    
    public int SumRange(int left, int right) {
        if(left == 0) { return nums[right]; }
        
        return nums[right] - nums[left-1];
        
    }
}
