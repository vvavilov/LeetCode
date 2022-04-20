static void Rotate(int[] nums, int k) {
    k = k % nums.Length;        
    SwapArray(nums, 0, nums.Length -1);
    SwapArray(nums, 0, k-1);
    SwapArray(nums, k, nums.Length - 1);
}

static void SwapArray(int[] nums, int start, int end) {
    while(end > start) {
        var temp = nums[start];
        nums[start] = nums[end];
        nums[end] = temp;
        
        end--;
        start++;
    }
    
}

static void RotateWithAdditionalMemory(int[] nums, int k) {
    k = k % nums.Length;
    
    var old = (int[])nums.Clone();
    
    for(int i = 0; i < old.Length; i++) {
        var newInd = (i + k) % old.Length;
        nums[newInd] = old[i];
    }
}