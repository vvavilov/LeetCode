// -1 2 -3 4 5
// -1 1 -2 2 7
//

public class NumArrayStupid {
    private int[] nums;
    
    public NumArrayStupid(int[] nums) {
        this.nums = nums;   
    }
    
    public int SumRange(int left, int right) {
        var result = 0;
        for(int i = left; i <= right; i++) {
            result += nums[i];
        }
        
        return result;
        
    }
}

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


/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */